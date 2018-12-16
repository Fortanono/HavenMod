using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Astralite
{
    public class AstraliteCrystal : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astralite Crystal");
			Tooltip.SetDefault("'Pulses with mystical energy'");
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
			item.rare = 5;
			item.value = Item.buyPrice(0, 0, 70, 0);
			item.consumable = false;
        }
    }
}