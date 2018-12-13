using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Localization;

namespace HavenMod.NPCs.Enemies.Bosses.dripplerboss
{
    public class dripplerboss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Globler");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Drippler];
        }

        public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;
			npc.damage = 45;
			npc.defense = 15;
			npc.lifeMax = 450;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.scale = 2;
			npc.knockBackResist = 0f;
			npc.boss = true;
			npc.noGravity = true;
			npc.npcSlots = 5f;
			npc.aiStyle = 5;
			animationType = NPCID.Drippler;
		}
		
public override void AI()
        {
if (npc.life >= npc.lifeMax / 2)
            {
				npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;
				npc.ai[0]++; 
			 npc.ai[1]++;
				if (npc.ai[0] >= 50)
            {
                float Speed = 12f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 20;
                int type = mod.ProjectileType("bloodball");
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 17);
                float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
				 
                npc.ai[0] = 0;
            }
            } else {
				npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;
				npc.ai[0]++; 
			 npc.ai[1]++;
				if (npc.ai[0] >= 10)
            {
                float Speed = 12f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 40;
                int type = mod.ProjectileType("bloodball");
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 17);
                float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
				 
                npc.ai[0] = 0;
            }}
            
			
        }
    }
}
