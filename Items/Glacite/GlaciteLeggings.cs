using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Glacite
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlaciteLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;

			item.value = 600;
			item.rare = 8;
			item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacite Leggings");
			Tooltip.SetDefault("12% increased movement speed\n10% reduced mana cost");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.12f;
			player.manaCost -= 0.1f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"GlaciteBar", 18);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}