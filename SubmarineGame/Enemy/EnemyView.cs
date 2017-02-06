using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Model;

namespace View
{
    class EnemyView
    {
        Texture2D enemyTexture;
        int scale;
        GraphicsDevice device;
        ContentManager content;
        Camera camera;
        SpriteBatch spriteBatch;

        public EnemyView(int scale, GraphicsDevice device, ContentManager content, Camera camera)
        {
            this.scale = scale;
            this.device = device;
            this.content = content;
            this.camera = camera;
            enemyTexture = new Texture2D(device, 1, 1);
            enemyTexture.SetData(new[] { Color.White });
        }

        public void draw(IEnemy enemy, SpriteBatch spriteBatch) 
        {
            Vector2 enemyViewPosition = camera.modelPositionToViewPosition(enemy.Position);
            int size = camera.scaleObject(enemy.Size);
            spriteBatch.Draw(enemyTexture, new Rectangle((int)enemyViewPosition.X, (int)enemyViewPosition.Y, size, size), enemy.Color);
        }

    }
}
