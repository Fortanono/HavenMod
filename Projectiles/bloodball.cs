using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
	public class bloodball : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Ball");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EyeBeam);
			aiType = ProjectileID.EyeBeam;
			projectile.friendly = false;
		}
		public override void AI()
		{
		int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, 0f, 0f, 200, default(Color), 3f);
		}

	}
}
