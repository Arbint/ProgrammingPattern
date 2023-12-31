﻿using SFML.Graphics;
using SFML.Window;
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

        //defaults to not handle the mouse event.
        public virtual bool HandleMouseButtonEvent(MouseButtonEventArgs buttonEvent) { return false; }
    }
}
