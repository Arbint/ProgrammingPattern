using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Data;

namespace ProgrammingPattern
{
    internal class GameEngine
    {
        public GameEngine(uint sizeX, uint sizeY, string title)
        {
            mWindow = new RenderWindow(new VideoMode(sizeX, sizeY), title);
        }
        
        public void Run()
        {
            Clock runClock = new Clock();
            runClock.Restart();
            while(mWindow.IsOpen)
            {
                mWindow.DispatchEvents(); //dispath events like close window event, mouse click, keypress
                
                Update(runClock.Restart().AsSeconds());
            }
        }

        private void Update(float deltaSecond)
        {
            Console.WriteLine($"runing at framerate: {1f/deltaSecond}");
        }

        private RenderWindow mWindow;
    }
}
