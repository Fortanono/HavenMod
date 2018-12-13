using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
	public class dualduals : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dual Duals");
			Tooltip.SetDefault("'Double the damage!'\n35% chance not to consume ammo");
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.autoReuse = true;
			item.useAnimation = 16;
			item.useTime = 8;
			item.reuseDelay = 12;
			item.width = 50;
			item.height = 18;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.damage = 20;
			item.shootSpeed = 13f;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.knockBack = 1.5f;
			item.rare = 4;
			item.ranged = true;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .35f;
		}
	}
}