using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Magic
{
    public class bloodblazer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Blazer");
            Tooltip.SetDefault("Increases your ability to attract hearts upon hitting an enemy");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.knockBack = 4;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.autoReuse = true;
            item.magic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("bloodblaze");
            item.shootSpeed = 19;
            item.width = 42;
            item.height = 22;
            item.scale = 1;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 30, 0);
        }
    }
}