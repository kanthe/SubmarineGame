using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Model
{
    /// <summary>
    /// Sets position of the flare part of an explosion
    /// </summary>
    class FlareSystem
    {
        Vector2 position;

        public FlareSystem(Vector2 position)
        {
            this.position = position;
        }
        /// <summary>
        /// Gets position
        /// </summary>
        public Vector2 getPosition()
        {
            return position;
        }
    }
}
