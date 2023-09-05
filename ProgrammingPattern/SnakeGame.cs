using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPattern
{
    internal class SnakeGame : GameEngine
    {
        public SnakeGame() : base(600, 600, "snakeGame") //tell how to construct the base class part of the class.
        {
            var mainMenuState = new MainMenuState();
            mainMenuState.onStartButtonClicked += StartGame;
            SwitchToState(mainMenuState);
        }

        protected override void Render()
        {

        }

        internal void StartGame()
        {
            float gridUnitSize = 30f;

            var gameplayState = new GameplayState((int)(600/gridUnitSize), (int)(600/gridUnitSize), gridUnitSize);
            SwitchToState(gameplayState);
        }
    }
}
