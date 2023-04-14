using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ReunionLogSoftware;

namespace ReunionLogSoftware.States{
    public class StateMachine{
        public StateType currentState;
        public object currentGame;

        public StateMachine(){
            currentState = StateType.MainMenu;
            if (currentGame == null){
                //currentGame = MainMenu.GetInstance();
            }
        }

        private void ChangeState(StateType newState){
            currentState = newState;
            switch(newState){
                case StateType.MainMenu:
                    //currentGame = MainMenu.GetInstance();
                    break;
                case StateType.Options:
                    
                case StateType.Run:
                    break;



            }
        }


    }
}