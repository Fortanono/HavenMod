using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class saltreactantproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.width = 32;
            projectile.height = 40;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Saltwater Tide Wave");
		}
    }
}