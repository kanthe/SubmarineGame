/*******************************************************************************************************/
// File:    Activator.cs
// Summary: Activates on events
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;

namespace Model
{

    class Activator
    {
        Timer timer;
        Timer reloadTimer;
        bool buttonPrevPressed = false;
        bool active = false;
        bool prevActive = false;

        public Timer Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public Activator(Timer timer = null, Timer reloadTimer = null)
        {
            this.timer = timer;
            this.reloadTimer = reloadTimer;
        }

        public bool activeOnHold(bool buttonPressed, float deltaTime)
        {
            bool reachedResetTime = timer.runTimer(deltaTime);

            if (buttonPressed && !buttonPrevPressed && !reachedResetTime)
            {
                active = true;
            }
            else if (buttonPressed && buttonPrevPressed)
            {
                active = true;
            }
            else
            {
                timer.resetTimer();
                active = false;
            }

            buttonPrevPressed = buttonPressed;

            return active;
        }

        public bool activeOneTimeStep(bool buttonPressed)
        {
            if (buttonPressed && !buttonPrevPressed)
            {
                active = true;
            }
            else
            {
                active = false;
            }
            buttonPrevPressed = buttonPressed;

            return active;
        }

        public bool activeOnRelease(bool buttonPressed)
        {

            if (!buttonPressed && buttonPrevPressed)
            {
                active = true;
            }
            else
            {
                active = false;
            }
            buttonPrevPressed = buttonPressed;

            return active;
        }

        public bool activeOnTimeSpan(bool buttonPressed, float deltaTime)
        {
            bool reachedResetTime = false;
            bool reachedReloadTime = false;

            if (active && !prevActive)
            {
                reachedResetTime = timer.runTimer(deltaTime);

                if(reachedResetTime)
                {
                    active = false;
                    prevActive = true;
                    timer.resetTimer();
                }
            }
            else if(!active && prevActive)
            {
                reachedReloadTime = reloadTimer.runTimer(deltaTime);

                if (reachedReloadTime && !buttonPressed)
                {
                    active = false;
                    prevActive = false;
                    reloadTimer.resetTimer();
                }
            }
            else if (buttonPressed && !active && !prevActive)
            {
                active = true;
                prevActive = false;
            }
            return active;
        }

        public bool activeOnInterval(bool buttonPressed, float deltaTime)
        {
            bool reachedResetTime = timer.runTimer(deltaTime);

            if (buttonPressed && buttonPrevPressed && reachedResetTime)
            {
                active = false;
                timer.resetTimer();
            }
            else
            {
                active = true;
            }
            buttonPrevPressed = buttonPressed;

            return active;
        }

        public bool activateDeactivateOnRelease(bool buttonPressed)
        {
            if(activeOneTimeStep(buttonPressed))
            {
                if(prevActive)
                {
                    prevActive = false;
                }
                else
                {
                    prevActive = true;
                }
            }
            return prevActive;
        }
    }
}
