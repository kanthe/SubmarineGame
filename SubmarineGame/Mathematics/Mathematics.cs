/*******************************************************************************************************/
// File:    Mathematics.cs
// Summary: Performs some mathematical operations.
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using System;
using Microsoft.Xna.Framework;

namespace Model
{
    static class Mathematics
    {
        // Defines some constants, used in the game.
        public static readonly Random RAND = new Random();
        public static readonly float PI = (float)Math.PI;

        /// <summary>
        /// Returns the absolute value (length) of a vector
        /// </summary>
        public static float AbsoluteValue(Vector2 vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
        /// <summary>
        /// Returns the absolute value (length) of a length
        /// </summary>
        public static float AbsoluteValue(float length)
        {
            return (float)Math.Abs(length);
        }
        /// <summary>
        /// Calculating the angle from the direction
        /// </summary>
        public static Vector2 AngleToDirection(float angle)
        {
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            direction.Normalize();

            return direction;
        }
        /// <summary>
        /// Calculating the angle from the direction
        /// </summary>
        public static float DirectionToAngel(Vector2 direction)
        {
            float angle = (float)Math.Asin(direction.Y / AbsoluteValue(direction));

            return angle;
        }
        /// <summary>
        /// Determines if Two circles intersect or (if one diameter is set to 0), if something is inside a circle
        /// </summary>
        public static bool IsInsideCircle(Vector2 positionOfObject, float diameterOfObject, Vector2 positionOfCircle, float diameterOfCircle)
        {
            // positionOfObject = positionOfObject + new Vector2(diameterOfObject / 2, diameterOfObject / 2);
            // positionOfCircle = positionOfCircle + new Vector2(diameterOfCircle / 2, diameterOfCircle / 2);
            return AbsoluteValue(positionOfObject - positionOfCircle) < diameterOfObject / 2 + diameterOfCircle / 2;
        }
        /// <summary>
        /// Determines if a circle intersect or (if one diameter is set to 0), if something is inside a rectangle
        /// positionOfRectangle is top left corner of the rectangle
        /// </summary>
        public static bool IsInsideRectangle(Vector2 positionOfObject, float diameterOfObject, Vector2 positionOfRectangle, float widthOfRectangle, float heightOfRectangle)
        {
            bool widthInside = false;
            bool heightInside = false;
            widthInside = positionOfObject.X - positionOfRectangle.X < diameterOfObject / 2 + widthOfRectangle && positionOfObject.X - positionOfRectangle.X > diameterOfObject / 2;
            heightInside = AbsoluteValue(positionOfObject.Y - positionOfRectangle.Y) < diameterOfObject / 2 + heightOfRectangle;

            return widthInside && heightInside;
        }
        /// <summary>
        /// Returns a position inside a circle
        /// </summary>
        public static Vector2 PlaceEvenInCircle()
        {
            Vector2 position = new Vector2();
            float angle = (float)(2.0 * PI * RAND.NextDouble());
            position.X = (float)Math.Cos(angle);
            position.Y = (float)Math.Sin(angle);

            return position;
        }
        /// <summary>
        /// Returns a random position, inside a given circle
        /// </summary>
        public static Vector2 PlaceRandomInCircle()
        {
            Vector2 position = new Vector2();
            float angle = (float)(2.0 * PI * RAND.NextDouble());
            position.X = (float)Math.Cos(angle);
            position.Y = (float)Math.Sin(angle);

            return position;
        }
    }
}
