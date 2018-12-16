using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs.Enemies.Bosses.Kingsbane
{
    public class CursedBlade : ModNPC
    {
        public override void SetDefaults()
        {
            npc.aiStyle = 23;  //5 is the flying AI
            npc.lifeMax = 50;   //boss life
            npc.damage = 10;  //boss damage
            npc.defense = 0;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 44;
            npc.height = 44;
            Main.npcFrameCount[npc.type] = 1;    //boss frame/animation 
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit33;
            npc.buffImmune[24] = true;
            npc.netAlways = true;
        }
    }
}