/*******************************************************************************************************/
// File:    MasterController.cs
// Summary: Creates and initiates main elements of the game, such as gameView (draws the game), 
// gameController(handles actions and movement), gameSimulation (created and handles maps and player).§
// Also deciding actions depending on the game state.
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Model
{
    class MapL1 : BaseMap
    {
        public static readonly float MAP_WIDTH = 2.0f;
        public static readonly int NO_GROUND_ELEMENTS = 1000;
        public static readonly float GROUND_MAX_HEIGHT = 0.5f;
        Player player;
        Vector2[] ground = new Vector2[NO_GROUND_ELEMENTS];
        List<BaseEnemy> enemies = new List<BaseEnemy>();
        List<Mountain> mountains = new List<Mountain>();

        public MapL1(Player player)
        {
            this.player = player;
            enemies.Add(new EnemyClassOne(new Vector2(1.0f, 0.5f)));
            enemies.Add(new EnemyClassOne(new Vector2(1.0f, 0.3f)));

            makeGround();
            Mountains.Add(new Mountain(0.5f, 0.5f, 0.9f, 0.2f));
            Mountains.Add(new Mountain(0.8f, 0.5f, 0.7f, 0.4f));
        }
        public Vector2[] Ground
        {
            get { return ground; }
            set { ground = value; }
        }

        public List<BaseEnemy> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public List<Mountain> Mountains
        {
            get
            {
                return mountains;
            }

            set
            {
                mountains = value;
            }
        }

        public void makeGround()
        {
            ground[0] = new Vector2(0.1f, 0.1f);

            for (int i = 1; i < NO_GROUND_ELEMENTS; i++)
            {
                if (ground[i - 1].Y > GROUND_MAX_HEIGHT)
                {
                    ground[i - 1].Y = GROUND_MAX_HEIGHT;
                }
                else if (ground[i - 1].Y < 0)
                {
                    ground[i - 1].Y = 0;
                }
                else
                {
                    ground[i] = new Vector2(i * MAP_WIDTH / NO_GROUND_ELEMENTS, ground[i - 1].Y + (float)Mathematics.RAND.NextDouble() * 0.02f - 0.01f);
                }
            }
        }
    }
}
