using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Model
{
    /// <summary>
    /// A particle used in the smoke simulation
    /// </summary>
    class SmokeParticle
    {
        float yAcceleration; // Acceleration in y direction
        float rotationSpeed; // Rotation speed of the particle
        float maxParticleLifeTime; // Maximum life time of the particle
        float minSize; // Minimum size of the particle
        float maxSize; // Maximum size of the particle
        Vector2 initPosition; // Initial position of the particle
        Vector2 position; // Position of the particle
        Vector2 initSpeedVector; // Initial speed
        Vector2 speedVector; // Speed
        float rotationAngle = 0; // Rotation angle
        float timeLived = 0; // Time since creation of the parrticle
        float lifePercent = 0; // Lifetime percent of maximum lifetime
        float size = 0; // Size of the particle
        /// <summary>
        /// Constructor: Setting initial position (at centre of the screen, near bottom),
        /// and speed vector (a unitary vector pointing in a random direction)
        /// </summary>
        /// <param name="rand">Random seed</param>
        public SmokeParticle(Vector2 position, float yAcceleration, float speedXYratio, float maxSpeed, float rotationSpeed, float maxParticleLifeTime, float minSize, float maxSize)
        {
            this.yAcceleration = yAcceleration;
            this.rotationSpeed = rotationSpeed;
            this.maxParticleLifeTime = maxParticleLifeTime;
            this.minSize = minSize;
            this.maxSize = maxSize;
            initPosition = position;
            this.position = position;
            // Vector with two random numbers in the span (-0.5, 0.5)
            Vector2 randomDirection = new Vector2((float)SmokeSystem.rand.NextDouble() - 0.5f, (float)SmokeSystem.rand.NextDouble() - 0.5f);
            // Normalize to get a spherical vector with length 1.0
            randomDirection.Normalize();
            // Generating initial speed: a random number in the span (0, maxSpeed)
            float initialSpeed = (float)SmokeSystem.rand.NextDouble() * maxSpeed;
            // Initial speed and direction
            speedVector.X = randomDirection.X * initialSpeed * speedXYratio;
            speedVector.Y = randomDirection.Y * initialSpeed;

            initSpeedVector = speedVector;
        }
        /// <summary>
        /// Get methods: Returns the position, speed, rotation angle and size for public access
        /// </summary>
        public Vector2 getPosition()
        {
            return position;
        }
        public Vector2 getSpeedVector()
        {
            return speedVector;
        }
        public float getRotationAngle()
        {
            return rotationAngle;
        }
        public float getSize()
        {
            return size;
        }
        /// <summary>
        /// Updating position, speed, time lived, life percent, size and rotation angle
        /// Speed is constant in x direction and depending linearly on acceleration in y direction
        /// Time lived increases with "deltaTime"
        /// Life percent is how mush of it's maximum liftime it has lived
        /// Size depends linearly on life percent
        /// Rotation angle increases linearly with "rotAngleIncrease"
        /// </summary>
        /// <param name="deltaTime">Gametime step</param>
        public void update(float deltaTime)
        {
            speedVector.Y = speedVector.Y + yAcceleration * deltaTime;
            position = position + speedVector * deltaTime;
            timeLived += deltaTime;
            lifePercent = timeLived / maxParticleLifeTime;
            size = minSize + lifePercent * maxSize;
            rotationAngle += rotationSpeed;
            // All variales is set to initial values when "maxTimeToLive" is reached
            if (timeLived > maxParticleLifeTime)
            {
                timeLived = 0;
                lifePercent = 0;
                size = minSize;
                position = initPosition;
                speedVector = initSpeedVector;
            }
        }
        
        
    }
}
