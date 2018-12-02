using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Magic
{
	public class pyritestaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pyrite Burst Staff");
			Tooltip.SetDefault("Shiny!\nInflicts midas on enemys, making them drop more gold.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.magic = true;
			item.mana = 40;
			item.width = 40;
			item.height = 40;
			item.scale = 1.5f;
			item.useTime = 3;
			item.useAnimation = 80;
			item.reuseDelay = 45;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = .5f;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("pyriteburst");
			item.shootSpeed = 16f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
        }

		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "pyrite", 45);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}