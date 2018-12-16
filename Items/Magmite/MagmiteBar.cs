using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Magmite
{
    public class MagmiteBar : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmite Bar");
			Tooltip.SetDefault("'Hot to the touch'");
		}
		
		public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.rare = 5;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.consumable = false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmiteOre", 4);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}