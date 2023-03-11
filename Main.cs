using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ReunionLogSoftware;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private SpriteFont testFont;
    private int i = 0;
    //private Game.Window indputTest;
    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        testFont = Content.Load<SpriteFont>("Test");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        i++;    
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        spriteBatch.Begin();
        spriteBatch.DrawString(testFont, "Hello World!", new Vector2(100,100), Color.White);
        spriteBatch.DrawString(testFont, i.ToString(), new Vector2(110, 160), Color.White);
        spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
