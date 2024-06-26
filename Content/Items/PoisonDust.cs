using Microsoft.Xna.Framework; // Using another one library
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.Localization;

namespace TestMod.Content.Items
{ 
	public class PoisonDust : ModItem
	{
        public override void SetStaticDefaults()
        {
            // Journey mode completion number
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
		}

       public override void SetDefaults()
        {
            // Visual properties
            Item.width = 40; 
            Item.height = 40;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            // Combat properties
            Item.damage = 15; 
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 20; 
            Item.useAnimation = 20; 
            Item.knockBack = 0f; 
            Item.autoReuse = true;
           
            // Projectile Handling
            Item.shoot = ProjectileID.Bee;
            Item.shootSpeed = 5f;

            // Other properties
            Item.value = 10000; // Item sell price in copper coins
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.UseSound = SoundID.Item1; 
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3)) 
            {
                // ...spawning dust
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Poisoned, 0, 0, 125); 
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(2))
            {
                target.AddBuff(BuffID.Poisoned, 300);
            }
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
