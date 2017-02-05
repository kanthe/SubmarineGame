using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Model
{
    /// <summary>
    /// Creating smoke particles and calculates the positions
    /// of them after an update.
    /// </summary>
    class SmokeSystem
    {
        public static readonly System.Random rand = new System.Random(); // Random number seed
        Vector2 position; // Initial position of the particles
        float yAcceleration = 0; // Acceleration in y direction
        float speedXYratio = 1.0f; // Initial speed in x direction compared to y direction
        float maxSpeed = 0.05f; // Maximum speed of the particles
        float rotationSpeed = 0.01f; // Rotation speed of the particles
        float maxParticleLifeTime = 1.0f; // Maximum life time of the particles
        float minSize = 1.0f; // Minimum size of the particles
        float maxSize = 100.0f; // Maximum size of the particles
        /// Creating a list of splitter particles
        public System.Collections.Generic.List<SmokeParticle> particles = 
            new System.Collections.Generic.List<SmokeParticle>(); // System of smoke particles
        /// <summary>
        /// Contructors: Adding a particle to the list
        /// </summary>
        public SmokeSystem(Vector2 position)
        {
            this.position = position;
            particles.Add(new SmokeParticle(position, yAcceleration, speedXYratio, maxSpeed, rotationSpeed, maxParticleLifeTime, minSize, maxSize));
        }
        public SmokeSystem(Vector2 position, float maxParticleLifeTime, float minSize, float maxSize)
        {
            this.position = position;
            this.maxParticleLifeTime = maxParticleLifeTime;
            this.maxSize = maxSize;
            this.minSize = minSize;
            particles.Add(new SmokeParticle(position, yAcceleration, speedXYratio, maxSpeed, rotationSpeed, maxParticleLifeTime, minSize, maxSize));       
        }
        public SmokeSystem(Vector2 position, float yAcceleration, float speedXYratio, float maxSpeed, float rotationSpeed, float maxParticleLifeTime, float minSize, float maxSize)
        {
            this.position = position;
            this.yAcceleration = yAcceleration;
            this.speedXYratio = speedXYratio;
            this.maxSpeed = maxSpeed;
            this.rotationSpeed = rotationSpeed;
            this.maxParticleLifeTime = maxParticleLifeTime;
            this.maxSize = maxSize;
            this.minSize = minSize;
            particles.Add(new SmokeParticle(position, yAcceleration, speedXYratio, maxSpeed, rotationSpeed, maxParticleLifeTime, minSize, maxSize));
        }
        /// <summary>
        /// Adds a new smoke particle
        /// </summary>
        public void addParticle()
        {
            particles.Add(new SmokeParticle(position, yAcceleration, speedXYratio, maxSpeed, rotationSpeed, maxParticleLifeTime, minSize, maxSize));
        }
        /// <summary>
        /// Removes the first smoke particle in the list
        /// </summary>
        public void removeParticle()
        {
            particles.RemoveAt(0);
        }
        /// <summary>
        /// Uses methods in the SmokePaerticle class to update postion, 
        /// speed, lifetime and size of all smoke particles
        /// </summary>
        /// <param name="deltaTime">Game time step</param>
        public void updateParticles(float deltaTime)
        {
            // Updating speed and position for all particles
            foreach (SmokeParticle particle in particles)
            {
                particle.update(deltaTime);
            }
        }
        public float getMaxSize() 
        {
            return maxSize;
        }
    }
}
