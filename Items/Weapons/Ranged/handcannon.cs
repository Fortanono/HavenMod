using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
    public class handcannon : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hand Cannon");
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.ranged = true;
			item.noMelee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 15;
			item.shootSpeed = 7.7f;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.knockBack = 7;
			item.shoot = 162;
			item.value = Item.buyPrice(gold: 10);
			item.rare = 1;
			item.UseSound = SoundID.Item14;
			item.autoReuse = true;
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