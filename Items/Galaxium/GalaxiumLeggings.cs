using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Galaxium
{
	[AutoloadEquip(EquipType.Legs)]
	public class GalaxiumLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;

			item.value = 600;
			item.rare = 8;
			item.defense = 15;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxium Leggings");
			Tooltip.SetDefault("10% increased movement speed\n12% melee critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
			player.meleeCrit += 12;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"GalaxiumBar", 18);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}