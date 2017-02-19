using Microsoft.Xna.Framework;

namespace Model
{
    class BaseEnemy : IEnemy
    {
        Vector2 position;
        float speed = -1;
        Color color;
        float size = -1;
        int hitPoints = -1;
        int maxHitPoints = -1;
        int crashDamage = -1;
        Timer electroDamageTimer = new Timer(2.0f);
        TorpedoLauncher torpedoLauncher = null;
        DropBombLauncher dropBombLauncher = null;
        ElectroLauncher electroLauncher = null;


        /// <summary>
        /// ENEMY DAMAGED/DESTROYED
        /// </summary>
        public void IsHit(int damage)
        {
            hitPoints -= damage;

            if (color == Color.Red)
            {
                color = Color.Purple;
            }
            else
            {
                color = Color.Red;
            }
        }
        public void Fire(float deltaTime)
        {

            if (torpedoLauncher != null && torpedoLauncher.Timer.runTimer(deltaTime))
            {
                torpedoLauncher.LaunchTorpedo(position);
                torpedoLauncher.Timer.resetTimer();
            }
        }
        public void MoveWeapons(float deltaTime, Movement movement) {

            if (torpedoLauncher != null)
            {
                for (int i = torpedoLauncher.Torpedos.Count - 1; i >= 0; i--)
                {
                    Torpedo torpedo = torpedoLauncher.Torpedos[i];
                    torpedo.Position = movement.backward(torpedo.Position, torpedo.Speed, deltaTime);
                }
            }
        }
        public int DidWeaponHitPlayer(Vector2 playerPosition, float playerSize)
        {
            int damage = 0;

            if (torpedoLauncher != null)
            {
                for (int i = torpedoLauncher.Torpedos.Count - 1; i >= 0; i--)
                {
                    Torpedo torpedo = torpedoLauncher.Torpedos[i];
                    
                    if (Mathematics.IsInsideCircle(playerPosition, playerSize, torpedo.Position, torpedo.Size))
                    {
                        torpedoLauncher.Torpedos.Remove(torpedo);
                        damage += torpedo.Damage;
                    }
                }
            }
            return damage;
        }

        public void TestProperties()
        {
            if (position == new Vector2(0, 0) || speed == -1 || size == -1 || hitPoints == -1 || maxHitPoints == -1 || crashDamage == -1)
            {
                throw new System.Exception();
            }
        }

        #region Properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public int HitPoints
        {
            get { return hitPoints; }
            set { hitPoints = value; }
        }
        public int MaxHitPoints
        {
            get{ return maxHitPoints; }
            set { maxHitPoints = value; }
        }
        public Timer ElectroDamageTimer
        {
            get { return electroDamageTimer; }
            set { electroDamageTimer = value; }
        }

        public TorpedoLauncher TorpedoLauncher
        {
            get { return torpedoLauncher; }
            set { torpedoLauncher = value; }
        }

        public int CrashDamage
        {
            get { return crashDamage; }
            set { crashDamage = value; }
        }

        public DropBombLauncher DropBombLauncher
        {
            get
            {
                return dropBombLauncher;
            }

            set
            {
                dropBombLauncher = value;
            }
        }

        public ElectroLauncher ElectroLauncher
        {
            get
            {
                return electroLauncher;
            }

            set
            {
                electroLauncher = value;
            }
        }

        

        #endregion
    }
}
