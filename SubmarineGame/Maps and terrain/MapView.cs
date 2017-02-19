/*******************************************************************************************************/
// File:    MasterController.cs
// Summary: Creates and initiates main elements of the game, such as gameView (draws the game), 
// gameController(handles actions and movement), gameSimulation (created and handles maps and player).§
// Also deciding actions depending on the game state.
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
    class MapView
    {
        int scale;
        GraphicsDevice device;
        ContentManager content;
        Camera camera;
        MapL1 mapModel;
        Texture2D groundTexture;
        EnemyView enemyView;

        public MapView(MapL1 mapModel, int scale, GraphicsDevice device, ContentManager content, Camera camera)
        {
            this.scale = scale;
            this.device = device;
            this.content = content;
            this.camera = camera;
            this.mapModel = mapModel;
            enemyView = new EnemyView(scale, device, content, camera);

            groundTexture = new Texture2D(device, 1, 1);
            groundTexture.SetData(new[] { Color.White });
        }

        // MAP

        public void drawMap(SpriteBatch spriteBatch)
        {
            // GROUND
            for (int i = 0; i < mapModel.Ground.Length; i++)
            {
                Vector2 groundView = camera.modelPositionToViewPosition(mapModel.Ground[i]);
                spriteBatch.Draw(groundTexture, new Rectangle((int)groundView.X, (int)groundView.Y, 5, (int)groundView.Y), Color.Brown);
            }
            // MOUNTAIN
            foreach (Mountain mountain in mapModel.Mountains)
            {
                for (int i = 0; i < mountain.YPositionsHigh.Length; i++)
                {
                    Vector2 mountainView = camera.modelPositionToViewPosition(mountain.LowPositions[i]);
                    float length = mountain.YPositionsHigh[i] - mountain.LowPositions[i].Y;
                    int viewHight = camera.scaleObject(length);
                    spriteBatch.Draw(groundTexture, new Rectangle((int)mountainView.X, (int)mountainView.Y, 20, viewHight), Color.Brown);
                }
            }
        }

        public void drawEnemies(SpriteBatch spriteBatch)
        {
            foreach (BaseEnemy enemy in mapModel.Enemies) {
                enemyView.draw(enemy, spriteBatch);
            }
        }
    }
}
