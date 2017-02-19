using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Model
{
    class EnemyClassOne : BaseEnemy
    {

        public EnemyClassOne(Vector2 position)
        {
            Position = position;
            Speed = 0.05f;
            Color = Color.Red;
            Size = 0.02f;
            CrashDamage = 50;
            HitPoints = 100;
            MaxHitPoints = 100;
            float launchInterval = 1.0f;
            TorpedoLauncher = new TorpedoLauncher(launchInterval);
            TorpedoLauncher.Color = Color.Red;
            TestProperties();
        }

        #region Properties
        


        #endregion

    }
}
