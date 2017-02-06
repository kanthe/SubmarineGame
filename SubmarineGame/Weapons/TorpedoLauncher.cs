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

        internal System.Collections.Generic.List<Torpedo> Torpedos
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

        public TorpedoLauncher()
        {
            
        }

        public void LaunchTorpedo(Vector2 position, bool torpedoButtonPressed)
        {
            if (launchActivator.activeOneTimeStep(torpedoButtonPressed))
            {
                torpedos.Add(new Torpedo(position, speed, color, size, damage));
            }
        }
    }
}
