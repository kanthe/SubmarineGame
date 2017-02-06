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

            for (int i = 0; i < mapModel.Ground.Length; i++)
            {
                Vector2 groundView = camera.modelPositionToViewPosition(mapModel.Ground[i]);
                int groundViewX = camera.scaleObject(mapModel.Ground[i].X);
                int groundViewY = camera.scaleObject(mapModel.Ground[i].Y);
                spriteBatch.Draw(groundTexture, new Rectangle((int)groundView.X, (int)groundView.Y, 10, (int)groundView.Y), Color.Brown);
            }
            Vector2 endPos = camera.modelPositionToViewPosition(new Vector2(MapL1.MAP_WIDTH, 0));
            spriteBatch.Draw(groundTexture, new Rectangle((int)endPos.X, (int)endPos.Y, 10, (int)endPos.Y + scale), Color.Brown);
            Vector2 startPos = camera.modelPositionToViewPosition(new Vector2(0, 0));
            spriteBatch.Draw(groundTexture, new Rectangle((int)startPos.X, (int)startPos.Y, 10, (int)startPos.Y), Color.Brown);
        }

        public void drawEnemies(SpriteBatch spriteBatch)
        {
            foreach (IEnemy enemy in mapModel.Enemies) {
                enemyView.draw(enemy, spriteBatch);
            }
        }
    }
}
