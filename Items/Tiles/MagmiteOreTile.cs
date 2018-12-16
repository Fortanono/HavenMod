using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Tiles
{
    public class MagmiteOreTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("MagmiteOre");   //put your CustomBlock name
			minPick = 150;
			mineResist = 6f;
			soundType = 21;
            soundStyle = 2;
            AddMapEntry(new Color(255, 125, 0));
        }
      
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 1f;
            g = 0.5f;
            b = 0f;
        }
    }
}