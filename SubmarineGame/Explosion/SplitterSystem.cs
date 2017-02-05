using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Model
{
    /// <summary>
    /// Creating splitter particles and calculates the positions
    /// of them after an update.
    /// </summary>
    class SplitterSystem
    {
        public static readonly System.Random rand = new System.Random(); // Random number seed
        int numberOfParticles = 20;
        float yAcceleration = 0; // Acceleration in y direction
        float maxSpeed = 0.1f;
        float size = 5.0f; // Size of the particles
        SplitterParticle[] particles; // System of particles
        /// <summary>
        /// Contructor: Creating an array of splitter particles
        /// </summary>
        public SplitterSystem(Vector2 position)
        {
            particles = new SplitterParticle[numberOfParticles];

            for (int count = 0; count < numberOfParticles; count++)
            {
                particles[count] = new SplitterParticle(position, yAcceleration, maxSpeed, size);
            }
        }
        public SplitterSystem(Vector2 position, float maxSpeed, float size)
        {
            particles = new SplitterParticle[numberOfParticles];
            this.maxSpeed = maxSpeed;
            this.size = size;

            for (int count = 0; count < numberOfParticles; count++)
            {
                particles[count] = new SplitterParticle(position, yAcceleration, maxSpeed, size);
            }
        }
        public SplitterSystem(Vector2 position, int numberOfParticles, float yAcceleration, float maxSpeed, float size)
        {
            particles = new SplitterParticle[numberOfParticles];
            this.numberOfParticles = numberOfParticles;
            this.yAcceleration = yAcceleration;
            this.maxSpeed = maxSpeed;
            this.size = size;
            
            for (int count = 0; count < numberOfParticles; count++) {
                particles[count] = new SplitterParticle(position, yAcceleration, maxSpeed, size);
            }
        }
        /// <summary>
        /// Get methods: Returns a specific particle, the number of particles in the simulation and
        /// the size of the particles
        /// </summary>
        /// <param name="count">Array index of the returned particle</param>
        /// <returns>A particle</returns>
        public SplitterParticle getParticle(int count)
        {
            return particles[count];
        }
        public int getNumberOfParticles()
        {
            return numberOfParticles;
        }
        public float getSize()
        {
            return size;
        }
        /// <summary>
        /// Uses the update method in the SplitterParticle class to update postion
        /// and speed of all splitter particles
        /// </summary>
        /// <param name="deltaTime">Game time step</param>
        public void update(float deltaTime)
        {

            for (int count = 0; count < numberOfParticles; count++)
            {
                particles[count].update(deltaTime);
            }
        }
        
    }
}
