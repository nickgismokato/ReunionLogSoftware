using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ReunionLogSoftware;
using ReunionLogSoftware.KeyboardOwn;
using ReunionLogSoftware.GraphControl;

namespace ReunionLogSoftware.States{
    public class Debug : GameState{
        private static Debug instance = null;
        private int choicePos = 0;
        private SpriteFont testFont;
        

        public static Debug GetInstance(GraphicsDevice graphicsDevice) {
            if (Debug.instance == null) {
                Debug.instance = new Debug(graphicsDevice);
            }
            return Debug.instance;
        }
        public Debug(GraphicsDevice graphicsDevice):base(graphicsDevice){
            Debug.instance = this;
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

            if(KeyboardOwn.Keyboard.HasBeenPressed(Keys.Down) && choicePos < 1){
                choicePos++;
            }
            if(KeyboardOwn.Keyboard.HasBeenPressed(Keys.Up) && choicePos > 0){
                choicePos--;
            }
            if(KeyboardOwn.Keyboard.HasBeenPressed(Keys.Enter)){
                switch(choicePos){
                    case 0:
                        GraphBuilder.Build("i7kE4");
                        break;
                    case 1:
                        Main.self.ChangeState(StateType.MainMenu);
                        break;
                    default:
                        break;
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch){
            _graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch(choicePos){
                case 0:
                    spriteBatch.DrawString(testFont, "Test", new Vector2(100, 160), Color.Green);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,220), Color.White);
                    break;
                case 1:
                    spriteBatch.DrawString(testFont, "Test", new Vector2(100, 160), Color.White);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,220), Color.Green);
                    break;
                default:
                    spriteBatch.DrawString(testFont, "Test", new Vector2(100, 160), Color.White);
                    spriteBatch.DrawString(testFont, "Exit", new Vector2(100,220), Color.White);
                    System.Console.WriteLine("choicePos is out of range. [choicePos: {0}]", choicePos);
                    break;
            }            
            spriteBatch.End();
        }
    }
}