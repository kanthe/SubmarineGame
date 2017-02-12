/*******************************************************************************************************/
// File:    Electro.cs
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
    class ElectroBeam
    {
        Vector2 position;
        float speed;
        Color color;
        int damage;
        float height;
        float width;

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
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

        public ElectroBeam(Vector2 position, Color color, float width, float height, int damage)
        {
            this.position = position;
            this.color = color;
            this.height = width;
            this.width = height;
            this.damage = damage;
        }
    }
}