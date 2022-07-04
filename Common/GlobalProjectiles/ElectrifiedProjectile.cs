using GenericClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Common.GlobalItems
{
    public class ElectrifiedProjectile : GlobalProjectile
    {
        public override void PostAI(Projectile projectile)
        {
            if (projectile.friendly
                && Main.player[projectile.owner].GetModPlayer<MartianCommanderArmorPlayer>().SetBonus
                && projectile.damage > 0)
            {
                int dust = Dust.NewDust(
                    new Vector2(projectile.position.X, projectile.position.Y),
                    projectile.width, projectile.height,
                    DustID.Electric,
                    projectile.velocity.X * 0.2f + (float)(projectile.direction * 3),
                    projectile.velocity.Y * 0.2f,
                    100, default, 1f
                );
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
