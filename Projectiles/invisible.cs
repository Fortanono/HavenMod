using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace HavenMod.Projectiles
{
	public class invisible : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 0;
			projectile.height = 0;
			projectile.friendly = true;
			projectile.aiStyle = 0;
			projectile.timeLeft = 0;
			projectile.penetrate = 0;
			projectile.tileCollide = false; 
			projectile.ignoreWater = true; 
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

	}
}