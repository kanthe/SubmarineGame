/*******************************************************************************************************/
// File:    TorpedoLauncher.cs
// Summary: Creates and initiates main elements of the game, such as gameView (draws the game), 
// gameController(handles actions and movement), gameSimulation (created and handles maps and player).§
// Also deciding actions depending on the game state.
// Version: Version 1.0 - 2016-06-26
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-26 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;

namespace Model
{
    class TorpedoLauncher
    {
        System.Collections.Generic.List<Torpedo> torpedos = new System.Collections.Generic.List<Torpedo>();
        Activator launchActivator = new Activator();
        float speed = 0.2f;
        Color color = Color.Yellow;
        float size = 0.01f;
        int damage = 10;
        Timer timer;

        public TorpedoLauncher(float speed, Color color, float size, int damage)
        {
            this.speed = speed;
            this.color = color;
            this.size = size;
            this.damage = damage;
        }
        public TorpedoLauncher(float speed, Color color, float size, int damage, float interval)
        {
            this.speed = speed;
            this.color = color;
            this.size = size;
            this.damage = damage;
            this.timer = new Timer(interval);
        }

        public void LaunchTorpedo(Vector2 position, bool torpedoButtonPressed)
        {
            if (launchActivator.activeOneTimeStep(torpedoButtonPressed))
            {
                torpedos.Add(new Torpedo(position, speed, color, size, damage));
            }
        }

        public void LaunchTorpedo(Vector2 position)
        {
            torpedos.Add(new Torpedo(position, speed, color, size, damage));
        }

        #region Properties

        public System.Collections.Generic.List<Torpedo> Torpedos
        {
            get { return torpedos; }
            set { torpedos = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        internal Timer Timer
        {
            get { return timer; } 
            set  { timer = value; }
        }

        #endregion

    }
}
