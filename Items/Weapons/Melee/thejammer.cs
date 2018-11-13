using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Melee
{
	public class thejammer : ModItem
	{
	    public override void SetDefaults()
		{
			item.damage = 13;
			item.useStyle = 5;
			item.useAnimation = 27;
			item.useTime = 27;
			item.shootSpeed = 2.3f;
			item.knockBack = 5f;
			item.width = 31;
			item.height = 31;
			item.scale = 1f;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("thejammer");
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.noMelee = true; 
			item.noUseGraphic = true;
			item.melee = true;
			item.autoReuse = false;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Jammer");
		}

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "cryogelbar", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}