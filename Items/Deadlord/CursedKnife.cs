using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Deadlord
{
	public class CursedKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Knife");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 11;
			item.magic = true;
			item.noUseGraphic = true;
			item.width = 14;
			item.height = 34;
			item.useTime = 4;
			item.useAnimation = 4;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 0;
			item.mana = 7;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.maxStack = 1;
			item.shoot = mod.ProjectileType("CursedKnifeProj");
			item.shootSpeed = 18f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DeadlordEmblem", 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
