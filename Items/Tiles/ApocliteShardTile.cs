using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Tiles
{
    public class ApocliteShardTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("ApocliteShard");   //put your CustomBlock name
			minPick = 205;
			mineResist = 10f;
			soundType = 21;
            soundStyle = 2;
            AddMapEntry(new Color(100, 0, 0));
        }
      
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)   //light colors
        {
            r = 0.5f;
            g = 0f;
            b = 0f;
        }
    }
}