using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories
{
    public class vialofchemicals : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vial of Chemicals");
            Tooltip.SetDefault("Increases chemical damage and crit chance");
        }

        public override void SetDefaults()
        {
            item.rare = 1;
            item.value = Item.buyPrice(0, 4, 35, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<havenmodplayer>(mod).chemicalDamage *= 1.03f;
            player.GetModPlayer<havenmodplayer>(mod).chemicalCrit += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SwiftnessPotion, 5);
            recipe.AddIngredient(ItemID.EndurancePotion, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}