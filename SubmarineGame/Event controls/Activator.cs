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
        float resetTime;
        bool buttonPrevPressed = false;
        bool reachedResetTime = false;
        bool activate = false;
        bool prevActivate = false;

        public Activator(float resetTime)
        {
            this.resetTime = resetTime;
            timer = new Timer(resetTime);
        }

        public Timer getTimer()
        {
            return timer;
        }

        public bool getActive()
        {
            return buttonPrevPressed;
        }

        public bool getReachedResetTime()
        {
            return reachedResetTime;
        }

        public bool activeOnHold(bool buttonPressed, float deltaTime)
        {
            reachedResetTime = timer.runTimer(deltaTime);

            if (buttonPressed && !buttonPrevPressed && !reachedResetTime)
            {
                activate = true;
            }
            else if (buttonPressed && buttonPrevPressed)
            {
                activate = true;
            }
            else
            {
                timer.resetTimer();
                activate = false;
            }

            buttonPrevPressed = buttonPressed;

            return activate;
        }

        public bool activeOnRelease(bool buttonPressed)
        {

            if (!buttonPressed && buttonPrevPressed)
            {
                activate = true;
            }
            else
            {
                activate = false;
            }
            buttonPrevPressed = buttonPressed;

            return activate;
        }

        public bool activeOnInterval(bool buttonPressed, float deltaTime)
        {
            reachedResetTime = timer.runTimer(deltaTime);

            if (buttonPressed && buttonPrevPressed && reachedResetTime)
            {
                activate = true;
                timer.resetTimer();
            }
            else
            {
                activate = false;
            }
            buttonPrevPressed = buttonPressed;

            return activate;
        }

        public bool activeOneTimeStep(bool buttonPressed)
        {

            if (buttonPressed && !buttonPrevPressed)
            {
                activate = true;
            }
            else
            {
                activate = false;
            }
            buttonPrevPressed = buttonPressed;

            return activate;
        }

        public bool activateDeactivateOnRelease(bool buttonPressed)
        {

            if (buttonPrevPressed == buttonPressed) { activate = prevActivate; }
            else if (!buttonPrevPressed) { activate = !prevActivate; }
            else { activate = prevActivate; }

            buttonPrevPressed = buttonPressed;

            buttonPrevPressed = buttonPressed;
            prevActivate = activate;

            return activate;
        }
    }
}
