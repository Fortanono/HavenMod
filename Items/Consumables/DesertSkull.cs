using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Consumables
{
    public class DesertSkull : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 20;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 3;
            item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Skull");
            Tooltip.SetDefault("Summons the Cowboy Invasion");
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("The Cowboys are coming to pillage!", 178, 128, 28, false);
            Main.PlaySound(SoundID.Roar, player.position, 0);
            DungueonInvasion.StartDungueonInvasion();
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddTile(26);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}