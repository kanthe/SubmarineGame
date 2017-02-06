/*******************************************************************************************************/
// File:    EventListener.cs
// Summary: Creates and draws the autofirebar.
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Model;

namespace View
{
    class EventListener
    {
        int scale;
        GraphicsDevice device;
        ContentManager content;
        // ANIMATIONS
        System.Collections.Generic.List<Explosion> explosions; // List of explosions
        float explosionDuration = 1.0f; // The time an explosion flare series is completed.
        int explosionNumber = 0; // Number of explosions.
        System.Collections.Generic.List<SmokeView> smokeViewList; // List of smoke
        System.Collections.Generic.List<SmokeSystem> smokeSystemList; // List of smoke
        // SOUNDS
        Activator soundActivator;

        public EventListener(int scale, GraphicsDevice device, ContentManager content)
        {
            this.scale = scale;
            this.device = device;
            this.content = content;
            // ANIMATIONS
            explosions = new System.Collections.Generic.List<Explosion>();
            smokeViewList = new System.Collections.Generic.List<SmokeView>(); // List of smoke
            smokeSystemList = new System.Collections.Generic.List<SmokeSystem>(); // List of smoke
            // SOUNDS
            soundActivator = new Activator();
        }

        /// <summary>
        /// Creating an explosion object and adding it to a list of such objects. 
        /// </summary>
        public void MakeExplosion(Vector2 position, GameTime explosionStartTime,
            float flareSize, float smokeParticleMaxLifeTime, float smokeParticleMinSize, float smokeParticleMaxSize, float splitterSpeed, float splitterSize)
        {
            explosions.Add(new Explosion(scale, device, content, explosionStartTime, position,
                flareSize, smokeParticleMaxLifeTime, smokeParticleMinSize, smokeParticleMaxSize, splitterSpeed, splitterSize));
            explosionNumber++;
        }
        /// <summary>
        /// Updates explosions.
        /// </summary>
        public void UpdateExplosions(GameTime gameTime, SpriteBatch spriteBatch, float deltaTime)
        {
            // All explosions are updated until the total game time reaches the explosion duration time 
            foreach (Explosion explosion in explosions)
            {
                if ((float)gameTime.TotalGameTime.TotalSeconds - explosion.getExplosionStartTime() < explosionDuration)
                {
                    explosion.Update(deltaTime, spriteBatch);
                }
            }
        }
        public void MakeSmoke(Vector2 position, float smokeParticleMaxLifeTime, float smokeParticleMinSize, float smokeParticleMaxSize)
        {
            SmokeSystem smokeSystem = new SmokeSystem(position, smokeParticleMaxLifeTime, smokeParticleMinSize, smokeParticleMaxSize);
            smokeSystemList.Add(smokeSystem);
            smokeViewList.Add(new SmokeView(smokeSystem, scale, device, content));
        }
        /// <summary>
        /// Updates explosions.
        /// </summary>
        public void UpdateSmoke(SpriteBatch spriteBatch, float deltaTime)
        {
            // All explosions are updated until the total game time reaches the explosion duration time 
            foreach (SmokeSystem smokeSystem in smokeSystemList)
            {
                smokeSystem.updateParticles(deltaTime);
            }
            foreach (SmokeView smokeView in smokeViewList)
            {
                smokeView.DrawSmoke(spriteBatch);
            }
        }
        public void removeSmoke()
        {
            smokeViewList = new System.Collections.Generic.List<SmokeView>();
            smokeSystemList = new System.Collections.Generic.List<SmokeSystem>();
        }
        /// <summary>
        /// GET METHODS
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.List<Explosion> getExplosions() { return explosions; }
        public System.Collections.Generic.List<SmokeView> getSmokeViewList() { return smokeViewList; }
        public System.Collections.Generic.List<SmokeSystem> getSmokeSystemList() { return smokeSystemList; }

        // SOUNDS

        
    }
}
