using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Common.GlobalNPCs
{
    public class ElectrifiedNPC : GlobalNPC
    {
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(BuffID.Electrified) && !npc.buffImmune[BuffID.Electrified])
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;

                int dust = Dust.NewDust(
                    new Vector2(npc.position.X, npc.position.Y),
                    npc.width, npc.height,
                    DustID.Electric,
                    npc.velocity.X * 0.2f + (float)(npc.direction * 3),
                    npc.velocity.Y * 0.2f,
                    100, default(Color), 1f
                );
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
