﻿/*******************************************************************************************************/
// File:    Time.cs
// Summary: A timer. Can be set and reset and count down. 
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;

namespace Model
{

    class Timer
    {
        float resetTime; // Time timer is set to
        float time = 0; // Time since last run

        // CONSTRUCTOR
        public Timer(float resetTime)
        {
            this.resetTime = resetTime;
        }

        // GET
        public float getResetTime() { return resetTime; }
        public float getTime() { return time; }

        // SET
        public void setTimer(float resetTime)
        {
            this.resetTime = resetTime;
        }
        // RESET
        public void resetTimer()
        {
            time = 0;
        }

        // RUN
        // Returns true if reset time is reached 
        public bool runTimer(float deltaTime)
        {
            bool reachedResetTime = false;
            time += deltaTime;

            if (time > resetTime)
            {
                reachedResetTime = true;
            }
            return reachedResetTime;
        }

        // REVERSE ONE TIME STEP
        public void reverseOneTimeStep(float deltaTime)
        {
            time -= deltaTime;
        }
    }
}
