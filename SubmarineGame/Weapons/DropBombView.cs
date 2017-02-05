/*******************************************************************************************************/
// File:    DropBombView.cs
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
    class DropBombView
    {
        Texture2D dropBombTexture;
        int scale;
        GraphicsDevice device;
        ContentManager content;
        Camera camera;

        public DropBombView(int scale, GraphicsDevice device, ContentManager content, Camera camera)
        {
            this.scale = scale;
            this.device = device;
            this.content = content;
            this.camera = camera;
            dropBombTexture = new Texture2D(device, 1, 1);
            dropBombTexture.SetData(new[] { Color.White });

        }

        public void DrawDropBomb(DropBomb dropBomb, SpriteBatch spriteBatch)
        {
            Vector2 dropBombViewPosition = camera.modelPositionToViewPosition(dropBomb.Position);
            int dropBombViewSize = (int)camera.scaleObject(dropBomb.Size);

            spriteBatch.Draw(dropBombTexture,
                new Rectangle((int)dropBombViewPosition.X, (int)dropBombViewPosition.Y, dropBombViewSize, dropBombViewSize),
                dropBomb.Color
                    );
        }
    }
}
