/*******************************************************************************************************/
// File:    TorpedoView.cs
// Summary: Triggered by MasterControllers "Draw" method. Creates view elements, used for drawing 
// certain features. Then triggeres their draw methods.
// Version: Version 1.0 - 2016-06-26
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-26 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Model;

namespace View
{
    class TorpedoView
    {
        Texture2D torpedoTexture;
        int scale;
        GraphicsDevice device;
        ContentManager content;
        Camera camera;

        public TorpedoView(int scale, GraphicsDevice device, ContentManager content, Camera camera)
        {
            this.scale = scale;
            this.device = device;
            this.content = content;
            this.camera = camera;
            torpedoTexture = new Texture2D(device, 1, 1);
            torpedoTexture.SetData(new[] { Color.White });

        }

        public void DrawTorpedo(Torpedo torpedo, SpriteBatch spriteBatch)
        {
            Vector2 torpedoViewPosition = camera.modelPositionToViewPosition(torpedo.Position);
            int diameter = (int)camera.scaleObject(torpedo.Size);
            torpedoViewPosition = camera.putPositionInCentre(torpedoViewPosition, diameter);

            spriteBatch.Draw(torpedoTexture,
                new Rectangle((int)torpedoViewPosition.X, (int)torpedoViewPosition.Y, diameter, diameter),
                torpedo.Color
                    );
        }
    }
}
