﻿using System;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class FakeHeartMarkDeviantt : ModProjectile
    {
        public override string Texture => "Fargowiltas/Projectiles/FakeHeartDeviantt";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fake Heart");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.timeLeft = 2;
            projectile.aiStyle = -1;
            projectile.hide = true;

            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            if (Main.netMode != 1)
            {
                for (int i = -3; i < 3; i++)
                {
                    Projectile.NewProjectile(projectile.Center, -projectile.velocity.RotatedBy(Math.PI / 7 * i), mod.ProjectileType("FakeHeart2Deviantt"), projectile.damage, projectile.knockBack, projectile.owner, -1, 120 + 20 * i);
                }
            }

            projectile.Kill();
        }

        public override bool CanDamage()
        {
            return false;
        }
    }
}