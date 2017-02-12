/*******************************************************************************************************/
// File:    ElectroView.cs
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
    class ElectroView
    {
        Texture2D electroTexture;
        int scale;
        GraphicsDevice device;
        ContentManager content;
        Camera camera;

        public ElectroView(int scale, GraphicsDevice device, ContentManager content, Camera camera)
        {
            this.scale = scale;
            this.device = device;
            this.content = content;
            this.camera = camera;
            electroTexture = new Texture2D(device, 1, 1);
            electroTexture.SetData(new[] { Color.White });

        }

        public void DrawElectroBeam(ElectroBeam electroBeam, SpriteBatch spriteBatch)
        {
            Vector2 electroViewPosition = camera.modelPositionToViewPosition(electroBeam.Position);
            int electroViewHeight = (int)camera.scaleObject(electroBeam.Height);
            int electroViewWidth = (int)camera.scaleObject(electroBeam.Width);

            spriteBatch.Draw(electroTexture,
                new Rectangle((int)electroViewPosition.X, (int)electroViewPosition.Y, electroViewWidth, electroViewHeight),
                electroBeam.Color
                    );
        }
    }
}
