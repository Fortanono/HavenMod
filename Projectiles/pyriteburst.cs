using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
	public class pyriteburst : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pyrite Burst");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			aiType = ProjectileID.Bullet;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Bullet;
			return true;
		}
public override void AI()
		{
		int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 269, 0f, 0f, 200, default(Color), 1f);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(72, 180);
		}
	}
}