using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items
{
    public class cryogelhamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jellied Hamaxe");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.useTurn = true;
            item.autoReuse = true;
            item.melee = true;
            item.useAnimation = 40;
            item.useTime = 15;
            item.axe = 14;
            item.hammer = 60;
            item.useStyle = 1;
            item.knockBack = 8;
            item.damage = 11;
            item.value = 150000;
            item.rare = 1;
            item.tileBoost = +1;
            item.UseSound = SoundID.Item1;
            item.scale = 0.85f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "cryogelbar", 12);
            recipe.anyWood = true;
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}