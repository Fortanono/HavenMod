using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Magmite
{
	[AutoloadEquip(EquipType.Legs)]
	public class MagmiteLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;

			item.value = 0;
			item.rare = 6;
			item.defense = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmite Leggings");
			Tooltip.SetDefault("15% increased magic damage\n10% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += .15f;
			player.moveSpeed += .1f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmiteBar", 18);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
			
		}
	}
}