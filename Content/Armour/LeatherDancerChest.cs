using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DustDancers.Content.Armour
{
    [AutoloadEquip(EquipType.Body)]
    public class LeatherDancerChest : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 12;
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
    }
}
