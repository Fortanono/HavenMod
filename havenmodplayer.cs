using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items
{
	public class havenmodplayer : ModPlayer
	{
		public static havenmodplayer ModPlayer(Player player)
		{
			return player.GetModPlayer<havenmodplayer>();
		}

		public bool WaterReactantEquipped = false;
		public bool SaplingEquipped = false;
		public bool PotassiumEquipped = false;
		public bool SaltEquipped = false;
		public bool SodiumEquipped = false;
		public bool StrangePottedPlantEquipped = false;
		public bool MoltenCryogelEquipped = false;
		public bool JungleBlossomEquipped = false;
		public bool RustedDemonPlateEquipped = false;
		public bool CrimtaneBacteriumEquipped = false;
		public bool HellstonePowderEquipped = false;
		public bool RefinedPotassiumEquipped = false;
		public bool RefinedSodiumEquipped = false;
		public bool RefinedSaltEquipped = false;
		public bool PyriteEquipped = false;
		public bool IchorSacEquipped = false;
		public bool CursedPyreEquipped = false;
		public bool PixieFlaskEquipped = false;
		public bool StrangeSouffletEquipped = false;
		public bool SpiritPhialEquipped = false; 
		public bool ReactiveConfettiEquipped = false;
		public bool RetinasTearEquipped = false;
		public bool ChlorophyteMossEquipped = false;
		public bool FairyCocktaleEquipped = false;
		public bool AmontilladoEquipped = false;
		public bool LithiumEquipped = false;
		public bool RubidiumEquipped = false;
		public bool CaesiumEquipped = false;
		public bool BerylliumEquipped = false;
		public bool CalciumEquipped = false;
		public bool MagnesiumEquipped = false;
		public bool StrontiumEquipped = false;
		public bool BariumEquipped = false;
		public bool RadiumEquipped = false;
		public bool SolarLinkEquipped = false;
		public bool SaltwaterRelicEquipped = false;
		public bool PottedTannenbaumEquipped = false;
		public bool FranciumEquipped = false;
		public int TotalWaterReactants = 0;

		public bool ElectricReactantEquipped = false;
		public bool KryptonGasEquipped = false;
		public bool NeonGasEquipped = false;
		public int TotalElectricReactants = 0;

		public float chemicalDamage = 1f;
		public float chemicalKnockback = 0f;
		public int chemicalCrit = 0;

		public override void ResetEffects()
		{
			ResetVariables();
			WaterReactantEquipped = false;
		    SaplingEquipped = false;
		    PotassiumEquipped = false;
		    SaltEquipped = false;
		    SodiumEquipped = false;
		    StrangePottedPlantEquipped = false;
		    MoltenCryogelEquipped = false;
		    JungleBlossomEquipped = false;
		    RustedDemonPlateEquipped = false;
		    CrimtaneBacteriumEquipped = false;
		    HellstonePowderEquipped = false;
		    RefinedPotassiumEquipped = false;
		    RefinedSodiumEquipped = false;
		    RefinedSaltEquipped = false;
		    PyriteEquipped = false;
		    IchorSacEquipped = false;
		    CursedPyreEquipped = false;
		    PixieFlaskEquipped = false;
		    StrangeSouffletEquipped = false;
		    SpiritPhialEquipped = false; 
		    ReactiveConfettiEquipped = false;
		    RetinasTearEquipped = false;
		    ChlorophyteMossEquipped = false;
		    FairyCocktaleEquipped = false;
		    AmontilladoEquipped = false;
		    LithiumEquipped = false;
		    RubidiumEquipped = false;
		    CaesiumEquipped = false;
		    BerylliumEquipped = false;
		    CalciumEquipped = false;
		    MagnesiumEquipped = false;
		    StrontiumEquipped = false;
		    BariumEquipped = false;
		    RadiumEquipped = false;
		    SolarLinkEquipped = false;
		    SaltwaterRelicEquipped = false;
		    PottedTannenbaumEquipped = false;
		    FranciumEquipped = false;
			TotalWaterReactants = 0;
			ElectricReactantEquipped = false;
		    KryptonGasEquipped = false;
		    NeonGasEquipped = false;
		    TotalElectricReactants = 0;
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			chemicalDamage = 1f;
			chemicalKnockback = 0f;
			chemicalCrit = 0;
		}
	}
}