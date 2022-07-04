using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace GenericClass.Content.Projectiles
{
	public class FusionHeart : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.tileCollide = false;
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.scale = 2f;
        }

        public override bool PreAI() => true;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Projectile.velocity = (player.position - Projectile.position) * 0.05f;

            if (++Projectile.frameCounter >= 10)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = ++Projectile.frame % Main.projFrames[Type];
            }

            if (Projectile.Colliding(Projectile.getRect(), player.getRect()))
                Projectile.Kill();
        }

        public override bool PreKill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
                Main.player[Projectile.owner].HealEffect(1);
            return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Type);

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Color color = Projectile.GetAlpha(GenericClass.LightFusionColors[Projectile.frame]);
            Vector2 origin = new(texture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 position = Projectile.position - Main.screenPosition + origin + new Vector2(0f, Projectile.gfxOffY);
            Rectangle frame = new(0, texture.Height / 4 * Projectile.frame, texture.Width - 2, texture.Height / 4 - 2);

            Main.EntitySpriteDraw(texture, position, frame, color, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
            Lighting.AddLight(Projectile.position, color.R / 255, color.G / 255, color.B / 255);

            return false;
        }
    }
}
