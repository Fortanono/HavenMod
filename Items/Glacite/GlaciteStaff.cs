using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Glacite
{
	public class GlaciteStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacite Staff");
			Tooltip.SetDefault("'Why rain when you can hail on your foe's parade?'");
            Item.staff[item.type] = true;
        }
		public override void SetDefaults()
		{
			item.damage = 48;
			item.magic = true;
			item.noMelee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 6;
            item.useAnimation = 6;
			item.useStyle = 5;
			item.knockBack = 4f;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 8;
			item.mana = 10;
			item.UseSound = SoundID.Item24;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("invisible");
            item.shootSpeed = 20f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mousePosition = Main.MouseWorld;

            float posX = mousePosition.X;
            float posY = mousePosition.Y;

            Projectile.NewProjectile(posX, posY, 0, 0, mod.ProjectileType("Glacicle"), (int)(item.damage * 1), (item.knockBack * 1), Main.myPlayer); // 296 is the explosion from the Inferno Fork

            return true;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlaciteBar", 16);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}