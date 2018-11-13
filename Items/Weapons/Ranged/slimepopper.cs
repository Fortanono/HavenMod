using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
    public class slimepopper : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Popper");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.FlintlockPistol);
			item.damage = 15;
			item.useTime = 11;
			item.width = 18;
			item.height = 11;
			item.useAnimation = 11;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.rare = 2;
			item.shoot = 10;
			item.shootSpeed = 8f;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlintlockPistol, 1);
			recipe.AddIngredient(null, "cryogelbar", 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}