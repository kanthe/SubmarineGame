/*******************************************************************************************************/
// File:    GameSimulation.cs
// Summary: Creates the player and maps and thus setting up initial condition of the game. Also reseting
// initial conditions when restarting game and keep track of current level.
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;

namespace Model
{
    /// <summary>
    /// Creating the main object models, which are visual in the game, map and player. 
    /// </summary>
    public enum GameState { NewGame, Continue, Exit } // All different states of the game

    class GameSimulation
    {
        GameState gameState; // State of the game
        Movement movement;
        float deltaTime;
        Player player;
        int level;
        MapL1 map;
        // MapTemplate map; // The model representation of the map.

        // GET / SET METHODS

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public GameState GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }

        public Movement Movement
        {
            get { return movement; }
            set { movement = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public MapL1 Map
        {
            get { return map; }
            set { map = value; }
        }

        // Player player; // The model representation of the player.

        public GameSimulation()
        {
            movement = new Movement();
            // Initial conditions
            level = 1;
            player = new Player(new Vector2(0.3f, 0.3f)); // The player
            map = new MapL1(player); // The Map (initially first level)
        }

        // UPDATE

        public void Update(GameTime gameTime)
        {
            // The gametime step in seconds
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // GRAVITY MOVEMENT
            player.Position = movement.down(player.Position, Movement.GRAVITY / 2, deltaTime);
            // ENEMIES MOVEMENT
            for (int i = map.Enemies.Count - 1; i >= 0; i--)
            {
                moveEnemy(map.Enemies[i]);
            }
            // PLAYERS WEAPONS
            foreach (Torpedo torpedo in player.TorpedoLauncher.Torpedos)
            {
                torpedo.Position = movement.forward(torpedo.Position, torpedo.Speed, deltaTime);
            }
            foreach (DropBomb dropBomb in player.DropBombLauncher.DropBombs)
            {
                dropBomb.Position = movement.forward(dropBomb.Position, dropBomb.Speed, deltaTime);
                dropBomb.Position = movement.down(dropBomb.Position, Movement.GRAVITY, deltaTime);
            }
            // WEAPONS HIT ENEMIES 
            for (int i = map.Enemies.Count - 1; i >= 0; i--)
            {
                weaponsHitEnemy(map.Enemies[i]);
            }
        }

        // PLAYER MOVES

        public void movePlayerForward()
        {
            player.Position = movement.forward(player.Position, player.Speed, deltaTime);
        }
        public void movePlayerBackward()
        {
            player.Position = movement.backward(player.Position, player.Speed, deltaTime);
        }
        public void movePlayerUp()
        {
            player.Position = movement.up(player.Position, player.Speed, deltaTime);
        }
        public void movePlayerDown()
        {
            player.Position = movement.down(player.Position, player.Speed, deltaTime);
        }

        // ENEMIES MOVE

        public void moveEnemy(IEnemy enemy)
        {
            enemy.Position = movement.backward(enemy.Position, enemy.Speed, deltaTime);
        }

        // WEAPONS

        public void playerLaunchTorpedo(bool torpedoButtonPressed)
        {
            player.TorpedoLauncher.LaunchTorpedo(player.Position, torpedoButtonPressed);
        }
        public void playerLaunchDropBomb(bool dropBombButtonPressed)
        {
            player.DropBombLauncher.LaunchDropBomb(player.Position, player.Speed / 3, dropBombButtonPressed);
        }
        public void playerLaunchElectroBeam(bool electroButtonPressed)
        {
            player.ElectroLauncher.LaunchElectroBeam(player.Position + new Vector2(player.Size / 2, 0), electroButtonPressed, deltaTime);
        }
        public void weaponsHitEnemy(IEnemy enemy)
        {
            for (int i = player.TorpedoLauncher.Torpedos.Count - 1; i >= 0; i--)
            {
                Torpedo torpedo = player.TorpedoLauncher.Torpedos[i];

                if (Mathematics.IsInsideCircle(torpedo.Position, torpedo.Size, enemy.Position, enemy.Size)) 
                {
                    enemy.isHit(torpedo.Damage);
                    player.TorpedoLauncher.Torpedos.Remove(torpedo);
                }
            }
            for (int i = player.DropBombLauncher.DropBombs.Count - 1; i >= 0; i--)
            {
                DropBomb dropBomb = player.DropBombLauncher.DropBombs[i];

                if (Mathematics.IsInsideCircle(dropBomb.Position, dropBomb.Size, enemy.Position, enemy.Size))
                {
                    enemy.isHit(dropBomb.Damage);
                    player.DropBombLauncher.DropBombs.Remove(dropBomb);
                }
            }
            ElectroBeam eBeam = player.ElectroLauncher.ElectroBeam;

            if (eBeam != null && Mathematics.IsInsideRectangle(enemy.Position, enemy.Size, eBeam.Position, eBeam.Width, eBeam.Height))
            {
                bool reachedResetTime = enemy.DamageTimer.runTimer(deltaTime);
                System.Console.WriteLine(enemy.DamageTimer.getTime());

                if(reachedResetTime)
                {
                    enemy.isHit(eBeam.Damage);
                    enemy.DamageTimer.resetTimer();
                }
            }

            if (enemy.HitPoints <= 0)
            {
                map.Enemies.Remove(enemy);
            }
            eBeam = null;
        }

        // ADVANCE LEVEL

        public void advanceLevel()
        {
            gameState = GameState.NewGame;
        }

        public void skipLevel() // (Triggered by key)
        {
            level++;
            gameState = GameState.NewGame;
        }

        public void reverseLevel() // (Triggered by key)
        {
            level--;
            gameState = GameState.NewGame;
        }

        public void restartLevel()
        {
            gameState = GameState.NewGame;
        }
        /// <summary>
        /// Sets game back to initial conditions (except possibly a new level)
        /// </summary>
        public void reset()
        {
            gameState = GameState.Continue;
            /*
            player = new Player(new Vector2(0.01f, 0.01f));

            switch (level)
            {
                case 1:
                    map = new MapL1(player);
                    break;
                case 2:
                    map = new MapL2(player);
                    break;
            }
            */
        }
    }
}

