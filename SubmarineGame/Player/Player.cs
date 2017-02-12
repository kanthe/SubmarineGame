/*******************************************************************************************************/
// File:    Player.cs
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

namespace Model
{
    class Player
    {
        Vector2 position;
        float speed = 0.1f;
        Color color = Color.Black;
        float size = 0.04f;
        TorpedoLauncher torpedoLauncher = new TorpedoLauncher();
        DropBombLauncher dropBombLauncher = new DropBombLauncher();
        ElectroLauncher electroLauncher = new ElectroLauncher();


        public TorpedoLauncher TorpedoLauncher
        {
            get { return torpedoLauncher; }
            set { torpedoLauncher = value; }
        }

        public DropBombLauncher DropBombLauncher
        {
            get { return dropBombLauncher; }
            set { dropBombLauncher = value; }
        }

        public ElectroLauncher ElectroLauncher
        {
            get { return electroLauncher; }
            set { electroLauncher = value; }
        }

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Player(Vector2 position)
        {
            this.position = position;
        }
    }
}
