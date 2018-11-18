using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HavenMod.Items
{
    public class pyrite : ModItem
    {
        public override void SetDefaults()
        {
            item.value = Item.buyPrice(0, 0, 75, 0);
			item.maxStack = 99;
            item.rare = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pyrite");
            Tooltip.SetDefault("'Only a fool would mistake this for gold.'");
        }

        public override void AddRecipes()
        {
           ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenChair);
            recipe.SetResult(this, 4);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenTable);
            recipe.SetResult(this, 8);
            recipe.AddTile(TileID.AdamantiteForge);
recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenDoor);
            recipe.SetResult(this, 6);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenToilet);
            recipe.SetResult(this, 4);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenBed);
            recipe.SetResult(this, 15);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenPiano);
            recipe.SetResult(this, 15);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenDresser);
            recipe.SetResult(this, 16);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenSofa);
            recipe.SetResult(this, 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldenBathtub);
            recipe.SetResult(this, 14);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.AddRecipe();
        }
    }
}
