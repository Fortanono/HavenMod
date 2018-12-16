using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Apoclite
{
	public class ApocliteBlaster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apoclite Blaster");
			Tooltip.SetDefault("Changes bullets into energy orbs");
		}
		public override void SetDefaults()
		{
			item.damage = 30;
			item.ranged = true;
			item.noMelee = true;
			item.width = 52;
			item.height = 22;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 12;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shootSpeed = 20f;
			item.useTurn = false;
			item.useAmmo = AmmoID.Bullet;
			item.shoot = mod.ProjectileType("ApocliteOrb");
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
			if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
			{
				type = mod.ProjectileType("ApocliteOrb"); // or ProjectileID.FireArrow;
			}
			else
			{
				float spread = 0f * 0.0174f;
				float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
				double startAngle = Math.Atan2(speedX, speedY)- spread/2;
				double deltaAngle = spread/8f;
				double offsetAngle;
				int i;
				for (i = 0; i < 1;i++ )
				{
					offsetAngle = startAngle + deltaAngle * i;
					Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed*(float)Math.Sin(offsetAngle), baseSpeed*(float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
				}
				return false;
			}
			
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