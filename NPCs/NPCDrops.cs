using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 
namespace HavenMod.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {

            if (npc.type == NPCID.KingSlime) // for a modded npc add this instead - if (npc.type == mod.NPCType("ModdedNpcName"))
            {


                if (!ModNameWorld.spawnOre)
                {                                                          //  R    G    B   Values

                        Main.NewText("Compressed gel forms in the icy caverns...", 32, 211, 214);
                        for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 30E-05); k++)   //40E-05 is the amount of veins that will spawn
                        {
                            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                            int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer

                            if (Main.tile[X, Y].type == TileID.SnowBlock)
                            {
                                WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("cryogelore"));   //WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9) is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, mod.TileType("CustomOreTile") is the custom tile that will spawn
                            }

                            else if (Main.tile[X, Y].type == TileID.IceBlock)
                            {
                                WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("cryogelore"));
                            }
                        }
                }
                ModNameWorld.spawnOre = true;
            }
        }
    }
}   
