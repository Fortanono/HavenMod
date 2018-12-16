using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Glacite
{
	public class GlaciteAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Glacite Axe");
            Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.damage = 65;
			item.melee = true;
			item.width = 60;
			item.height = 52;
			item.useTime = 12;
			item.useAnimation = 18;
			item.axe = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlaciteBar", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}