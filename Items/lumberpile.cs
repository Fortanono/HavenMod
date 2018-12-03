using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items
{
	public class lumberpile : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lumber Pile");
			Tooltip.SetDefault("Right Click to open");
		}

		public override void SetDefaults()
		{
			item.maxStack = 99;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 3;
			bossBagNPC = mod.NPCType("Sheriff");
			item.value = Item.buyPrice(0, 0, 25, 0);
		}
		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{                                         //below it's a choice that items that will drop randomly

			if (Main.hardMode == false)
			{
				int choice = Main.rand.Next(6);
				if (choice == 0)
				{
					player.QuickSpawnItem(ItemID.Wood, 50);
				}
				if (choice == 1)
				{
					player.QuickSpawnItem(ItemID.Ebonwood, 50);
				}

				if (choice == 2)
				{
					player.QuickSpawnItem(ItemID.Shadewood, 50);
				}

				if (choice == 3)
				{
					player.QuickSpawnItem(ItemID.DynastyWood, 50);
				}

				if (choice == 4)
				{
					player.QuickSpawnItem(ItemID.BorealWood, 50);
				}

				if (choice == 5)
				{
					player.QuickSpawnItem(ItemID.PalmWood, 50);
				}
			}


			if (Main.hardMode == true)
			{
				int choice2 = Main.rand.Next(8);

				if (choice2 == 0)
				{
					player.QuickSpawnItem(ItemID.Pearlwood, 50);
				}

				if (choice2 == 1)
                {
                    player.QuickSpawnItem(ItemID.SpookyWood, 50);
                }

				if (choice2 == 2)
				{
					player.QuickSpawnItem(ItemID.Wood, 50);
				}
				if (choice2 == 3)
				{
					player.QuickSpawnItem(ItemID.Ebonwood, 50);
				}

				if (choice2 == 4)
				{
					player.QuickSpawnItem(ItemID.Shadewood, 50);
				}

				if (choice2 == 5)
				{
					player.QuickSpawnItem(ItemID.DynastyWood, 50);
				}

				if (choice2 == 6)
				{
					player.QuickSpawnItem(ItemID.BorealWood, 50);
				}

				if (choice2 == 7)
				{
					player.QuickSpawnItem(ItemID.PalmWood, 50);
				}
			}
		}
	}
}
