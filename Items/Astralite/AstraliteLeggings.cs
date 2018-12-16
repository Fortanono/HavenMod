using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Astralite
{
	[AutoloadEquip(EquipType.Legs)]
	public class AstraliteLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;

			item.value = 0;
			item.rare = 6;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astralite Leggings");
			Tooltip.SetDefault("15% increased movement speed\n12% increased ranged damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += .15f;
			player.rangedDamage += .12f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 18);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 18);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
		}
	}
}