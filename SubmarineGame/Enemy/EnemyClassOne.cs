﻿using Microsoft.Xna.Framework;

namespace Model
{
    class EnemyClassOne : IEnemy
    {
        Vector2 position;
        float speed = -0.1f;
        Color color = Color.Red;
        float size = 0.02f;
        int hitPoints = 100;
        int maxHitPoints = 100;
        Movement movement = new Movement();
        Timer damageTimer = new Timer(0.5f);

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
            get { return maxHitPoints; }
            set { maxHitPoints = value; }
        }

        public Movement Movement
        {
            get { return movement; }
            set { movement = value; }
        }

        public Timer DamageTimer
        {
            get
            {
                return damageTimer;
            }

            set
            {
                damageTimer = value;
            }
        }

        public EnemyClassOne (Vector2 position)
        {
            this.position = position;
        }

        public void Fire(System.Collections.Generic.List<Torpedo> enemyBullets, float deltaTime)
        {

        }
        /// <summary>
        /// ENEMY DAMAGED/DESTROYED
        /// </summary>
        public void crash()
        {
            
        }

        public void isHit(int damage)
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
    }
}