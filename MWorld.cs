using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;



namespace HavenMod
{
    public class MWorld : ModWorld
    {
        public static bool dungueonInvasionUp = false;
        public static bool downedDungueonInvasion = false;
public override void PostWorldGen()
		{

			int[] itemsToPlaceInChests = new int[] { mod.ItemType("saltcrystal"), mod.ItemType("potassiumchunk")};
			int itemsToPlaceInChestsChoice = 50;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex]; 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == 0)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[itemsToPlaceInChestsChoice]);
							itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests.Length;
							break;
						}
					}
				}
			}
		}
		
		        //Initialize all variables to their default values
        public override void Initialize()
        {
            Main.invasionSize = 0;
            dungueonInvasionUp = false;
            downedDungueonInvasion = false;
        }

        //Save downed data
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedDungueonInvasion) downed.Add("dungueonInvasion");

            return new TagCompound {
                {"downed", downed}
            };
        }

        //Load downed data
        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedDungueonInvasion = downed.Contains("dungueonInvasion");
        }

        //Sync downed data
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedDungueonInvasion;
            writer.Write(flags);
        }

        //Sync downed data
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedDungueonInvasion = flags[0];
        }

        //Allow to update invasion while game is running
        public override void PostUpdate()
        {
            if (dungueonInvasionUp)
            {
                if (Main.invasionX == (double)Main.spawnTileX)
                {
                    //Checks progress and reports progress only if invasion at spawn
                    DungueonInvasion.CheckDungueonInvasionProgress();
                }
                //Updates the dungeon invasion while it heads to spawn point and ends it
                DungueonInvasion.UpdateDungueonInvasion();
            }
        }
    }
    }
   
}
