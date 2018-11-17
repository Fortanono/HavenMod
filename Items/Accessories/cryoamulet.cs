using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories
{
    public class cryoamulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amulet of Preservation");
            Tooltip.SetDefault("Increased life regen while moving\n3 defense");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 150000;
            item.rare = 1;
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "cryogelbar", 12);
            recipe.AddIngredient(216);
            recipe.anyWood = true;
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 3;

            if (player.velocity.X != 0 && player.velocity.Y != 0)
            {
                player.lifeRegen += 10;
            }
        }
    }
}
