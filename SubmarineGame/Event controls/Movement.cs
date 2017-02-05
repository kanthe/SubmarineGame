/*******************************************************************************************************/
// File:    Movement.cs
// Summary: Handles different kind of movement and turning
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;

namespace Model
{
    class Movement
    {
        public static readonly float GRAVITY = 0.05f;

        public Movement()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        public Vector2 forward(Vector2 position, float speed, float deltaTime)
        {
            position.X += speed * deltaTime;
            return position;
        }
        /// <summary>
        /// 
        /// </summary>
        public Vector2 backward(Vector2 position, float speed, float deltaTime)
        {
            position.X -= speed * deltaTime;
            return position;
        }
        /// <summary>
        /// 
        /// </summary>
        public Vector2 up(Vector2 position, float speed, float deltaTime)
        {
            position.Y += speed * deltaTime;
            return position;
        }
        /// <summary>
        /// 
        /// </summary>
        public Vector2 down(Vector2 position, float speed, float deltaTime)
        {
            position.Y -= speed * deltaTime;
            return position;
        }
    }
}
