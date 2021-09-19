using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Common.Players
{
    public class MartianCommanderArmorPlayer : ModPlayer
    {
        public bool SetBonus { get; set; }

        public override void ResetEffects()
        {
            SetBonus = false;
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (SetBonus)
                target.AddBuff(BuffID.Electrified, 180);
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (SetBonus)
                target.AddBuff(BuffID.Electrified, 180);
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (SetBonus)
            {
                int dust = Dust.NewDust(
                    new Vector2(hitbox.X, hitbox.Y),
                    hitbox.Width, hitbox.Height,
                    DustID.Electric,
                    item.velocity.X * 0.2f + (float)(Player.direction * 3),
                    item.velocity.Y * 0.2f,
                    100, default(Color), 1f
                );
                Main.dust[dust].noGravity = true;
            }
        }
    }
}