using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items
{
    public class cryogelbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jelly Bow");
            Tooltip.SetDefault("Hmm, Squishy");
        }

        public override void SetDefaults()
        {
            item.damage = 26;
            item.ranged = true;
            item.width = 30;
            item.height = 56;
            item.scale = 0.85f;
            item.maxStack = 1;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 150000;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = 1;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 15f;
            item.autoReuse = true;
        }
    }
}