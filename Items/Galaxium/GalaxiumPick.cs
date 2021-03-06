using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Galaxium
{
	public class GalaxiumPick : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Galaxium Pick");
            Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
			item.width = 52;
			item.height = 56;
			item.useTime = 8;
			item.useAnimation = 11;
			item.pick = 205;
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
			recipe.AddIngredient(null, "GalaxiumBar", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}