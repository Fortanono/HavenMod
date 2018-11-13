using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Melee
{
	public class areswarpike : ModItem
	{
	    public override void SetDefaults()
		{
			item.damage = 29;
			item.useStyle = 5;
			item.useAnimation = 23;
			item.useTime = 23;
			item.shootSpeed = 3.3f;
			item.knockBack = 10f;
			item.width = 36;
			item.height = 36;
			item.scale = 1f;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("areswarpike");
			item.value = Item.buyPrice(0, 7, 0, 0);
			item.noMelee = true; 
			item.noUseGraphic = true;
			item.melee = true;
			item.autoReuse = false;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ares War Pike");
            Tooltip.SetDefault("Unleashes powerful greek fire and splashes ichor on enemies");
		}

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "olympiumbar", 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}