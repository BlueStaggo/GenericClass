using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(
				"Increases maximum mana by 20\n" +
				"10% increased melee and movement speed\n" +
				"8% increased damage\n" +
				"5% increased critical strike chance"
			);
			this.SetRequiredSacrifices(1);
		}

		public override void SetDefaults()
		{
			Item.value = 7_50_00;
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 20;
			player.moveSpeed += 0.10f;
			player.meleeSpeed += 0.10f;
			player.GetDamage(DamageClass.Generic) += 0.08f;
			player.GetCritChance(DamageClass.Generic) += 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) =>
			body.type == ItemID.CobaltBreastplate
			&& legs.type == ItemID.CobaltLeggings;

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus =
				"10% reduced mana usage\n" +
				"8% increased melee speed\n" +
				"20% chance to not consume ammo";
			player.manaCost -= 0.10f;
			player.ammoCost80 = true;
		}

		public override void ArmorSetShadows(Player player)
		=> player.armorEffectDrawShadow = true;

		public override void AddRecipes() => CreateRecipe()
			.AddIngredient(ItemID.CobaltBar, 10)
			.AddTile(TileID.Anvils)
			.Register();
	}
}