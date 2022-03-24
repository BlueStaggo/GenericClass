using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Common.Players
{
    public class FlamingCuffsPlayer : ModPlayer
    {
        public bool Accessory { get; set; }

        public override void ResetEffects()
        {
            Accessory = false;
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (Accessory)
                target.AddBuff(BuffID.OnFire3, Main.rand.Next(120, 360));
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Accessory)
                target.AddBuff(BuffID.OnFire3, Main.rand.Next(120, 360));
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (Accessory)
            {
                int dust = Dust.NewDust(
                    new Vector2(hitbox.X, hitbox.Y),
                    hitbox.Width, hitbox.Height,
                    DustID.Torch,
                    item.velocity.X * 0.2f + (float)(Player.direction * 3),
                    item.velocity.Y * 0.2f,
                    100, default(Color), 2.5f
                );
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X *= 2f;
                Main.dust[dust].velocity.Y *= 2f;
            }
        }
    }
}