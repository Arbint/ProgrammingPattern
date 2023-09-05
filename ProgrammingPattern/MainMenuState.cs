using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProgrammingPattern
{
    internal class MainMenuState : GameState
    {
        //use delegate to singnal back.
        public delegate void OnStartButtonClicked();
        public event OnStartButtonClicked onStartButtonClicked;

        public MainMenuState()
        {
            mFont = new Font("BAUHS93.TTF");
            mTitleText = new Text("Snake Game", mFont);
            mTitleText.Position = new Vector2f(200f, 200f);
            mButtonText = new Text("Start Game", mFont);
            
            mButton = new RectangleShape();
            mButton.Size = new Vector2f(200f, 80f);
            mButton.Position = mTitleText.Position + new Vector2f(0, 50f);
            mButton.FillColor = new Color(128, 130, 128);
            mButtonText.Position = mButton.Position + new Vector2f(30f, 15f);
            
        }
        public override void Render(RenderWindow window)
        {
            window.Draw(mTitleText);
            window.Draw(mButton);
            window.Draw(mButtonText);
        }

        public override bool HandleMouseButtonEvent(MouseButtonEventArgs buttonEvent)
        {
            if(buttonEvent.Button == Mouse.Button.Left)
            {
                if(mButton.GetGlobalBounds().Contains(buttonEvent.X, buttonEvent.Y))
                {
                    StartGameBtnClicked();
                    return true;
                }
            }

            return base.HandleMouseButtonEvent(buttonEvent);
        }

        private void StartGameBtnClicked()
        {
            onStartButtonClicked?.Invoke();
        }

        public override void Update(float deltaTime)
        {
            
        }

        Font mFont;
        Text mTitleText;

        Text mButtonText;
        RectangleShape mButton;
    }
}
