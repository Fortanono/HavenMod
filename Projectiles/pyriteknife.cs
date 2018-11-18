using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
	public class pyriteknife : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("pyriteknife");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			aiType = ProjectileID.ThrowingKnife;
		}
public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 5; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 7f, Main.rand.Next(-20, 24) * .5f, Main.rand.Next(-15, -6) * .5f, mod.ProjectileType("pyriteknifeshard"), (int)(projectile.damage * .3f), 0, projectile.owner);
				
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}
		
		
	}
}
