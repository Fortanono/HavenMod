using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class cryogelbody : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Cryogel Breastplate");
			Tooltip.SetDefault("Its so cold."
				+ "\n+5% chemical crit chance.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item .buyPrice(0, 1, 5, 0);
			item.rare = 2;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			havenmodplayer ModPlayer = havenmodplayer.ModPlayer(player);
			ModPlayer.chemicalCrit += 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "cryogelbar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}