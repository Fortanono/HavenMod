using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories
{
    public class bamboodivinggear : ModItem
    {
        public override void SetDefaults()
        {
            item.rare = 8;
            item.value = Item.sellPrice(0, 11, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bamboo Diving Gear");
            Tooltip.SetDefault("Grants the ability to swim and greatly extends underwater breathing\nProvides light under water and extra mobility on ice\nReduces enemy spawns and makes enemies less likely to target you while underwater");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.arcticDivingGear = true;
            player.accFlipper = true;
            player.accDivingHelm = true;
            player.iceSkate = true;
            if (player.wet)
              Lighting.AddLight((int) player.Center.X / 16, (int) player.Center.Y / 16, 0.2f, 0.8f, 0.9f);
              player.aggro -= 400;
              player.calmed = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ArcticDivingGear, 1);
            recipe.AddIngredient(ItemID.BreathingReed, 1);
            recipe.AddTile(114);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}