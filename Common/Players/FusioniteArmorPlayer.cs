using GenericClass.Content.Dusts;
using GenericClass.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Common.Players
{
    public class FusioniteArmorPlayer : ModPlayer
    {
        public bool SetBonus { get; set; }
        public bool Breastplate { get; set; }

        public override void ResetEffects()
        {
            SetBonus = false;
            Breastplate = false;
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        => FusionExplosion(target, 0);

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        => FusionExplosion(target, hitDirection);

        public override void NaturalLifeRegen(ref float regen)
        {
            if (Breastplate)
                regen += 4;
        }

        public void FusionExplosion(NPC target, int hitDirection)
        {
            if (SetBonus && Main.rand.NextBool(3) && !target.friendly)
            {
                for (int i = 0; i < 50; i++)
                {
                    Dust dust = Dust.NewDustPerfect
                    (
                        target.position,
                        ModContent.DustType<FusionDust>(),
                        Main.rand.NextVector2Circular(5, 5),
                        Scale: Main.rand.NextFloat(2, 2.5f)
                    );
                    dust.noGravity = true;
                }
                SoundEngine.PlaySound(SoundID.Item, target.position, 14);
                target.StrikeNPC(150, 10, hitDirection);

                Projectile.NewProjectile(null, target.position, Vector2.Zero, ModContent.ProjectileType<FusionHeart>(), 0, 0, Main.myPlayer);
            }
        }
    }
}