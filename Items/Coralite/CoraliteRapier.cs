using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Coralite
{
	public class CoraliteRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coralite Rapier");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 22;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.useTime = 12;
            item.useAnimation = 12;
			item.useStyle = 1;
			item.crit = 8;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 0, 75, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
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