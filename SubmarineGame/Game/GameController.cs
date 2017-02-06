/*******************************************************************************************************/
// File:    GameController.cs
// Summary: GameController is the "motor" of the game. When updated from MasterController it controls 
// the movement and actions of player and enemies. AAlso controlls when messages and shown and all 
// actions in game, triggered by the keyboard.
// Version: Version 1.0 - 2016-06-24
// Author:  Robin Kanthe
// Email:   kanthe.robin@gmail.com
// -------------------------------------------
// Log:2016-06-24 Created the file. Robin Kanthe
/*******************************************************************************************************/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using View;
using Model;

namespace Controller
{
    /// <summary>
    /// Handles input from player and updates game.
    /// </summary>
    class GameController
    {
        GameSimulation gameSimulation; // Model representation of the game
        // EventListener eventListener;  // Drawing things and/or playing sounds in respons to events
        Activator pauseActivator = new Activator(); // 
        EventListener eventListener;

        public GameController(GameSimulation gameSimulation, EventListener eventListener)
        {
            this.gameSimulation = gameSimulation;
            this.eventListener = eventListener;
        }
        /// <summary>
        /// Updates the players AND enemies movement and actions.
        /// </summary>
        /// <param name="gameTime"> GameTime object containing total time of game, time since last update, etc.</param>
        /// 
        public void Update(GameTime gameTime)
        {
            // Get the current gamepad state.
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);

            // Space: PAUSE

            bool pauseButtonPressed = Keyboard.GetState().IsKeyDown(Keys.Space) || currentState.IsConnected && currentState.Buttons.Start == ButtonState.Pressed;
            bool pause = pauseActivator.activateDeactivateOnRelease(pauseButtonPressed);

            // Makes all the updates if pause is not activated or if the message object do not give pause intructions when playing a message
            if (!pause)
            {
                /*
                 ********************************************************************************
                 * CONTROLS PLAYER                                                             *
                 ********************************************************************************
                 */
                gameSimulation.Update(gameTime);

                //
                // MOVE FORWARD
                //
                if (Keyboard.GetState().IsKeyDown(Keys.Right) || currentState.IsConnected && currentState.ThumbSticks.Left.X > 0.2f)
                {
                    gameSimulation.movePlayerForward();
                    // Exposions makes illusion of rocket exhause
                    // eventListener.MakeExplosion(player.getPosition() - player.getDirection() * Player.DIAMETER * 3 / 4, gameTime, 0.2f, 10.0f, 10.0f, 50.0f, 0.1f, 3.0f);
                }
                //
                // MOVE BACKWARD
                //
                if (Keyboard.GetState().IsKeyDown(Keys.Left) || currentState.IsConnected && currentState.ThumbSticks.Left.X < -0.2f)
                {
                    
                    if (gameSimulation.Player.Position.X > 0)
                    {
                        gameSimulation.movePlayerBackward();
                        // Exposions makes illusion of rocket exhause
                        // eventListener.MakeExplosion(player.getPosition() - player.getDirection() * Player.DIAMETER * 3 / 4, gameTime, 0.2f, 10.0f, 10.0f, 50.0f, 0.1f, 3.0f);
                    }
                    
                }
                //
                // MOVE UP
                //
                if (Keyboard.GetState().IsKeyDown(Keys.Up) || currentState.IsConnected && currentState.ThumbSticks.Left.Y > 0.2f)
                {
                    gameSimulation.movePlayerUp();
                    // Exposions makes illusion of rocket exhause
                    // eventListener.MakeExplosion(player.getPosition() - player.getDirection() * Player.DIAMETER * 3 / 4, gameTime, 0.2f, 10.0f, 10.0f, 50.0f, 0.1f, 3.0f);
                }
                //
                // MOVE DOWN
                //
                if (Keyboard.GetState().IsKeyDown(Keys.Down) || currentState.IsConnected && currentState.ThumbSticks.Left.Y < -0.2f)
                {
                    gameSimulation.movePlayerDown();
                    // Exposions makes illusion of rocket exhause
                    // eventListener.MakeExplosion(player.getPosition() - player.getDirection() * Player.DIAMETER * 3 / 4, gameTime, 0.2f, 10.0f, 10.0f, 50.0f, 0.1f, 3.0f);
                }

                /*
                 ********************************************************************************
                 * WEAPONS / ABILITIES                                                          *
                 ********************************************************************************
                 */
                
                //
                // Shoot TORPEDO
                //
                // True if player presses the fire button. That does not mean a beam is fired, since 
                // beam is only fired once when pressing the fire button, not one every time step, "deltaTime".
                bool fireButtonPressed = Keyboard.GetState().IsKeyDown(Keys.Q) || currentState.IsConnected && currentState.Buttons.A == ButtonState.Pressed;
                gameSimulation.playerLaunchTorpedo(fireButtonPressed);
                // Beam sound
                /*
                if (playerShootBeams)
                {
                    eventListener.playPlayerBeamSound();
                }
                 */
                //
                // Shoot DROPBOMB
                //
                bool dropBombButtonPressed = Keyboard.GetState().IsKeyDown(Keys.W) || currentState.IsConnected && currentState.Buttons.A == ButtonState.Pressed;
                gameSimulation.playerLaunchDropBomb(dropBombButtonPressed);

                //
                // Shoot ELECTRO BEAM
                //
                bool electroButtonPressed = Keyboard.GetState().IsKeyDown(Keys.E) || currentState.IsConnected && currentState.Buttons.A == ButtonState.Pressed;
                gameSimulation.playerLaunchElectroBeam(electroButtonPressed);
                
                // Moving PLAYERS BEAMS. All beams are stored in the BeamWeapon object until deleted (at window boundaries, if it hits an enemy
                // or outside map boundary.
                /*
                for (int index = Player.BEAM_WEAPON.getBeams().Count - 1; index >= 0; index--)
                {
                    BeamModel beam = Player.BEAM_WEAPON.getBeams()[index];
                    if (Geometry.AbsoluteValue(beam.getPosition()) > gameSimulation.getMap().getBorderRadius() * 0.999f)
                    {
                        Player.BEAM_WEAPON.getBeams().RemoveAt(index);
                    }
                    Vector2 beamPosition = player.getMovement().move(beam.getPosition(), beam.getSpeed(), beam.getDirection(), gameSimulation.getMap().getBorderRadius(), deltaTime);
                    beam.setPosition(beamPosition);

                    // ENEMY IS HIT by players beam. 

                    for (int count = gameSimulation.getMap().getEnemies().Count - 1; count >= 0; count--)
                    {
                        EnemyTemplate enemy = gameSimulation.getMap().getEnemies()[count];

                        if (Geometry.IsInsideCircle(beam.getPosition(), 0, enemy.getPosition(), enemy.getDiameter()))
                        {
                            enemy.isHit(beam.getBeamDamage());
                            Player.BEAM_WEAPON.getBeams().Remove(beam);
                        }
                    }
                }
                 * */
                /*
                 ********************************************************************************
                 * ENEMIES                                                                      *
                 ********************************************************************************
                 */
                /*
                System.Collections.Generic.List<EnemyTemplate> enemies = gameSimulation.getMap().getEnemies(); // All enemies

                for (int count = enemies.Count - 1; count >= 0; count--)
                {
                    // ENEMIES MOVE

                    // Follows player: Direction and distance to player is calculated

                    EnemyTemplate enemy = enemies[count];
                    Vector2 initPos = enemy.getPosition();

                    if (enemy.getPosition().X < 1.5f)
                    {
                        gameSimulation.getMovement().backward(enemy.getPosition(), enemy.getSpeed());
                    }
                    if (enemy.getPosition().X - player.getPosition().X < -0.1f)
                    {
                        enemies.Remove(enemy);
                    }

                    // ENEMIES SMOKE

                    float D = enemy.getDiameter();

                    if ((float)enemy.getHitPoints() / enemy.getMaxHitPoints() > 0.3f && (float)enemy.getHitPoints() / enemy.getMaxHitPoints() < 0.7f)
                    {
                        eventListener.MakeSmoke(enemy.getPosition(), 15.0f, 50 * D, 250 * D);
                    }
                    // More smoke if more damaged
                    else if ((float)enemy.getHitPoints() / enemy.getMaxHitPoints() > 0 && (float)enemy.getHitPoints() / enemy.getMaxHitPoints() < 0.3f)
                    {
                        eventListener.MakeSmoke(enemy.getPosition(), 15.0f, 100 * D, 500 * D);
                    }

                    // ENEMIES CRASH

                    if (Geometry.IsInsideCircle(player.getPosition(), Player.DIAMETER, enemy.getPosition(), enemy.getDiameter()))
                    {
                        enemy.crash();
                        player.crash();
                    }

                    // ENEMIES DIE

                    if (enemy.getHitPoints() <= 0)
                    {
                        enemies.Remove(enemy);
                        eventListener.removeSmoke();
                    }
                }

                // MOVE ENEMY BEAMS

                for (int index = gameSimulation.getMap().getEnemyBeams().Count - 1; index >= 0; index--)
                {
                    BeamModel beam = gameSimulation.getMap().getEnemyBeams()[index];
                    Vector2 beamPosition = beam.getPosition() + beam.getSpeed() * beam.getDirection() * deltaTime;
                    beam.setPosition(beamPosition);

                    // PLAYER IS HIT

                    if (Geometry.IsInsideCircle(beam.getPosition(), 0, player.getPosition(), Player.DIAMETER * 1.5f))
                    {
                        player.isHit(beam.getBeamDamage()); // Player is hit
                        eventListener.StartShieldAnimation();
                        eventListener.playPlayerHitSound(); // Plays soft sound
                        gameSimulation.getMap().getEnemyBeams().Remove(beam);
                        eventListener.MakeExplosion(player.getPosition(), gameTime, 0.1f, 10.0f, 0.0f, 10.0f, 0.3f, 3.0f);
                    }
                }
                */
                /*
                 ********************************************************************************
                 * OVERALL GAME FUNCTIONS                                                       *
                 ********************************************************************************
                 */

                /*

                // GAMEOVER: Testing if player is dead
                if (player.getHitPoints() < player.getMinHitPoints())
                {
                    gameSimulation.setMessage(Message.GameOver);
                }

                // ADVANCE LEVEL
                if (gameSimulation.getNumberOfVisitedPlanets() == gameSimulation.getTotalNumberOfPlanets())
                {
                    gameSimulation.setMessage(Message.LevelComplete);
                }

                // SKIP LEVEL
                if (skipLevelActivator.activeOneTimeStep(Keyboard.GetState().IsKeyDown(Keys.H))) // || currentState.IsConnected && currentState.DPad.Right == ButtonState.Pressed))
                {
                    gameSimulation.skipLevel();
                }
                // GO BACK TO LEVEL
                if (reverseLevelActivator.activeOneTimeStep(Keyboard.GetState().IsKeyDown(Keys.G))) // || currentState.IsConnected && currentState.DPad.Left == ButtonState.Pressed) && gameSimulation.getLevel() >= 2)
                {
                    gameSimulation.reverseLevel();
                }
                gameSimulation.advanceLevel();
                gameSimulation.restartLevel();

                // CHEAT (stays until reloading game)

                if (Keyboard.GetState().IsKeyDown(Keys.L))
                {
                    player.setMinHitPoints(-10000);
                    player.setMovement(new Movement(Player.ACCELERATION, Player.MIN_SPEED, 0.5f, Player.ROTATION_SPEED));
                    Player.BEAM_WEAPON.setAutoFireState(AutoFireState.NotLoaded);
                    Player.MISSILE_WEAPON.setMissileState(MissileState.NotLoaded);
                    Player.SHIELD.setShieldState(ShieldState.Unpowered);
                    Player.FURY_MODE.setFuryState(FuryState.NotLoaded);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.K))
                {
                    player.setMinHitPoints(-10000);
                    player.setMovement(new Movement(Player.ACCELERATION, Player.MIN_SPEED, 0.5f, Player.ROTATION_SPEED));
                    Player.BEAM_WEAPON.setAutoFireState(AutoFireState.NotLoaded);
                    Player.MISSILE_WEAPON.setMissileState(MissileState.OffPlayer);
                    Player.FURY_MODE.setFuryState(FuryState.OffPlayer);
                }
                */
            }
        }
    }
}


