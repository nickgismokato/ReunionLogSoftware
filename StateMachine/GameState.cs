using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ReunionLogSoftware.States{
    public abstract class GameState : IState{
        protected GraphicsDevice _graphicsDevice;
        public GameState(GraphicsDevice graphicsDevice){
            _graphicsDevice = graphicsDevice;
        }
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Initialize();

        public abstract void LoadContent(ContentManager content);

        public abstract void UnloadContent();

        public abstract void Update(GameTime gameTime);
    }
}