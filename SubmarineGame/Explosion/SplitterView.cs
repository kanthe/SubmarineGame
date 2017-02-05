using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Model;

namespace View
{
    /// <summary>
    /// Loads content (spark particle) and calculating 
    /// and drawing visual representation of the simulation
    /// </summary>
    class SplitterView
    {
        SplitterSystem splitterSystem;
        Texture2D particleTexture;
        Camera camera;
        /// <summary>
        /// Constructor: Setting values of the fields
        /// </summary>
        /// <param name="splitterSystem">Simulation</param>
        /// <param name="scale">Length in pixels of one model unit</param>
        /// <param name="device"></param>
        /// <param name="content"></param>
        public SplitterView(SplitterSystem splitterSystem, int scale, GraphicsDevice device, ContentManager content)
        {
            this.splitterSystem = splitterSystem;
            particleTexture = content.Load<Texture2D>("spark"); // Texture for the ball
            camera = GameView.camera;
        }
        /// <summary>
        /// Draws the particles of the simulation, one by one
        /// </summary>
        public void DrawSplitter(SpriteBatch spriteBatch)
        {

            for (int count = 0; count < splitterSystem.getNumberOfParticles(); count++ )
            {
                int particleSize = (int)splitterSystem.getSize();
                Vector2 particleViewPosition = camera.modelPositionToViewPosition(splitterSystem.getParticle(count).getPosition());

                spriteBatch.Draw(
                    particleTexture,
                    new Rectangle((int)particleViewPosition.X, (int)particleViewPosition.Y, particleSize, particleSize),
                    Color.White
                );
            }
            
        }
    }

    
}
