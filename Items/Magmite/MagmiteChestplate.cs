using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Magmite
{
	[AutoloadEquip(EquipType.Body)]
	public class MagmiteChestplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 0;
			item.rare = 6;
			item.defense = 18;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmite Chestplate");
			Tooltip.SetDefault("15% increased melee damage\n+40 Mana");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 15f;
			player.statManaMax2 += 40;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagmiteBar", 24);
			recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}