using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories.Reactants
{
    public class saltcrystal : ModItem
    {
        public override void SetDefaults()
        {
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 12, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Salt Crystal");
            Tooltip.SetDefault("[c/ADFF2F:~ ~ ~ Chemist Class ~ ~ ~]\nWater guns will fire a wave of saltwater with this equipped");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<havenmodplayer>(mod).SaltEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).WaterReactantEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).TotalWaterReactants += 1;
        }
    }
}