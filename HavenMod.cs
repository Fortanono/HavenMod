using Terraria;
using Terraria.ModLoader;

namespace HavenMod
{
	class HavenMod : Mod
	{
	public HavenMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        //Setting music for Invasion
        public override void UpdateMusic(ref int music)
        {
            if (MWorld.dungueonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/NeoWestern");
            }
        }
	}
}
