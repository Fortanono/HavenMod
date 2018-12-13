using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
	public class melter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Melter");
			Tooltip.SetDefault("'Launches snowballs at incredible speeds!'");
		}

		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 5;
			item.useAnimation = 14;
			item.useTime = 14;
			item.width = 44;
			item.height = 14;
			item.shoot = 166;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.damage = 15;
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 15, 0, 0);
			item.knockBack = 1f;
			item.rare = 4;
			item.ranged = true;
			item.useAmmo = AmmoID.Snowball;
			item.shoot = 166;
		}
	}
}