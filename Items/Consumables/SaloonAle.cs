using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Consumables
{
    public class SaloonAle : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Saloon Ale");
            Tooltip.SetDefault("Increases melee abilities\nLowers defense\n6 minute duration");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 3;
            item.consumable = true;

        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Tipsy, 21600);
            player.AddBuff(BuffID.Rage, 21600);
            return true;
        }
    }
}