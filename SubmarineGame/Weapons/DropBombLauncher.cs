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
using System.Collections.Generic;

namespace Model
{
    class DropBombLauncher
    {
        List<DropBomb> dropBombs = new List<DropBomb>();
        Activator launchActivator = new Activator();
        
        Color color = Color.Red;
        float size = 0.02f;
        int damage = 20;
        Timer timer;

        public List<DropBomb> DropBombs
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

        public DropBombLauncher(float interval)
        {
            timer = new Timer(interval);
        }

        public void LaunchDropBomb(Vector2 position, float speed, bool dropBombButtonPressed, float deltaTime)
        {
            if (timer.runTimer(deltaTime) &&
                launchActivator.activeOneTimeStep(dropBombButtonPressed))
            {
                dropBombs.Add(new DropBomb(position, speed, color, size, damage));
                timer.resetTimer();
            }
        }
    }
}
