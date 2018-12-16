using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Apoclite
{
	public class ApocliteScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apoclite Scythe");
			Tooltip.SetDefault("'From the shadows I come'\nThis is unobtainable. Stop cheating, you dirty cheater");
			Item.staff[item.type] = true; 
		}
		public override void SetDefaults()
		{
			item.damage = 64;
			item.melee = true;
			item.width = 30;
			item.height = 52;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ApocliteScytheProj");
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ApocliteCrystal", 16);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}