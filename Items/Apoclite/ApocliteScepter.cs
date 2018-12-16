using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Apoclite
{
	public class ApocliteScepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apoclite Scepter");
			Tooltip.SetDefault("Fires a deadly barage of energy");
			Item.staff[item.type] = true; 
		}
		public override void SetDefaults()
		{
			item.damage = 42;
			item.magic = true;
			item.noMelee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 4;
			item.useAnimation = 4;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 8;
			item.mana = 5;
			item.UseSound = SoundID.Item13;
			item.autoReuse = true;
			item.shootSpeed = 20f;
			item.shoot = mod.ProjectileType("ApocliteOrbMagic");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 20f * 0.0174f;//45 degrees converted to radians
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double baseAngle = Math.Atan2(speedX, speedY);
			double randomAngle = baseAngle+(Main.rand.NextFloat()-0.5f)*spread;
			speedX = baseSpeed*(float)Math.Sin(randomAngle);
			speedY = baseSpeed*(float)Math.Cos(randomAngle);

			return true;
		}
		
		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocliteCrystal", 16);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}