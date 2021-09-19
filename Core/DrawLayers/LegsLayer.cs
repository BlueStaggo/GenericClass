using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

// Shamelessly Ctrl-C'd and Ctrl-V'd from Clicker Class
namespace GenericClass.Core.DrawLayers
{
    //Items manually register data which this layer is using
    public sealed class LegsLayer : PlayerDrawLayer
    {
        private static Dictionary<int, DrawLayerData> LegsLayerData { get; set; }

        /// <summary>
        /// Add data associated with the leg equip slot here, usually in <see cref="ModType.SetStaticDefaults"/>.
        /// <para>Don't forget the !Main.dedServ check!</para>
        /// </summary>
        /// <param name="legSlot">Leg equip slot</param>
        /// <param name="data">Data</param>
        public static void RegisterData(int legSlot, DrawLayerData data)
        {
            if (!LegsLayerData.ContainsKey(legSlot))
            {
                LegsLayerData.Add(legSlot, data);
            }
        }

        public override void Load()
        {
            LegsLayerData = new Dictionary<int, DrawLayerData>();
        }

        public override void Unload()
        {
            LegsLayerData = null;
        }

        public override Position GetDefaultPosition()
        {
            return new AfterParent(PlayerDrawLayers.Leggings);
        }

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            if (drawPlayer.dead || drawPlayer.invis || drawPlayer.legs == -1)
            {
                return false;
            }
            return true;
        }

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;

            if (!LegsLayerData.TryGetValue(drawPlayer.legs, out DrawLayerData data))
            {
                return;
            }

            Color color = drawPlayer.GetImmuneAlphaPure(data.Color, drawInfo.shadow);

            Texture2D texture = data.Texture.Value;
            Vector2 drawPos = drawInfo.Position - Main.screenPosition + new Vector2(drawPlayer.width / 2 - drawPlayer.legFrame.Width / 2, drawPlayer.height - drawPlayer.legFrame.Height + 4f) + drawPlayer.legPosition;
            Vector2 legsOffset = drawInfo.legsOffset;
            DrawData drawData = new DrawData(texture, drawPos.Floor() + legsOffset, drawPlayer.legFrame, color, drawPlayer.legRotation, legsOffset, 1f, drawInfo.playerEffect, 0)
            {
                shader = drawInfo.cLegs
            };
            drawInfo.DrawDataCache.Add(drawData);
        }
    }
}