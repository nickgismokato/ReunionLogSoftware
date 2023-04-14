using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using ReunionLogSoftware.States;

namespace ReunionLogSoftware;

public class Main : Game{

    public static Main self;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private int i = 0;

    private int choicePos = 0;
    
    //private Game.Window indputTest;
    public Main(){
        self = this;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    public void SessionExit(){
        Exit();
    }

    public void ChangeState(StateType stateType){
        switch(stateType){
            case StateType.MainMenu:
                StateManager.Instance.ChangeScreen(MainMenu.GetInstance(GraphicsDevice));
                break;
            case StateType.Options:
                StateManager.Instance.ChangeScreen(Options.GetInstance(GraphicsDevice));
                break;
            case StateType.Run:
                StateManager.Instance.ChangeScreen(ReunionLogSoftware.States.Run.GetInstance(GraphicsDevice));
                break;
            case StateType.Debug:
                StateManager.Instance.ChangeScreen(Debug.GetInstance(GraphicsDevice));
                break;
            default:
                break;
        }
    }
    protected override void Initialize(){
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent(){
        spriteBatch = new SpriteBatch(GraphicsDevice);
        StateManager.Instance.SetContent(Content);
        StateManager.Instance.AddScreen(new MainMenu(GraphicsDevice));
        // TODO: use this.Content to load your game content here
    }
    protected override void UnloadContent(){
        StateManager.Instance.UnloadContent();
    }
    protected override void Update(GameTime gameTime){
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        StateManager.Instance.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime){

        // TODO: Add your drawing code here
        GraphicsDevice.Clear(Color.CornflowerBlue);
        StateManager.Instance.Draw(spriteBatch);
        base.Draw(gameTime);
    }
}
