using SFML.Graphics;
using SFML.System;

namespace ProgrammingPattern
{
    internal class MainMenuState : GameState
    {
        public MainMenuState()
        {
            mFont = new Font("BAUHS93.TTF");
            mTitleText = new Text("Snake Game", mFont);
            mTitleText.Position = new Vector2f(200f, 200f);

        }
        public override void Render(RenderWindow window)
        {
            window.Draw(mTitleText);
        }

        public override void Update(float deltaTime)
        {
            
        }

        Font mFont;
        Text mTitleText;

    }
}
