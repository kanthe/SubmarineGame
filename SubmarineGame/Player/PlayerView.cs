/*******************************************************************************************************/
// File:    PlayerView.cs
// Summary: Triggered by MasterControllers "Draw" method. Creates view elements, used for drawing 
// certain features. Then triggeres their draw methods.
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Model;

namespace View
{
    class PlayerView
    {
        Texture2D playerTexture;
        int scale;
        GraphicsDevice device;
        ContentManager content;
        Camera camera;

        public PlayerView(int scale, GraphicsDevice device, ContentManager content, Camera camera)
        {
            this.scale = scale;
            this.device = device;
            this.content = content;
            this.camera = camera;
            playerTexture = new Texture2D(device, 1, 1);
            playerTexture.SetData(new[] { Color.White });

        }

        public void DrawPlayer(Player player, SpriteBatch spriteBatch)
        {
            Vector2 playerViewPosition = camera.modelPositionToViewPosition(player.Position);
            int playerSize = camera.scaleObject(player.Size);

            spriteBatch.Draw(playerTexture,
                new Rectangle((int)playerViewPosition.X - playerSize / 2, (int)playerViewPosition.Y - playerSize / 2, playerSize, playerSize),
                Color.Green
                    );
        }
    }
}
