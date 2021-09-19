using Terraria;
using Terraria.ModLoader;

namespace GenericClass.Common.Players
{
    public class NightsArmorPlayer : ModPlayer
    {
        public bool SetBonus { get; set; }

        public override void ResetEffects()
        {
            SetBonus = false;
        }

        public override void NaturalLifeRegen(ref float regen)
        {
            if (SetBonus)
            {
                regen *= 1.5f;
                Player.lifeRegenTime += 1;
            }
        }
    }
}