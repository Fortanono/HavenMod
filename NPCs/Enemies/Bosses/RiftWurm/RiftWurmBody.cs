using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs.Enemies.Bosses.RiftWurm
{    
    public class RiftWurmBody : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rift Wurm");
		}
		
		private Player player;
        private float speed;
		
        public override void SetDefaults()
        {
            npc.width = 65;               //this is where you put the npc sprite width.     important
            npc.height = 40;              //this is where you put the npc sprite height.   important
            npc.damage = 40;
            npc.defense = 20;
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
            npc.damage = 60;
            npc.defense = 35;
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
			
			/*if (Main.rand.NextFloat() < 0.4f)
			{
				Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Terraria.Dust.NewDust(npc.position, 30, 30, 174, 0f, 0f, 0, new Color(255,255,255), 1.45f)];
				dust.noGravity = true;
			}*/

			
			if(Main.rand.Next(699) == 69) //Every tick has a 1/700 chance to spawn a projectile
			{
				Player player = Main.player[npc.target];

				Main.PlaySound(SoundID.Item46, npc.position); 
				
				float projectileSpeed = 1; 
				int damage = 30; 
				float knockBack = 3;
				int type = mod.ProjectileType("RiftBlast"); 

				Vector2 velocity = Vector2.Normalize(new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2) - 
				new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2)) * projectileSpeed; // We get a correct velocity towards the player.
				Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);
			}

            if(npc.life <= npc.lifeMax * 0.2)
            {
                if (Main.rand.Next(399) == 69) //Every tick has a 1/400 chance to spawn a projectile under 20% HP
                {
                    Player player = Main.player[npc.target];

                    Main.PlaySound(SoundID.Item46, npc.position);

                    float projectileSpeed = 20;
                    int damage = 50;
                    float knockBack = 3;
                    int type = 438;

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2) -
                    new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2)) * projectileSpeed; // We get a correct velocity towards the player.
                    Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);
                }
            }
			
		
			//Pretty certain it goes into decimals, not whole numbers so something like this
			float r = 252/255;
			float b = 120/255;
			float g = 32/255;

			//Center of the npc
			//You can just set the positions to npc.Center.X and npc.Center.Y
		  
			//Making a Vector2 object with the parameters of positionX and positionY
			Vector2 npcPos = new Vector2(npc.Center.X, npc.Center.Y);
			//You can also just do:
			//Vector2 npcPos = new Vector2(npc.Center.X, npc.Center.Y)
			//Vector2 npcPos = npc.Center;
			//These will harbor the same values
		  
			//Making a Vector3 object with the parameters of r, g, and b
			//Vector3 lightColor = new Vector2(r, g, b);
		  
			//Using all three different AddLight methods, which basically all does the same thing
			//Lighting.AddLight(npcPos, lightColor);
			Lighting.AddLight(npcPos, r, g, b);
			//Lighting.AddLight(npc.Center.X, npc.Center.Y, r, g, b);
			
			
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
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Terraria.Dust.NewDust(npc.position, 30, 30, 272, 0f, 0f, 0, new Color(255,255,255), 1f)];
				dust.fadeIn = 1.5f;
			}

		}	
		
		private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
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
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {

            return false;       //this make that the npc does not have a health bar
        }
    }
}
