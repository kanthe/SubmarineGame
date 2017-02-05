using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Model;

namespace View
{
    /// <summary>
    /// Creates an explosion consisting of 3 parts, flare, splitter and smoke
    /// which all have a View class and System class. Objects of these classes are created.
    /// Also an explosion sound effect is loaded and played
    /// 
    /// </summary>
    class Explosion
    {
        Vector2 position;
        GraphicsDevice device;
        ContentManager content;
        SmokeSystem smokeSystem;
        SmokeView smokeView;
        FlareSystem flareSystem;
        FlareView flareView;
        SplitterSystem splitterSystem;
        SplitterView splitterView;

        int explosionUpdateCount = 0; // The number of gametime steps the explosion has been
        int flareTileNumber = 1; // Currently shown explosion image
        public static readonly float flareFrameRate = 60.0f; // Frames per second
        float explosionTime; // The time all explosion images should have been shown
        // The time the explosion starts. Used by "EventListener" to determine how long the explosion has been going
        float explosionStartTime; 
        /// <summary>
        /// Constructor: 
        /// Sets model position of the mouse cursor
        /// Creates the required objects
        /// Loads and plays explosion sound
        /// </summary>
        public Explosion(int scale, GraphicsDevice device, ContentManager content, GameTime explosionStartTime, Vector2 position, 
            float flareSize, float smokeParticleMaxLifeTime, float smokeParticleMinSize, float smokeParticleMaxSize, float splitterSpeed, float splitterSize)
        {
            this.position = position;
            this.content = content;
            this.device = device;
            this.explosionStartTime = (float)explosionStartTime.TotalGameTime.TotalSeconds;

            flareSystem = new FlareSystem(position);
            smokeSystem = new SmokeSystem(position, smokeParticleMaxLifeTime, smokeParticleMinSize, smokeParticleMaxSize);
            splitterSystem = new SplitterSystem(position, splitterSpeed, splitterSize);

            flareView = new FlareView(flareSize, flareSystem, scale, device, content);
            smokeView = new SmokeView(smokeSystem, scale, device, content);
            splitterView = new SplitterView(splitterSystem, scale, device, content);

            explosionTime = (float)FlareView.numberOfTiles / flareFrameRate;
        }
        /// <summary>
        /// Upadates the explosion i.e. calls update and draw methods in the flare, smoke aand splitter objects
        /// Which loads and draws images, updates model and view positions etc.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime, SpriteBatch spriteBatch)
        {
            explosionUpdateCount++; // The number of gametime steps the explosion has been
            
            smokeSystem.addParticle(); // Adds a smoke particle
            // Determines which frame (explosion image) which shall be shown. 
            if (explosionUpdateCount * deltaTime > flareTileNumber * explosionTime / FlareView.numberOfTiles && flareTileNumber <= 23)
            {
                flareTileNumber++; // Currently shown flare image is increased by 1, which will be shown next update
            }

            smokeSystem.updateParticles(deltaTime); // Updates smoke particles
            splitterSystem.update(deltaTime); // Updates splitter particles

            // Draws flare, splitter and smoke 
            flareView.DrawFlare(flareTileNumber, spriteBatch);
            splitterView.DrawSplitter(spriteBatch);
            smokeView.DrawSmoke(spriteBatch);
        }
        /// <summary>
        /// Sets and gets the start time of the explosion
        /// </summary>
        public float getExplosionStartTime()
        {
            return explosionStartTime;
        }
    }
}
