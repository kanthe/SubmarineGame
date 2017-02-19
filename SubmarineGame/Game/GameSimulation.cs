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
        Timer touchGroundTimer = new Timer(1.0f);

        public GameSimulation()
        {
            movement = new Movement();
            level = 1;
            player = new Player(new Vector2(0.3f, 0.3f));
            map = new MapL1(player);
        }

        // UPDATE

        public void Update(GameTime gameTime)
        {
            // The gametime step in seconds
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // PLAYER GRAVITY MOVEMENT
            player.Position = movement.down(player.Position, Movement.GRAVITY / 2, deltaTime);
            // PLAYER TOUCH GROUND
            didPlayerTouchGround(deltaTime);
            // PLAYER TOUCH MOUNTAIN
            foreach (Mountain mountain in Map.Mountains)
            {
                for (int i = 1; i < mountain.YPositionsHigh.Length; i++) {
                    if (Mathematics.IsInsideRectangle(player.Position, player.Size, mountain.LowPositions[i], 
                        0.01f, mountain.YPositionsHigh[i] - mountain.LowPositions[i].Y))
                    {
                        player.IsHit(10);
                    }
                }
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
            // ENEMIES
            for (int i = map.Enemies.Count - 1; i >= 0; i--)
            {
                BaseEnemy enemy = map.Enemies[i];
                enemyLaunchAndMoveWeapons(map.Enemies[i]);
                weaponsHitEnemy(enemy);
                enemyMove(enemy);
            }
            
            if(player.IsGameOver())
            {
                player.Color = Color.Black;
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

        public void didPlayerTouchGround(float deltaTime)
        {
            touchGroundTimer.runTimer(deltaTime);

            for (int i = 0; i < map.Ground.Length; i++)
            {
                if (Mathematics.IsInsideRectangle(player.Position, player.Size, map.Ground[i], 0.01f, map.Ground[i].Y)
                    && touchGroundTimer.getTime() > touchGroundTimer.getResetTime())
                {
                    player.IsHit(10);
                    touchGroundTimer.resetTimer();
                    break;
                }
            }
        }

        // ENEMY MOVE

        public void enemyMove(BaseEnemy enemy)
        {
            enemy.Position = movement.backward(enemy.Position, enemy.Speed, deltaTime);

            if (enemy.Position.X < 0)
            {
                map.Enemies.Remove(enemy);
            }
            else if (Mathematics.IsInsideCircle(player.Position, player.Size, enemy.Position, enemy.Size))
            {
                player.HitPoints -= enemy.CrashDamage;
                map.Enemies.Remove(enemy);
            }
        }

        // WEAPONS

        public void playerLaunchTorpedo(bool torpedoButtonPressed)
        {
            player.TorpedoLauncher.LaunchTorpedo(player.Position, torpedoButtonPressed, deltaTime);
        }
        public void playerLaunchDropBomb(bool dropBombButtonPressed)
        {
            player.DropBombLauncher.LaunchDropBomb(player.Position, player.Speed / 3, dropBombButtonPressed, deltaTime);
        }
        public void playerLaunchElectroBeam(bool electroButtonPressed)
        {
            player.ElectroLauncher.LaunchElectroBeam(player.Position + new Vector2(player.Size / 2, 0), electroButtonPressed, deltaTime);
        }

        public void weaponsHitEnemy(BaseEnemy enemy)
        {
            for (int i = player.TorpedoLauncher.Torpedos.Count - 1; i >= 0; i--)
            {
                Torpedo torpedo = player.TorpedoLauncher.Torpedos[i];

                if (Mathematics.IsInsideCircle(torpedo.Position, torpedo.Size, enemy.Position, enemy.Size)) 
                {
                    enemy.IsHit(torpedo.Damage);
                    player.TorpedoLauncher.Torpedos.Remove(torpedo);
                }
            }
            for (int i = player.DropBombLauncher.DropBombs.Count - 1; i >= 0; i--)
            {
                DropBomb dropBomb = player.DropBombLauncher.DropBombs[i];

                if (Mathematics.IsInsideCircle(dropBomb.Position, dropBomb.Size, enemy.Position, enemy.Size))
                {
                    enemy.IsHit(dropBomb.Damage);
                    player.DropBombLauncher.DropBombs.Remove(dropBomb);
                }
            }
            ElectroBeam eBeam = player.ElectroLauncher.ElectroBeam;

            if (eBeam != null && Mathematics.IsInsideRectangle(enemy.Position, enemy.Size, eBeam.Position, eBeam.Width, eBeam.Height))
            {
                bool reachedResetTime = enemy.ElectroDamageTimer.runTimer(deltaTime);

                if(reachedResetTime)
                {
                    enemy.IsHit(eBeam.Damage);
                    enemy.ElectroDamageTimer.resetTimer();
                }
            }

            if (enemy.HitPoints <= 0)
            {
                map.Enemies.Remove(enemy);
            }
            eBeam = null;
        }

        public void enemyLaunchAndMoveWeapons(BaseEnemy enemy)
        {
            enemy.Fire(deltaTime);
            enemy.MoveWeapons(deltaTime, movement);
            int damage = enemy.DidWeaponHitPlayer(player.Position, player.Size);

            if(damage > 0)
            {
                player.IsHit(damage);
            }
        }

        public bool weaponHitPlayer(Vector2 position, float size)
        {
            bool playerIsHit = false;

            if(Mathematics.IsInsideCircle(player.Position, player.Size, position, size))
            {
                playerIsHit = true;
            }
            return playerIsHit;
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

        #region Properties
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
        #endregion
    }
}

