using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Melee
{
	public class swinginrifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Swingin' Rifle");
		}
		public override void SetDefaults()
		{
			item.damage = 24;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 20;
			item.shootSpeed = 7.7f;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.shoot = 14;
			item.value = Item.buyPrice(gold: 10);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

	}
}