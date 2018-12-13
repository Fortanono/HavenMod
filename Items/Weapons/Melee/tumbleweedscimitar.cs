using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Melee
{
	public class tumbleweedscimitar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tumbleweed Scimitar");
			Tooltip.SetDefault("Casts rolling tumbleweeds");
		}
		public override void SetDefaults()
		{
			item.damage = 24;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 30;
			item.shootSpeed = 6.5f;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 3;
			item.shoot = mod.ProjectileType("tumbleweed");
			item.value = Item.buyPrice(gold: 10);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}