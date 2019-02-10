using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class bloodblaze : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 2;
            projectile.scale = 1;
            projectile.timeLeft = 600;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Laser");
        }

        public virtual void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(105, 60);
        }
    }
}