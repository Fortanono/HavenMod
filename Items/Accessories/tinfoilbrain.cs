using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories
{
    public class tinfoilbrain : ModItem
    {
        public override void SetDefaults()
        {
            item.rare = -12;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tinfoil Brain");
            Tooltip.SetDefault("'It's brainwaves are reflecting back on itself!'\nReduces damage taken by 23%\nYou become perpetually confused");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.23f;
            player.confused = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrainOfConfusion, 1);
            recipe.AddIngredient(ItemID.TinHelmet, 1);
            recipe.AddTile(114);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}