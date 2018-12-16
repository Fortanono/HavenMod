using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Magmite
{
	public class MagmiteScepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmite Scepter");
			Tooltip.SetDefault("");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.magic = true;
			item.mana = 18;
			item.width = 58;
			item.height = 58;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8;
			item.value = 0;
			item.rare = 6;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 296;
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmiteBar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}