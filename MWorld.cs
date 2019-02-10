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
        public static bool DownedDripplerBoss = false;
		private const int saveVersion = 0;
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Project Nine Ores", ProjectIXOres));
			}
		}
		
		private void ProjectIXOres(GenerationProgress progress)
		{
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Project Nine Ores";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
			{
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

				WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), mod.TileType("ApocliteShardTile"), false, 0f, 0f, false, true);
                
			}
            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) //Glacite generation
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.active() && (tile.type == TileID.SnowBlock || tile.type == TileID.IceBlock))
                {
                    WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(3, 7), mod.TileType("GlaciteOreTile"), false, 0f, 0f, true, true);
                }
            }
            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) //Magmite generation
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

                WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), mod.TileType("MagmiteOreTile"), false, 0f, 0f, false, true);

            }
            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) //Coralite generation
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(6, 8), WorldGen.genRand.Next(5, 6), mod.TileType("CoraliteTile"), false, 0f, 0f, false, true);

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
