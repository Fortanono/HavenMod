using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace HavenMod
{
    public class DungueonInvasion : ModWorld
    {
		//List of PreHardmodeInvaders
		public static int[] PreHardmodeInvaders = {

            ModLoader.GetMod("HavenMod").NPCType("CowboyGunner"),
            ModLoader.GetMod("HavenMod").NPCType("CowboyHunter"),
            ModLoader.GetMod("HavenMod").NPCType("CowboySnakeTrainer"),
            ModLoader.GetMod("HavenMod").NPCType("CoveredWagon"),
            ModLoader.GetMod("HavenMod").NPCType("CowboyPioneer")
        };
		
		//List of HardmodeInvaders
		public static int[] HardmodeInvaders = {

            ModLoader.GetMod("HavenMod").NPCType("CowboyGunner"),
            ModLoader.GetMod("HavenMod").NPCType("CowboyHunter"),
            ModLoader.GetMod("HavenMod").NPCType("CowboySnakeTrainer"),
            ModLoader.GetMod("HavenMod").NPCType("CoveredWagon"),
            ModLoader.GetMod("HavenMod").NPCType("CowboyPioneer")
        };
		
		//Easy way to get full list
		public static int[] GetFullInvaderList()
		{
			//Creating a list
			int[] list = new int[PreHardmodeInvaders.Length + HardmodeInvaders.Length];
			
			//CopyTo(var arrayToCopyTo, index)
			PreHardmodeInvaders.CopyTo(list, 0);
			HardmodeInvaders.CopyTo(list, PreHardmodeInvaders.Length);
			
			return list;
		}
		
		//Setup for an Invasion After setting up
		public static void StartDungueonInvasion()
		{
			//Set to no invasion
			if (Main.invasionType != 0 && Main.invasionSize == 0)
			{
				Main.invasionType = 0;
			}
			if (Main.invasionType == 0)
			{
				//Checks amount of players
				int num = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
					{
						num++;
					}
				}
				if (num > 0)
				{
					//Invasion setup
					Main.invasionType = -1;
					MWorld.dungueonInvasionUp = true;
					Main.invasionSize = 100 * num;
					Main.invasionSizeStart = Main.invasionSize;
					Main.invasionProgress = 0;
					Main.invasionProgressIcon = 0 + 3;
					Main.invasionProgressWave = 0;
					Main.invasionProgressMax = Main.invasionSizeStart;
					Main.invasionWarn = 360;
					if (Main.rand.Next(2) == 0)
					{
						Main.invasionX = 0.0;
						return;
					}
					Main.invasionX = (double)Main.maxTilesX;
				}
			}
		}

		//Text for Dungeons and syncing messages
		public static void dungueoninvasionWarning()
		{
			String text = "";
			if (Main.invasionX == (double)Main.spawnTileX)
			{
				text = "A band of cowboys have arrived!";
			}
			if(Main.invasionSize <= 0)
			{
				text = "The cowboys have been defeated.";
			}
			if (Main.netMode == 0)
			{
				Main.NewText(text, 178, 128, 28, false);
				return;
			}
			if (Main.netMode == 2)
			{
				//Sync with net
				NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral(text), 255, 175f, 75f, 255f, 0, 0, 0);
			}
		}
		
		public static void UpdateDungueonInvasion()
		{
			if(MWorld.dungueonInvasionUp)
			{
				//End invasion if size less or equal to 0
				if(Main.invasionSize <= 0)
				{
					MWorld.dungueonInvasionUp = false;
					dungueoninvasionWarning();
					Main.invasionType = 0;
					Main.invasionDelay = 0;
				}
				
				//Do not do the rest if invasion already at spawn
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					return;
				}
				
				//Update when the invasion gets to Spawn
				float num = (float)Main.dayRate;
				if (Main.invasionX > (double)Main.spawnTileX)
				{
					Main.invasionX -= (double)num;
					if (Main.invasionX <= (double)Main.spawnTileX)
					{
						Main.invasionX = (double)Main.spawnTileX;
						dungueoninvasionWarning();
					}
					else
					{
						Main.invasionWarn--;
					}
				}
				else
				{
					if (Main.invasionX < (double)Main.spawnTileX)
					{
						Main.invasionX += (double)num;
						if (Main.invasionX >= (double)Main.spawnTileX)
						{
							Main.invasionX = (double)Main.spawnTileX;
							dungueoninvasionWarning();
						}
						else
						{
							Main.invasionWarn--;
						}
					}
				}
			}
		}
		
		public static void CheckDungueonInvasionProgress()
		{
			//Get full list of invaders
			int[] FullList = GetFullInvaderList();
			
			//Not really sure what this is
			if (Main.invasionProgressMode != 2)
			{
				Main.invasionProgressNearInvasion = false;
				return;
			}
			bool flag = false;
			Player player = Main.player[Main.myPlayer];
			Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			int num = 5000;
			int icon = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					icon = 0;
					int type = Main.npc[i].type;
					for(int n = 0; n < FullList.Length; n++)
					{
						if(type == FullList[n])
						{
							Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
							if (rectangle.Intersects(value))
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			Main.invasionProgressNearInvasion = flag;
			int progressMax3 = 1;
			if (MWorld.dungueonInvasionUp)
			{
				progressMax3 = Main.invasionSizeStart;
			}
			if(MWorld.dungueonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				//Shows the UI for the invasion
				Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, icon, 0);
			}
			
			//Syncing start of invasion
			foreach(Player p in Main.player)
			{
				NetMessage.SendData(78, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, (float)Main.invasionSizeStart, (float)(Main.invasionType), 0f, 0, 0, 0);
			}
		}
    }
}
