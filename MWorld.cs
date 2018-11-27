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
        public static bool spawnOre = false;
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
    }
    }
   
}
