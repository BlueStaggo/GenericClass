using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace GenericClass
{
	internal static class ModItemExtension
	{
		public static void SetRequiredSacrifices(this ModItem item, int _)
		=> CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[item.Type] = 1;
	}
}
