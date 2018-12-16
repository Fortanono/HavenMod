using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Galaxium
{
    public class GalaxiumBar : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxium Bar");
			Tooltip.SetDefault("'Pulses with cosmic energy'");
		}
		
		public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.rare = 7;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.consumable = false;
        }
    }
}
