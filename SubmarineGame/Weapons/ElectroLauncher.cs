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
        Activator launchActivator = new Activator(0);
        Timer launchTimer = new Timer(0.5f);
        bool beamLaunched = false;
        
        Color color = Color.Blue;
        float width = 0.01f;
        float length = 0.1f;

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Length
        {
            get { return length; }
            set { length = value; }
        }

        int damage = 30;

        public ElectroBeam ElectroBeam
        {
            get { return electroBeam; }
            set { electroBeam = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public ElectroLauncher()
        {
            
        }

        public void LaunchElectroBeam(Vector2 position, bool electroButtonPressed, float deltaTime)
        {
            if (launchActivator.activeOneTimeStep(electroButtonPressed))
            {
                beamLaunched = true;
                electroBeam = new ElectroBeam(position, color, width, length, damage);
            }
            if (beamLaunched && !launchTimer.runTimer(deltaTime))
            {
                electroBeam = new ElectroBeam(position, color, width, length, damage);
            }
            else
            {
                electroBeam = null;
                beamLaunched = false;
                launchTimer.resetTimer();
            }
        }
    }
}
