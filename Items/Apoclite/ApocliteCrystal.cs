using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Apoclite
{
    public class ApocliteCrystal : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apoclite Crystal");
			Tooltip.SetDefault("'Pulses with chaotic energy'");
		}
		
		public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.rare = 7;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.consumable = false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocliteShard", 6);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
