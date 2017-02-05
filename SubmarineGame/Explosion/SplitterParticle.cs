using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Model
{
    /// <summary>
    /// A particle used in the splitter simulation
    /// </summary>
    class SplitterParticle
    {
        float yAcceleration; // Acceleration in y direction
        float size; // Size of the particle
        Vector2 position; // Position of the particle
        Vector2 speedVector; // Speed of the particle
        /// <summary>
        /// Constructor: Setting initial position (at centre of the screen, high up),
        /// and speed vector (a unitary vector pointing in a random direction)
        /// </summary>
        /// <param name="rand">Random seed</param>
        public SplitterParticle(Vector2 position, float yAcceleration, float maxSpeed, float size)
        {
            this.yAcceleration = yAcceleration;
            this.size = size;
             // Initial position
            this.position = position;
            // Vector with two random numbers in the span (-0.5, 0.5)
            Vector2 randomDirection = new Vector2((float)SplitterSystem.rand.NextDouble() - 0.5f, (float)SplitterSystem.rand.NextDouble() - 0.5f);
            // Normalize to get it spherical with length 1.0
            randomDirection.Normalize();
            // Generating initial speed: a random number in the span (0, maxSpeed)
            float initialSpeed = (float)SplitterSystem.rand.NextDouble() * maxSpeed; 
            // Initial speed and direction
            speedVector = randomDirection * initialSpeed;
        }
        /// <summary>
        /// Get methods: Returns the position and speed for public access
        /// </summary>
        public Vector2 getPosition()
        {
            return position;
        }
        public Vector2 getSpeedVector()
        {
            return speedVector;
        }
        /// <summary>
        /// Updating speed and position for the particle.
        /// X coordinates are linear to the x components of the speeds
        /// Y coordinates are calculated using the y components of the speeds
        /// which increases due to influence of gravity
        /// </summary>
        /// <param name="deltaTime">Simultion time step</param>
        public void update(float deltaTime) 
        {
            speedVector.Y = speedVector.Y + yAcceleration * deltaTime;

            position = position + speedVector * deltaTime;
        }
    }
}
