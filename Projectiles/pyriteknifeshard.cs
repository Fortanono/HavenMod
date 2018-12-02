using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
	public class pyriteknifeshard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("pyriteknifeshard");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.CrystalShard);
			aiType = ProjectileID.CrystalShard;
		}
		public override void AI()
		{
		int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 269, 0f, 0f, 200, default(Color), .8f);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(72, 20);
		}

	}
}
