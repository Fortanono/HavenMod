using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace HavenMod.Items.Tiles
{
    public class cryogelore : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true; //true if you want light emitted
            Main.tileSpelunker[Type] = true;
            drop = mod.ItemType("cryogel"); //name of item that will drop when tile is broken
            AddMapEntry(new Color(32, 211, 214));
            dustType = 135;
            soundType = 21;
            soundStyle = 2;
            minPick = 55;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) //The colors of the light emitted
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }
    }
}
