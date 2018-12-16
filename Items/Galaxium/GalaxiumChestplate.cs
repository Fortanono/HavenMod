using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Galaxium
{
	[AutoloadEquip(EquipType.Body)]
	public class GalaxiumChestplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 18;

			item.value = 600;
			item.rare = 8;
			item.defense = 24;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxium Chestplate");
			Tooltip.SetDefault("15% increased melee and ranged damage");
		}

		public override void UpdateEquip(Player player)
		{
            player.meleeDamage += .15f;
			player.rangedDamage += .15f;
		}
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GalaxiumBar", 24);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
	}
}