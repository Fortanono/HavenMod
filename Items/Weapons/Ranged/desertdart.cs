using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
	public class desertdart : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Dart");
			Tooltip.SetDefault("Uses seeds as ammo.");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.useTime = 35;
			item.width = 38;
			item.height = 6;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.UseSound = SoundID.Item64;
			item.rare = 2;
			item.shoot = 10;
			item.shootSpeed = 12f;
			item.autoReuse = true;
			item.ranged = true;
			item.noMelee = true;
			item.useAmmo = 283;
		}
	}
}