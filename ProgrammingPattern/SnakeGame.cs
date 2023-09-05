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
            SwitchToState(new MainMenuState());
        }

        protected override void Render()
        {

        }
    }
}
