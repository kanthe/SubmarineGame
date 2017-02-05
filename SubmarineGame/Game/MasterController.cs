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
using View;
using Model;

namespace Controller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;

        int scale; // Standard length used to translate between model coordinates/lengths and view coordinates/lengths
        SpriteBatch spriteBatch; // Creates a new SpriteBatch, which is used to draw all textures
        GameView gameView; // Visual representation of game.
        GameSimulation gameSimulation; // Model representation of game.
        GameController gameController; // Updates game and handling player input
        EventListener eventListener;  // Drawing things and/or playing sounds in respons to events
        public GameTime gameTime; // Time object used for measuring game time and game time steps

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (int)GameView.WINDOWSIZE.X;
            graphics.PreferredBackBufferHeight = (int)GameView.WINDOWSIZE.Y;
            scale = (int)GameView.WINDOWSIZE.Y;
            Content.RootDirectory = "Content";
            gameSimulation = new GameSimulation();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            // Creating a "gameController" object, which handles input from player 
            //  and updates game.
            gameController = new GameController(gameSimulation, eventListener);
            gameSimulation.GameState = GameState.NewGame;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            // Making objects, drawing things and/or playing sounds in respons to events

            eventListener = new EventListener(scale, GraphicsDevice, Content);
            // GameView object creates visual representation of game objects and loads content.
            gameView = new GameView(gameSimulation, GraphicsDevice, Content, eventListener);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;

            // Takes different actions depending on GAME STATE
            switch (gameSimulation.GameState)
            {
                case GameState.NewGame:
                    gameSimulation.reset();
                    //gameController = new GameController(gameSimulation, eventListener, messages);
                    gameView = new GameView(gameSimulation, GraphicsDevice, Content, eventListener);
                    break;
                case GameState.Continue: // CONTINUE updates game
                    gameController.Update(gameTime);
                    break;
                // When new game is started: New GameSimulation and GameController objects are created.
                // gameSimulation resets, meaning a lot of its objects are recreated
                // Tutorial state is handled to gameSimulation
                case GameState.Exit: // Exits the game
                    Exit();
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // The gametime step in seconds
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            gameView.DrawGame(gameTime, spriteBatch); // Draws game.

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
