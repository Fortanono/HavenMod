using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Astralite
{
	public class AstralitePistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astralite Pistol");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 26;
			item.crit = 0;
			item.ranged = true;
			item.noMelee = true;
			item.width = 58;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shootSpeed = 20f;
			item.useTurn = false;
			item.useAmmo = AmmoID.Bullet;
			item.shoot = 10;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}