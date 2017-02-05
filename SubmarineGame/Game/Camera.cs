/*******************************************************************************************************/
// File:    Camera.cs
// Summary: Interface between model and view. Tranlating model coordinates/lengths to view 
// coordinates/lengths and vice versa. 
// Version: Version 1.0 - 2016-01-12
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-01-12 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;

namespace View
{
    /// <summary>
    /// Transforming model coordinates to coordinates of viewing window
    /// </summary>
    class Camera
    {
        float scale;
        Vector2 viewDisplacement;
        float displacementFactor;

        public Camera(int scale)
        {
            // One model unit i pixels. The window height is used as scale in this simulation
            this.scale = (float)scale;
            displacementFactor = 2.0f;
            viewDisplacement = new Vector2(0, 0);
        }
        /// <summary>
        /// Calculating the displacement when centering view on a certain position.
        /// Used in methods below to calculate model and view positions.
        /// </summary>
        public void centerOn(Vector2 modelPosition)
        {
            // Calculating displacement when moving a position to centre of the screen and adding the side bar.
            viewDisplacement.X = scale / displacementFactor - modelPosition.X * scale;
        }

        /// <summary>
        /// Transforming model coordinates to view coordinates
        /// </summary>
        /// <param name="modelPosition">Position in model coordinates</param>
        /// <returns>Position in view coordinates</returns>
        public Vector2 modelPositionToViewPosition(Vector2 modelPosition)
        {
            Vector2 viewPosition;
            viewPosition.X = modelPosition.X * scale + viewDisplacement.X;
            viewPosition.Y = -modelPosition.Y * scale + scale;

            return viewPosition;
        }

        /// <summary>
        /// Transforming view coordinates to model coordinates
        /// </summary>
        /// <param name="viewPosition">Position in view coordinates</param>
        /// <returns>Position in model coordinates</returns>
        public Vector2 viewPositionToModelPosition(Vector2 viewPosition)
        {
            Vector2 modelPosition;
            modelPosition.X = (viewPosition.X - viewDisplacement.X) / scale;
            modelPosition.Y = -(viewPosition.Y - viewDisplacement.X) / scale;

            return modelPosition;
        }

        /// <summary>
        /// Transforming a length in model coordinates to view coordinates
        /// </summary>
        public int scaleObject(float length)
        {
            int scaledObject = (int)(length * scale);

            return scaledObject;
        }
        /// <summary>
        /// Transforming a length in model coordinates to view coordinates
        /// </summary>
        public void zoom(float percent, Vector2 modelPosition)
        {
            scale = scale / percent * 100.0f;
            displacementFactor = displacementFactor * 100.0f / percent;
        }
        public void setScale(int scale) { this.scale = (float)scale; }
        public void setDisplacementFactor(float displacementFactor) { this.displacementFactor = (float)displacementFactor; }
    }

        
}
