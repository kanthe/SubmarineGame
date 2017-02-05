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
    class DropBombLauncher
    {
        System.Collections.Generic.List<DropBomb> dropBombs = new System.Collections.Generic.List<DropBomb>();
        Activator launchActivator = new Activator(0);
        
        Color color = Color.Red;
        float size = 0.02f;
        int damage = 20;

        internal System.Collections.Generic.List<DropBomb> DropBombs
            {
                get { return dropBombs; }
                set { dropBombs = value; }
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

        public DropBombLauncher()
        {
            
        }

        public void LaunchDropBomb(Vector2 position, float speed, bool dropBombButtonPressed)
        {
            if (launchActivator.activeOneTimeStep(dropBombButtonPressed))
            {
                dropBombs.Add(new DropBomb(position, speed, color, size, damage));
            }
        }
    }
}
