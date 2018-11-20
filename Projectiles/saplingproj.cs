using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class saplingproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.width = 14;
            projectile.height = 24;
            projectile.timeLeft = 600;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapling Leaf");
		}
    }
}