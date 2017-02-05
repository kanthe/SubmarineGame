using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Model;

namespace View
{
    /// <summary>
    /// Loads content (explosion) and calculating 
    /// and drawing visual representation of the simulation
    /// </summary>
    class FlareView
    {
        public static readonly int numberOfTiles = 24; // Number of explosion images
        float flareSize; // Size compared to original image
        FlareSystem flareSystem;
        Texture2D flareTexture;
        GraphicsDevice device;
        Camera camera;
        Point[] flareTiles;
        /// <summary>
        /// Constructor: Setting values of the fields
        /// </summary>
        /// <param name="flareSystem">Simulation</param>
        /// <param name="scale">Height of the window is used as scale</param>
        /// <param name="device"></param>
        /// <param name="content"></param>
        public FlareView(float size, FlareSystem flareSystem, int scale, GraphicsDevice device, ContentManager content)
        {
            this.flareSize = size;
            this.flareSystem = flareSystem;
            this.device = device;
            flareTexture = content.Load<Texture2D>("explosion"); // Texture for the flare
            camera = GameView.camera;

            // Creating an array of points to the different flare images in the "explosion" texture
            flareTiles = new Point[24];
            int count = 0;

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    flareTiles[count] = new Point(flareTexture.Bounds.Width * x / 4, flareTexture.Bounds.Height * y / 8);
                    count++;
                }
            }
        }
        /// <summary>
        /// Draws the current flare
        /// </summary>
        /// <param name="flareTileNumber">Number on current flare tile</param>
        public void DrawFlare(int flareTileNumber, SpriteBatch spriteBatch)
        {
            Vector2 flareViewPosition = camera.modelPositionToViewPosition(flareSystem.getPosition());
            Point flareViewPoint = new Point((int)flareViewPosition.X, (int)flareViewPosition.Y);
            Point flareTileSize = new Point(flareTexture.Bounds.Width / 4, flareTexture.Bounds.Height / 8);
            Rectangle flareTile = new Rectangle(flareTiles[4], flareTileSize);

            spriteBatch.Draw(
                flareTexture,
                flareViewPosition,
                new Rectangle(flareTiles[flareTileNumber - 1], flareTileSize),
                Color.White,
                0,
                new Vector2(flareTexture.Bounds.Width / 8, flareTexture.Bounds.Height / 16),
                flareSize,
                SpriteEffects.None,
                0
            );
        }
    }
}
