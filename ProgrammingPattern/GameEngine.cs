﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProgrammingPattern
{
    internal class GameEngine
    {
        public GameEngine(uint sizeX, uint sizeY, string title)
        {
            mWindow = new RenderWindow(new VideoMode(sizeX, sizeY), title);
            mWindow.MouseButtonPressed += MouseBtnClicked;
            mTargetFramerate = 60;
        }

        private void MouseBtnClicked(object? sender, MouseButtonEventArgs e)
        {
            if (mCurrentState != null && mCurrentState.HandleMouseButtonEvent(e))
            {
                return;
            }

            NativehandleMouseEvent(e);
        }

        private void NativehandleMouseEvent(MouseButtonEventArgs mouseEvent)
        {
            
        }

        public void SwitchToState(GameState nextState)
        {
            mNextState = nextState;
        }

        public RenderWindow Window { get { return mWindow; } } //missing the set part means you cannot set it.
        
        public void Run()
        {
            Clock runClock = new Clock();
            runClock.Restart();
            float accumlatedTime = 0;
            float targetDeltaTime = 1f / mTargetFramerate;
            while(mWindow.IsOpen)
            {
                mWindow.DispatchEvents(); //dispath events like close window event, mouse click, keypress
                accumlatedTime += runClock.Restart().AsSeconds(); // keep increment acumulatedTime with the time elapes each loop
                while(accumlatedTime > targetDeltaTime) //if we accumulated enough time for an update, we update.
                {
                    Update(targetDeltaTime); 
                    accumlatedTime -= targetDeltaTime;
                }

                NativeRender();
            }
        }

        private void NativeRender()
        {
            Window.Clear();

            if(mCurrentState!=null)
            {
                mCurrentState.Render(Window);
            }

            Render();
            Window.Display();
        }

        protected virtual void Render()
        {
            
        }

        private void Update(float deltaSecond)
        {
            if(mNextState != null) //swith to the new state if mNextState exist.
            {
                mCurrentState = mNextState;
                mNextState = null;
            }

            if(mCurrentState != null)
            {
                mCurrentState.Update(deltaSecond); 
            }

            //Console.WriteLine($"runing at framerate: {1f/deltaSecond}");
        }

        private RenderWindow mWindow;
        private int mTargetFramerate;

        private GameState? mCurrentState; //? means this variable couble be null
        private GameState? mNextState; 
    }
}
