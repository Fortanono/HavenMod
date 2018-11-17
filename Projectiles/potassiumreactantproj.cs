using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class potassiumreactantproj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(15);
            aiType = 15;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(153, 180);
		}

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potassium Fireball");
		}
    }
    
}