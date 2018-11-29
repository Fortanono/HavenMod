using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using HavenMod;

namespace ExampleMod.NPCs
{
	[AutoloadHead]
	public class Sheriff : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "HavenMod/NPCs/Sheriff";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Sheriff";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            if (MWorld.downedDungueonInvasion = true)
            {
               return true;
            }
			return false;
		}

		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
            return true;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Colin";
				case 1:
					return "Earl";
				case 2:
					return "Wyatt";
				default:
					return "Rick";
			}
		}

		public override string GetChat()
		{
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				return "I think " + Main.npc[partyGirl].GivenName + " is hiding something from me.";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "Do you want to get locked up?";
				case 1:
					return "I got everything you need.";
				default:
					return "It's high noon somewhere, right?";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("leadstoneBullet"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("SaloonAle"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("lumberpile"));
			nextSlot++;
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), 873);
            Item.NewItem(npc.getRect(), 874);
            Item.NewItem(npc.getRect(), 875);
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
		{
			scale = 0.85f;
			item = 2269;
			closeness = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.Bullet; //projectile type
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}