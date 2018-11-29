using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Consumables
{
    public class FrozenSlimeCore : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Slime Core");
            Tooltip.SetDefault("Spawns compressed gel in your underground ice caves\nDon't use this too often, as it will clutter your slow biome");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 20;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = -12;
            item.consumable = true;

        }

        public override bool UseItem(Player player)
        {
            if (Main.hardMode == false)
            {
                Main.NewText("Compressed gel forms in the icy caverns...", 32, 211, 214);
                Main.PlaySound(SoundID.Roar, player.position, 0);
                for (int k = 0; k < (int)((double)(Main.rockLayer * Main.maxTilesY) * 80E-05); k++)   //40E-05 is the amount of veins that will spawn
                {
                    int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200); //this is the coordinates where the veins ore will spawn, so in Cavern layer

                    if (Main.tile[X, Y].type == TileID.SnowBlock || Main.tile[X, Y].type == TileID.IceBlock)
                    {
                        WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("cryogelore"));   //WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9) is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, mod.TileType("CustomOreTile") is the custom tile that will spawn
                    }
                }
                return true;
            }
            else
            {
                Main.NewText("You can't use this in hard mode dummy...", 32, 211, 214);
            }
            return true;
        }
    }
}