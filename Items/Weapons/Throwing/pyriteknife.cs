using HavenMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Throwing
{
	public class pyriteknife : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pyrite Throwing Knife");
            Tooltip.SetDefault("'Looks like gold, but is it?'");
        }
		public override void SetDefaults()
		{
			item.shootSpeed = 15f;
			item.damage = 37;
			item.knockBack = 2f;
			item.useStyle = 1;
			item.useAnimation = 12;
			item.useTime = 12;
			item.width = 14;
			item.height = 40;
			item.maxStack = 999;
			item.rare = 5;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 2);
			item.shoot = mod.ProjectileType("pyriteknife");
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "pyrite", 1);
            recipe.SetResult(this, 15);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
}
}