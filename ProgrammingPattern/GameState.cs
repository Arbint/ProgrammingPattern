using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPattern
{
    internal abstract class GameState
    {
        protected GameState() { } // only child class can call this coustructor.
        public abstract void Update(float deltaTime);
        public abstract void Render(RenderWindow window);
    }
}
