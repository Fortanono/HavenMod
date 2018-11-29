using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HavenMod
{
    public class MNPC : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (MWorld.dungueonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                //Clear pool so that only the stuff you want spawns
                pool.Clear();
                if (NPC.downedPlantBoss)
                {
                    //key = NPC ID | value = spawn weight
                    //pool.add(key, value)
                    if (Main.rand.Next(5) > 0)
                    {
                        foreach (int i in DungueonInvasion.HardmodeInvaders)
                        {
                            pool.Add(i, 1f);
                        }
                    }
                    else
                    {
                        foreach (int i in DungueonInvasion.PreHardmodeInvaders)
                        {
                            pool.Add(i, 1f);
                        }
                    }
                }
                else
                {
                    foreach (int i in DungueonInvasion.PreHardmodeInvaders)
                    {
                        pool.Add(i, 1f);
                    }
                }
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            //Change spawn stuff if invasion up and invasion at spawn
            if (MWorld.dungueonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                spawnRate = 100;
                maxSpawns = 100;
            }
        }

        public override void PostAI(NPC npc)
        {
            //Changes NPCs so they do not despawn when invasion up and invasion at spawn
            if (MWorld.dungueonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                npc.timeLeft = 1000;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            //When an NPC (from the invasion list) dies, add progress by decreasing size
            if (MWorld.dungueonInvasionUp)
            {
                int[] FullList = DungueonInvasion.GetFullInvaderList();
                foreach (int invader in FullList)
                {
                    if (npc.type == invader)
                    {
                        Main.invasionSize -= 1;
                    }
                }
            }
        }
    }
}