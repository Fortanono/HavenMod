using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Tiles
{
    public class GlaciteOreTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("GlaciteCrystal");   //put your CustomBlock name
			minPick = 205;
			mineResist = 10f;
			soundType = 21;
            soundStyle = 2;
            AddMapEntry(new Color(0, 200, 200));
        }
      
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0f;
            g = 0.5f;
            b = 0.5f;
        }
    }
}