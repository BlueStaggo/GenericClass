using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

// This isn't shamelessly Ctrl-C'd and Ctrl-V'd from Clicker Class; it's my own original code!
namespace GenericClass.Core.DrawLayers
{
    public sealed class ItemLayer : GlobalItem
    {
        private static Dictionary<int, ItemLayerData> ItemLayerData { get; set; }

        /// <summary>
        /// Add data associated with an item here, usually in <see cref="ModType.SetStaticDefaults"/>.
        /// <para>Don't forget the !Main.dedServ check!</para>
        /// </summary>
        /// <param name="item">Item ID</param>
        /// <param name="data">Data</param>
        public static void RegisterData(int item, ItemLayerData data)
        {
            if (!ItemLayerData.ContainsKey(item))
            {
                ItemLayerData.Add(item, data);
            }
        }

        public override void Load()
        {
            ItemLayerData = new Dictionary<int, ItemLayerData>();
        }

        public override void Unload()
        {
            ItemLayerData = null;
        }

        public override void PostDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            if (!ItemLayerData.TryGetValue(item.type, out ItemLayerData data))
            {
                return;
            }

            Color color = data.Color;

            Texture2D texture = data.Texture.Value;
            Vector2 drawPos = item.position - Main.screenPosition + new Vector2(item.width * 0.5f, item.height - texture.Height * 0.5f);
            spriteBatch.Draw(texture, drawPos, texture.Bounds, color, rotation, texture.Size() / 2, scale, SpriteEffects.None, 0f);
        }

        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (!ItemLayerData.TryGetValue(item.type, out ItemLayerData data))
            {
                return;
            }

            if (!data.InventoryDraw)
            {
                return;
            }

            Color color = data.Color;

            Texture2D texture = data.Texture.Value;
            spriteBatch.Draw(texture, position, frame, color, 0, origin, scale, SpriteEffects.None, 0f);
        }
    }
}