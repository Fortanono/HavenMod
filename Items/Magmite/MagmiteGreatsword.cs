using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Magmite
{
	public class MagmiteGreatsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmite Greatsword");
			Tooltip.SetDefault("'Slow and steady wins the race'");
		}
		public override void SetDefaults()
		{
			item.damage = 96;
			item.melee = true;
			item.width = 64;
			item.height = 72;
			item.useTime = 46;
            item.useAnimation = 46;
			item.useStyle = 1;
			item.knockBack = 20f;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmiteBar", 12);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}