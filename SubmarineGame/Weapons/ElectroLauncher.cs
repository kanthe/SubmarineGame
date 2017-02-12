/*******************************************************************************************************/
// File:    ElectroLauncher.cs
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
    class ElectroLauncher
    {
        ElectroBeam electroBeam;
        Activator activator;
        Timer launchTimer = new Timer(0.5f);
        Timer reloadTimer = new Timer(0.25f);
        
        Color color = Color.Blue;
        float width = 0.01f;
        float length = 0.1f;
        int damage = 30;

        public ElectroBeam ElectroBeam
        {
            get { return electroBeam;  } 
            set { electroBeam = value; }
        }

        public Timer LaunchTimer
        {
            get { return launchTimer; }
            set { launchTimer = value; }
        }

        public ElectroLauncher()
        {
            activator = new Activator(launchTimer, reloadTimer);
        }

        public void LaunchElectroBeam(Vector2 position, bool electroButtonPressed, float deltaTime)
        {
            if (activator.activeOnTimeSpan(electroButtonPressed, deltaTime))
            {
                electroBeam = new ElectroBeam(position, color, width, length, damage);
            }
            else
            {
                electroBeam = null;
            }
        }
    }
}
