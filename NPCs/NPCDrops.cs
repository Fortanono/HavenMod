using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

 
namespace HavenMod.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.KingSlime && Main.hardMode == false) // for a modded npc add this instead - if (npc.type == mod.NPCType("ModdedNpcName"))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrozenSlimeCore"), 1);
            }

            if (npc.type == mod.NPCType("CoveredWagon"))
            {
                Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("CowboyPioneer"));
                NPC.NewNPC((int)spawnAt.X - 16, (int)spawnAt.Y - 16, mod.NPCType("CowboyPioneer"));
                NPC.NewNPC((int)spawnAt.X + 16, (int)spawnAt.Y - 32, mod.NPCType("CowboyPioneer"));
                NPC.NewNPC((int)spawnAt.X - 32, (int)spawnAt.Y - 16, mod.NPCType("CowboyPioneer"));
                NPC.NewNPC((int)spawnAt.X + 32, (int)spawnAt.Y - 32, mod.NPCType("CowboyPioneer"));
            }
        }
    }
}   