using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class electronicdefaultproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.width = 14;
            projectile.height = 24;
            projectile.timeLeft = 20;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electric Flash");
		}

        public override void AI()
		{
		int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226);
		}
    }
}