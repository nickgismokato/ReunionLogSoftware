using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ReunionLogSoftware;
using ReunionLogSoftware.KeyboardOwn;

namespace ReunionLogSoftware.States{
    public class MainMenu : GameState{
        private static MainMenu instance = null;
        private int choicePos = 0;
        private int i = 0;
        private SpriteFont testFont;


        public static MainMenu GetInstance(GraphicsDevice graphicsDevice) {
            if (MainMenu.instance == null) {
                MainMenu.instance = new MainMenu(graphicsDevice);
            }
            return MainMenu.instance;
        }

        public MainMenu(GraphicsDevice graphicsDevice):base(graphicsDevice){

        }

        public override void Initialize(){
            //
        }

        public override void LoadContent(ContentManager content){
            testFont = content.Load<SpriteFont>("Test");
        }

        public override void UnloadContent(){
            //
        }

        public override void Update(GameTime gameTime){
            KeyboardOwn.Keyboard.GetState();

            if(KeyboardOwn.Keyboard.HasBeenPressed(Keys.Down) && choicePos < 3){
                choicePos++;
            }
            if(KeyboardOwn.Keyboard.HasBeenPressed(Keys.Up) && choicePos > 0){
                choicePos--;
            }
            if(KeyboardOwn.Keyboard.HasBeenPressed(Keys.Enter)){
                switch(choicePos){
                    case 0:
                        Main.self.ChangeState(StateType.Run);
                        break;
                    case 1:
                        Main.self.ChangeState(StateType.Debug);
                        break;
                    case 2:
                        Main.self.ChangeState(StateType.Options);
                        break;
                    case 3:
                        Main.self.SessionExit();
                        break;
                    default:
                        break;
                }
            }

            i++;
        }
        public override void Draw(SpriteBatch spriteBatch){
            _graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch(choicePos){
                case 0:
                    spriteBatch.DrawString(testFont, "Run", new Vector2(100,100), Color.Green);
                    spriteBatch.DrawString(testFont, "Debug", new Vector2(100,160), Color.White);
                    spriteBatch.DrawString(testFont, "Options", new Vector2(100, 220), Color.White);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,280), Color.White);
                    break;
                case 1:
                    spriteBatch.DrawString(testFont, "Run", new Vector2(100,100), Color.White);
                    spriteBatch.DrawString(testFont, "Debug", new Vector2(100,160), Color.Green);
                    spriteBatch.DrawString(testFont, "Options", new Vector2(100, 220), Color.White);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,280), Color.White);
                    break;
                case 2:
                    spriteBatch.DrawString(testFont, "Run", new Vector2(100,100), Color.White);
                    spriteBatch.DrawString(testFont, "Debug", new Vector2(100,160), Color.White);
                    spriteBatch.DrawString(testFont, "Options", new Vector2(100, 220), Color.Green);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,280), Color.White);
                    break;
                case 3:
                    spriteBatch.DrawString(testFont, "Run", new Vector2(100,100), Color.White);
                    spriteBatch.DrawString(testFont, "Debug", new Vector2(100,160), Color.White);
                    spriteBatch.DrawString(testFont, "Options", new Vector2(100, 220), Color.White);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,280), Color.Green);
                    break;
                default:
                    spriteBatch.DrawString(testFont, "Run", new Vector2(100,100), Color.White);
                    spriteBatch.DrawString(testFont, "Debug", new Vector2(100,160), Color.White);
                    spriteBatch.DrawString(testFont, "Options", new Vector2(100, 220), Color.White);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,280), Color.White);
                    System.Console.WriteLine("choicePos is out of range. [choicePos: {0}]", choicePos);
                    break;
            }            
            spriteBatch.End();
        }
    }
}