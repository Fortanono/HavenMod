using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Tiles
{
    public class CoraliteTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("Coralite");   //put your CustomBlock name
			minPick = 60;
			mineResist = 3f;
			soundType = 21;
            soundStyle = 2;
            AddMapEntry(new Color(0, 175, 0));
        }
      
    }
}