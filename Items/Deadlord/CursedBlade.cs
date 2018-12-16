using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Deadlord
{
	public class CursedBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Blade");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 26;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.useTime = 18;
            item.useAnimation = 18;
			item.useStyle = 1;
			item.crit = 8;
			item.knockBack = 5f;
			item.value = Item.buyPrice(0, 0, 75, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DeadlordEmblem", 16);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}