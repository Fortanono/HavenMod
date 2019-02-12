using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs
{
    public class NPCGlobal : GlobalNPC
    {
		public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(3) == 1)
            {
                if (npc.type == NPCID.Crab || npc.type == NPCID.Shark || npc.type == NPCID.Squid || npc.type == NPCID.SeaSnail)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Coralite"), 3 + Main.rand.Next(6));
                }

                if (npc.type == NPCID.FaceMonster)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlackBile"), 3 + Main.rand.Next(6));
                }
				
            }
if (Main.rand.Next(4) == 1)
            {
                if (npc.type == NPCID.PinkJellyfish)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Coralite"), 2 + Main.rand.Next(4));
                }
				
            }
            if (Main.rand.Next(2) == 1)
            {
                if (npc.type == NPCID.WyvernHead)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AstraliteCrystal"), 1);
                }

            }
        }
        public bool greekfire = false;
        public bool bloodywarjavelinbuff = false;

        public override void ResetEffects(NPC npc)
        {
            greekfire = false;
            bloodywarjavelinbuff = false;
        }

        public override void SetDefaults(NPC npc)
		{
			npc.buffImmune[mod.BuffType<Buffs.bloodywarjavelinbuff>()] = npc.buffImmune[BuffID.BoneJavelin];
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (bloodywarjavelinbuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				int bloodyJavelinCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					Projectile p = Main.projectile[i];
					if (p.active && p.type == mod.ProjectileType<Projectiles.warjavelin>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
					{
						bloodyJavelinCount++;
					}
				}
				npc.lifeRegen -= bloodyJavelinCount * 2 * 3;
				if (damage < bloodyJavelinCount * 3)
				{
					damage = bloodyJavelinCount * 3;
				}

                if (greekfire)
                {
                    npc.lifeRegen -= 35;
                    if (damage < 2);
                }
			}
		}

        public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
    }
}