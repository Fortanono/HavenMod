using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories.Reactants
{
    public class kryptongasbottle : ModItem
    {
        public override void SetDefaults()
        {
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 3, 70);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Krypton Gas Bottle");
            Tooltip.SetDefault("[c/ADFF2F:~ ~ ~ Chemist Class ~ ~ ~]\nElectric circuits will fire a sharp krypton arrow with this equipped");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<havenmodplayer>(mod).KryptonGasEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).ElectricReactantEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).TotalElectricReactants += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Glowstick, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}