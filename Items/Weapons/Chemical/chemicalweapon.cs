using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Chemical
{
	public abstract class chemicalweapon : ModItem
	{
		public virtual void SafeSetDefaults()
		{
		}
		public override void SetDefaults()
		{
			SafeSetDefaults();
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
		}
		public override void GetWeaponDamage(Player player, ref int damage)
		{
			damage = (int)(damage * havenmodplayer.ModPlayer(player).chemicalDamage + 5E-06f);
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			knockback = knockback + havenmodplayer.ModPlayer(player).chemicalKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit = crit + havenmodplayer.ModPlayer(player).chemicalCrit;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " chemical " + damageWord;
			}
		}
	}
}