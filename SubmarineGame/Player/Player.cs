/*******************************************************************************************************/
// File:    Player.cs
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

namespace Model
{
    class Player
    {
        Vector2 position;
        float speed = 0.1f;
        Color color = Color.Green;
        float size = 0.04f;
        int hitPoints = 100;
        int maxHitPoints = 100;
        TorpedoLauncher torpedoLauncher = new TorpedoLauncher(1.0f);
        DropBombLauncher dropBombLauncher = new DropBombLauncher(2.0f);
        ElectroLauncher electroLauncher = new ElectroLauncher(0.5f, 0.5f);

        public Player(Vector2 position)
        {
            this.position = position;
        }
        public void IsHit(int damage)
        {
            hitPoints -= damage;

            if (color == Color.Green)
            {
                color = Color.Yellow;
            }
            else
            {
                color = Color.Green;
            }
        }
        public bool IsGameOver()
        {
            bool gameOver = false;

            if(hitPoints <= 0)
            {
                gameOver = true;
            }
            return gameOver;
        }

        #region Properties

        public TorpedoLauncher TorpedoLauncher
        {
            get { return torpedoLauncher; }
            set { torpedoLauncher = value; }
        }

        public DropBombLauncher DropBombLauncher
        {
            get { return dropBombLauncher; }
            set { dropBombLauncher = value; }
        }

        public ElectroLauncher ElectroLauncher
        {
            get { return electroLauncher; }
            set { electroLauncher = value; }
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

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public int HitPoints
        {
            get { return hitPoints; }
            set { hitPoints = value; }
        }

        public int MaxHitPoints
        {
            get { return maxHitPoints; }
            set { maxHitPoints = value; }
        }

        #endregion
    }
}
