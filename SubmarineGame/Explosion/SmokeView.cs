using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Model;

namespace View
{
    /// <summary>
    /// Loads content (smoke particle) and calculating 
    /// and drawing visual representation of the simulation
    /// </summary>
    class SmokeView
    {
        SmokeSystem smokeSystem;
        Texture2D particleTexture;
        Camera camera;
        /// <summary>
        /// Constructor: Setting values of the fields
        /// </summary>
        /// <param name="smokeSystem">Simulation</param>
        /// <param name="scale">Length in pixels of one model unit</param>
        /// <param name="device"></param>
        /// <param name="content"></param>
        public SmokeView(SmokeSystem smokeSystem, int scale, GraphicsDevice device, ContentManager content)
        {
            this.smokeSystem = smokeSystem;
            particleTexture = content.Load<Texture2D>("particleSmoke"); // Texture for the smoke

            camera = GameView.camera;
        }
        /// <summary>
        /// Draws the particles of the simulation, one by one
        /// </summary>
        public void DrawSmoke(SpriteBatch spriteBatch)
        {

            foreach (SmokeParticle particle in smokeSystem.particles)
            {
                Vector2 particleViewPosition = camera.modelPositionToViewPosition(particle.getPosition());
                int particleSize = (int)particle.getSize();
                float fade = 1.0f - particleSize / smokeSystem.getMaxSize();
                Color color = new Color(fade, fade, fade, fade);
                spriteBatch.Draw(
                    particleTexture,
                    new Rectangle(
                        (int)particleViewPosition.X - particleSize / 2,
                        (int)particleViewPosition.Y - particleSize / 2,
                        particleSize,
                        particleSize
                    ),
                    null,
                    color,
                    particle.getRotationAngle(),
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0
                 );
            }

        }
    }
}
