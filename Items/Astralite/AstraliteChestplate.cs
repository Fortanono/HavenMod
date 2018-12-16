using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Astralite
{
	[AutoloadEquip(EquipType.Body)]
	public class AstraliteChestplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 0;
			item.rare = 6;
			item.defense = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astralite Chestplate");
			Tooltip.SetDefault("10% increased magic damage\n15% increased ranged critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += .15f;
			player.rangedCrit += 15;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 20);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
		}
	}
}