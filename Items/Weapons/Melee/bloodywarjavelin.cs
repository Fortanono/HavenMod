using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Melee
{
    public class bloodywarjavelin : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.useTime = 27;
            item.knockBack = 0;
            item.useAnimation = 27;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.melee = true;
            item.noMelee = true;
            item.width = 42;
            item.height = 42;
            item.scale = 1;
            item.rare = 2;
            item.shoot = mod.ProjectileType("warjavelin");
            item.shootSpeed = 9;
            item.autoReuse = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody War Javelin");
            Tooltip.SetDefault("Throws a powerful javelin that sticks to enemies");
        }
    }
}