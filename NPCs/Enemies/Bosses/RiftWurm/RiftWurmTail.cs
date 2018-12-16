using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs.Enemies.Bosses.RiftWurm
{    
    public class RiftWurmTail : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rift Wurm");
		}
        public override void SetDefaults()
        {
            npc.width = 65;     //this is where you put the npc sprite width.     important
            npc.height = 40;      //this is where you put the npc sprite height.   important
            npc.damage = 30;
            npc.defense = 0;
            npc.lifeMax = 80000;
            npc.knockBackResist = 0.0f;
            npc.behindTiles = true;
            npc.noTileCollide = true;
            npc.netAlways = true;
            npc.noGravity = true;
            npc.dontCountMe = true;
            npc.HitSound = SoundID.NPCHit4;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 50;
            npc.defense = 1000;
            npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale); //double health in expert mode and stacked with amount of players.
        }

        public override void AI()
        {
			if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
                npc.timeLeft = 300;
 
            if (Main.netMode != 1)
            {
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                }
            }
			
			if (Main.player[npc.target].dead)
			{
				npc.timeLeft = 0;
				Dust dust;
				Vector2 position = Main.LocalPlayer.Center;
				dust = Terraria.Dust.NewDustDirect(npc.position, 30, 30, 174, 0f, 0f, 0, new Color(255,255,255), 1f);
				dust.noGravity = true;
				dust.fadeIn = 3f;
			}
			
            if (npc.ai[1] < (double)Main.npc.Length)
            {
                // We're getting the center of this NPC.
                Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                // Then using that center, we calculate the direction towards the 'parent NPC' of this NPC.
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                // We then use Atan2 to get a correct rotation towards that parent NPC.
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                // We also get the length of the direction vector.
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                // We calculate a new, correct distance.
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;

                // Reset the velocity of this NPC, because we don't want it to move on its own
                npc.velocity = Vector2.Zero;
                // And set this NPCs position accordingly to that of this NPCs parent NPC.
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
        }
		
		public override bool CheckActive()
		{
			return false;
		}

        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, new Rectangle?(), drawColor, npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
            return false;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

			}
		}	
		
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {

            return false;      //this make that the npc does not have a health bar
        }
    }
}
