/*******************************************************************************************************/
// File:    GameSimulation.cs
// Summary: Creates the player and maps and thus setting up initial condition of the game. Also reseting
// initial conditions when restarting game and keep track of current level.
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;

namespace Model
{
    

    interface IEnemy
    {
        Vector2 Position { get; set; }
        float Speed { get; set; }
        Color Color { get; set; }
        float Size { get; set; }
        int HitPoints { get; set; }
        int MaxHitPoints { get; set; }
        Movement Movement { get; set; }

        void Fire(System.Collections.Generic.List<Torpedo> enemyBullets, float deltaTime);
        /// <summary>
        /// ENEMY DAMAGED/DESTROYED
        /// </summary>
        void crash();
        void isHit(int damage);
    }
}
