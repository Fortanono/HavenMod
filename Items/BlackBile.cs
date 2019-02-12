using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items
{
    public class BlackBile : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 0, 17);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Bile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 5);
            recipe.AddIngredient(this, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.UnholyArrow, 5);
            recipe.AddRecipe();
        }
    }
}