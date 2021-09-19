using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PalladiumHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(
				"Increases maximum mana by 40\n" +
				"8% increased melee speed\n" +
				"8% increased damage and critical strike chance"
			);
			this.SetRequiredSacrifices(1);
		}

		public override void SetDefaults()
		{
			Item.value = 7_50_00;
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 40;
			player.meleeSpeed += 0.08f;
			player.GetDamage(DamageClass.Generic) += 0.08f;
			player.GetCritChance(DamageClass.Generic) += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) =>
			body.type == ItemID.PalladiumBreastplate
			&& legs.type == ItemID.PalladiumLeggings;

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Greatly increases life regeneration after striking an enemy";
			player.onHitRegen = true;
		}

		public override void AddRecipes() => CreateRecipe()
			.AddIngredient(ItemID.PalladiumBar, 12)
			.AddTile(TileID.Anvils)
			.Register();
	}
}