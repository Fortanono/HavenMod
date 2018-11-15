using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HavenMod.Items
{
    public class olympiumbar : ModItem
    {
        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 0, 75, 0);
            item.maxStack = 99;
            item.rare = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Olympium Bar");
            Tooltip.SetDefault("'Piped with molten marble'");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltOre, 4);
            recipe.AddIngredient(3081, 35);
            recipe.SetResult(this);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumOre, 4);
            recipe.AddIngredient(3081, 35);
            recipe.SetResult(this);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
        }
    }
}
