using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Coralite
{
    public class polyp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Polyp");
            ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.useStyle = 5;
            item.melee = true;
            item.width = 24;
			item.height = 24;
			item.useAnimation = 24;
			item.useTime = 24;
            item.channel = true;
            item.shootSpeed = 16f;
			item.knockBack = 5.7f;
            item.noMelee = true;
			item.noUseGraphic = true;
            item.rare = 4;
            item.value = Item.buyPrice(0, 0, 75, 0);
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("polypproj");
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Coralite", 60);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
    }
}