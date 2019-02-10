using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories.Reactants
{
    public class jungleblossom : ModItem
    {
        public override void SetDefaults()
        {
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 3, 70);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Blossom");
            Tooltip.SetDefault("[c/ADFF2F:~ ~ ~ Chemist Class ~ ~ ~]\n'Destroy your enemies with a show of fabulous petals'\nWater guns will fire a homing petal with this equipped");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<havenmodplayer>(mod).JungleBlossomEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).WaterReactantEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).TotalWaterReactants += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NaturesGift);
            recipe.AddIngredient(ItemID.JungleSpores, 18);
            recipe.AddIngredient(ItemID.Vine, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}