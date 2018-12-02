using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class cryogellegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Cryogel Boots");
			Tooltip.SetDefault("You are chilled too the core, making you want to run faster."
				+ "\n5% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item .buyPrice(0, 1, 0, 0);
			item.rare = 2;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "cryogelbar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}