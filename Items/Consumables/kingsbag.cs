using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Consumables
{
	public class kingsbag: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Kingsbane");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			 player.QuickSpawnItem(mod.ItemType("DeadlordEmblem"), Main.rand.Next(16,32));
		}
	}
}