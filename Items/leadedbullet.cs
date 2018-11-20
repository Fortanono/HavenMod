using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items
{
	public class leadedbullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leaded Bullets");
			Tooltip.SetDefault("'These bullets seem toxic'");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("leadedbullet");  
			item.shootSpeed = 16f;                  
			item.ammo = AmmoID.Bullet;             
		}

	}
}
