using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Melee
{
    public class hestiashearth : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 21;
            item.melee = true;
            item.width = 28;
            item.height = 28;
            item.useTime = 14;
            item.shootSpeed = 12f;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 3f;
            item.shoot = mod.ProjectileType("hestiashearth");
            item.value = Item.buyPrice(0, 7, 0, 0);
            item.rare = 5;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hestia's Hearth");
            Tooltip.SetDefault("Shoots a powerful hearth disc\nTwo hearth discs can be active at once\nUnleashes powerful greek fire and splashes ichor on enemies");
        }

        public override bool CanUseItem(Player player)
		{
		    const int WheelMax = 1;
		    int Count = 0;
		    foreach (Projectile projectile in Main.projectile)
		    if (projectile.type == item.shoot && projectile.owner == item.owner && projectile.active)
			{	
		        Count++;
			}
		    return (Count > WheelMax) ? false : true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "olympiumbar", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("greekfire"), 120);
            target.AddBuff(BuffID.Ichor, 300);
		}
    }
}