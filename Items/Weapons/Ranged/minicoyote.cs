using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
	public class minicoyote : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Coyote");
			Tooltip.SetDefault("High fire rate at the expense of accuracy\n50% chance to not consume ammo");
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.autoReuse = true;
			item.useAnimation = 7;
			item.useTime = 7;
			item.width = 50;
			item.height = 18;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item41;
			item.damage = 13;
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 20, 0, 0);
			item.knockBack = 1.5f;
			item.rare = 4;
			item.ranged = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;

			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .5f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -5);
		}
	}
}
