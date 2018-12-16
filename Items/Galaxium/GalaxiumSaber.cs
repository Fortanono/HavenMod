using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Galaxium
{
	public class GalaxiumSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxium Saber");
			Tooltip.SetDefault("Creates a galactic explosion at your cursor location");
		}
		public override void SetDefaults()
		{
			item.damage = 70;
			item.melee = true;
			item.width = 62;
			item.height = 62;
			item.useTime = 60;
            item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 20f;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
            item.shoot = mod.ProjectileType("invisible");
            item.shootSpeed = 0f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mousePosition = Main.MouseWorld;

            float posX = mousePosition.X;
            float posY = mousePosition.Y;

            Projectile.NewProjectile(posX, posY, 0, 0, 296, (int)(item.damage * 0.25), (item.knockBack * 2), Main.myPlayer); // 296 is the explosion from the Inferno Fork

            return true;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GalaxiumBar", 16);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}