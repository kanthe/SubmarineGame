/*******************************************************************************************************/
// File:    GameView.cs
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
    /// <summary>
    /// Creating visual representation of the game.
    /// </summary>
    class GameView
    {
        public static readonly Vector2 WINDOWSIZE = new Vector2(1000, 1000); // Size of game window.

        GameSimulation gameSimulation; // Model representation of the game.
        int scale; // One model unit in pixels.
        GraphicsDevice device;
        ContentManager content;
        public static Camera camera;
        EventListener eventListener; // Reakts on events, i.e. playing sound when a button is pressed
        MapView mapView; // Visual representation of the Map
        PlayerView playerView; // Visual representation of the player.
        DropBombView dropBombView;
        TorpedoView torpedoView;
        ElectroView electroView;

        // EnemyView enemyView; // Visual representation of an enemy

        public GameView(GameSimulation gameSimulation, GraphicsDevice device, ContentManager content, EventListener eventListener)
        {
            this.gameSimulation = gameSimulation;
            this.scale = (int)WINDOWSIZE.Y; // Hight of the window is used as scale
            this.device = device;
            this.content = content;
            this.eventListener = eventListener;
            camera = new Camera(scale);

            playerView = new PlayerView(scale, device, content, camera);
            torpedoView = new TorpedoView(scale, device, content, camera);
            electroView = new ElectroView(scale, device, content, camera);
            dropBombView = new DropBombView(scale, device, content, camera);
            // enemyView = new EnemyView(scale, device, content);
            mapView = new MapView(gameSimulation.Map, scale, device, content, camera);
        }

        //DRAWS GAME

        public void DrawGame(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // The gametime step in seconds
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // BACKGROUND

            // Setting background color
            device.Clear(Color.CornflowerBlue);

            // MAP

            // MapView has methods to draw most game elements
            mapView.drawMap(spriteBatch);

            // ---------
            // PLAYER
            // ---------

            Player player = gameSimulation.Player;
            // The View is centered on the player
            // Everything drawn below will be drawn with respect to player
            camera.centerOn(player.Position); // - new Vector2(Player.DIAMETER / 2, Player.DIAMETER / 2));

            // Position on view (screen) coordinates
            // Vector2 playerViewPosition = camera.modelPositionToViewPosition(player.getPosition());

            // Draws PLAYER

            playerView.DrawPlayer(player, spriteBatch);

            foreach (Torpedo torpedo in player.TorpedoLauncher.Torpedos)
            {
                torpedoView.DrawTorpedo(torpedo, spriteBatch);
            }
            foreach (DropBomb dropBomb in player.DropBombLauncher.DropBombs)
            {
                dropBombView.DrawDropBomb(dropBomb, spriteBatch);
            }
            if (player.ElectroLauncher.ElectroBeam != null)
            {
                electroView.DrawElectroBeam(player.ElectroLauncher.ElectroBeam, spriteBatch);
            }

            // ENEMIES

            // Draws enemies
            // System.Collections.Generic.List<EnemyTemplate> enemies = gameSimulation.getMap().getEnemies();
            mapView.drawEnemies(spriteBatch);

            // EXPLOSIONS AND SMOKE

            // eventListener.UpdateExplosions(gameTime, spriteBatch, deltaTime);
            // eventListener.UpdateSmoke(spriteBatch, deltaTime);

            

            // SHOW MESSAGE

        }
    }
}
