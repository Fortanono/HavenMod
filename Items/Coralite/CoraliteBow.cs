using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Coralite
{
	public class CoraliteBow : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coralite Bow");
			Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
		{

			item.damage = 16;
			item.width = 24;
			item.height = 38;
			item.useTime = 20;
			item.ranged = true;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 540;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 4;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Coralite", 60);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}