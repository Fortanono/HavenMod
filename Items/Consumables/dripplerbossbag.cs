using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace HavenMod.Items.Consumables
{
    public class dripplerbossbag : ModItem
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
			bossBagNPC = mod.NPCType("dripplerboss");
		}

        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ItemID.GoldCoin, 6);
			player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(4,12));
            switch (Main.rand.Next(4))
                {
                    case 0:
                        player.QuickSpawnItem(mod.ItemType("bloodywarjavelin"));
                        break;
                    case 1:
                        player.QuickSpawnItem(mod.ItemType("bloodblazer"));
                        break;
                    case 2:
                        player.QuickSpawnItem(mod.ItemType("forbiddenorb"));
                        break;
					case 3:
                        player.QuickSpawnItem(mod.ItemType("scarletstringbow"));
                        break;
                }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.MoneyTrough);
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.SharkToothNecklace);
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.Sextant);
            }				
        }
    }
}