using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
	public class leadedbullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("leadedbullet");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			aiType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(20, 180);
			target.AddBuff(31, 180);
		}

	}
}
