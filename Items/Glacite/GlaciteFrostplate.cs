using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Glacite
{
	[AutoloadEquip(EquipType.Body)]
	public class GlaciteFrostplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 34;
			item.height = 20;

			item.value = 600;
			item.rare = 8;
			item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacite Frostplate");
			Tooltip.SetDefault("15% increased magic damage \n10% increased melee speed");
		}

		public override void UpdateEquip(Player player)
		{
            player.magicDamage += .15f;
			player.meleeSpeed += .10f;
		}
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GlaciteBar", 24);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
	}
}