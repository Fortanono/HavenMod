using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Chemical
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
	public class chemicalplayer : ModPlayer
	{
		public static chemicalplayer ModPlayer(Player player)
		{
			return player.GetModPlayer<chemicalplayer>();
		}

		public float chemicalDamage = 1f;
		public float chemicalKnockback = 0f;
		public int chemicalCrit = 0;

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			chemicalDamage = 1f;
			chemicalKnockback = 0f;
			chemicalCrit = 0;
		}
	}
}