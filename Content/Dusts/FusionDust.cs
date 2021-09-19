using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace GenericClass.Content.Dusts
{
    public class FusionDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.alpha = 127;
            dust.color = Main.rand.NextFromList(GenericClass.LightFusionColors);
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.velocity *= 0.97f;
            dust.scale -= 0.05f;

            float light = dust.scale / 2.5f;
            Lighting.AddLight(dust.position, light * dust.color.R / 255, light * dust.color.G / 255, light * dust.color.B / 255);

            if (dust.scale < 0.5f)
                dust.active = false;

            return false;
        }
    }
}