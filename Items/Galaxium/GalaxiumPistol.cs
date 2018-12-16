using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Galaxium
{
	public class GalaxiumPistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxium Machine Pistol");
			Tooltip.SetDefault("20% chance not to consume ammo");
		}
		public override void SetDefaults()
		{
			item.damage = 35;
			item.crit = 10;
			item.ranged = true;
			item.noMelee = true;
			item.width = 52;
			item.height = 22;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.knockBack = 12;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item12;
			item.autoReuse = true;
			item.shootSpeed = 20f;
			item.useTurn = false;
			item.useAmmo = AmmoID.Bullet;
			item.shoot = 10;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, -2);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;

			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 400, 0))
			{
				position += muzzleOffset;
			}

		    float spread = 5f * 0.0174f;//45 degrees converted to radians
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
			recipe.AddIngredient(null, "GalaxiumBar", 16);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}