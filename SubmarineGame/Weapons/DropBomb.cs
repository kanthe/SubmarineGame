/*******************************************************************************************************/
// File:    DropBomb.cs
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
    class DropBomb
    {
        Vector2 position;
        float speed;
        Color color;
        int damage;
        float size;

        public float Size
        {
            get { return size; }
            set { size = value; }
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

        public DropBomb(Vector2 position, float speed, Color color, float size, int damage)
        {
            this.position = position;
            this.speed = speed;
            this.color = color;
            this.size = size;
            this.damage = damage;
        }
    }
}