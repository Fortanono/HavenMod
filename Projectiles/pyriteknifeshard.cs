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

	}
}
