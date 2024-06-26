using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DustDancers.Content.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class LeatherDancerHead : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 4;
            Item.value = 1000;
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.05f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.Register();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = 
                "\n+25% movement speed\n" +
                "+10% acceleration\n" +
                "+12% mining speed\n" +
                "'To be as fast as lightning is to be a third as fast of what's preferred' - Adahn Rose";
            player.moveSpeed += 0.25f;
            player.runAcceleration += 0.10f;
            player.pickSpeed -= 0.12f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            if (body.type == ModContent.ItemType<LeatherDancerChest>() && legs.type == ModContent.ItemType<LeatherDancerLegs>()) 
            {
                return true;
            }
            return false;
        }
    }
}
