using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class chemistrobe : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Chemist's Robe");
			Tooltip.SetDefault("Ah, old faithful."
				+ "\n+2% chemical crit chance.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item .buyPrice(0, 0, 5, 0);
			item.rare = 2;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			havenmodplayer ModPlayer = havenmodplayer.ModPlayer(player);
			ModPlayer.chemicalCrit += 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}