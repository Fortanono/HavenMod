using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class forbiddenburst : ModProjectile
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
			DisplayName.SetDefault("Forbidden Ichor");
		}

        public override void AI()
		{
		int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 228);
		}

        public virtual void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(BuffID.Ichor, 240);
		}
    }
}