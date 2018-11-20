using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories.Reactants
{
    public class sapling : ModItem
    {
        public override void SetDefaults()
        {
            item.rare = 0;
            item.value = Item.sellPrice(0, 0, 0, 70);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapling");
            Tooltip.SetDefault("[c/ADFF2F:~ ~ ~ Chemist Class ~ ~ ~]\nWater guns will fire an evergreen leaf with this equipped");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<havenmodplayer>(mod).SaplingEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).WaterReactantEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).TotalWaterReactants += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Acorn, 20);
            recipe.AddIngredient(ItemID.DirtBlock, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}