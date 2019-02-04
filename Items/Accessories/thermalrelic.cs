using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories
{
    public class thermalrelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thermal Relic");
            Tooltip.SetDefault("When over 50% mana, you deal 15% more magic damage\nWhen under 50% mana, magic attacks under 10 mana cost nothing\nWhen under 50% mana, magic damage is halved");
        }

        public override void SetDefaults()
        {
            item.rare = 7;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.statMana > player.statManaMax2 * 0.5f)
            {
                player.magicDamage += 0.15f;
            }

            if(player.statMana < player.statManaMax2 * player.statManaMax2 * 0.5f)
            {
                player.magicDamage -= 0.5f;
                if(item.mana <= 10)
                {
                    item.mana = 0;
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 3);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}