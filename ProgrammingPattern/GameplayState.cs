using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPattern
{
    internal class GameplayState : GameState
    {
        public GameplayState(int gridSizeX, int gridSizeY, float gridUnitSize)
        {
            mSnakeShapes = new List<RectangleShape>();
            mSnakeCoords = new List<Vector2i>();

            mGridSizeX = gridSizeX;
            mGridSizeY = gridSizeY;
            mGridUnitSize = gridUnitSize;

            AddSnakeBodyPart(3, 3);
            AddSnakeBodyPart(2, 3);
            AddSnakeBodyPart(1, 3);
            AddSnakeBodyPart(1, 2);
        }

        private void AddSnakeBodyPart(int v1, int v2)
        {
            RectangleShape newShape = new RectangleShape(new Vector2f(mGridUnitSize, mGridUnitSize));
            newShape.Origin = new Vector2f(mGridUnitSize / 2f, mGridUnitSize / 2f);
            newShape.FillColor = Color.White;

            mSnakeShapes.Add(newShape);
            mSnakeCoords.Add(new Vector2i(v1, v2));
        }

        public override void Render(RenderWindow window)
        {
            for(int i =0; i < mSnakeShapes.Count; i++)
            {
                Vector2i coord = mSnakeCoords[i];
                mSnakeShapes[i].Position = new Vector2f(coord.X * mGridUnitSize, coord.Y * mGridUnitSize);
                window.Draw(mSnakeShapes[i]);
            }
        }

        public override void Update(float deltaTime)
        {

        }

        private List<RectangleShape> mSnakeShapes;
        private List<Vector2i> mSnakeCoords;
        
        private int mGridSizeX;
        private int mGridSizeY;
        private float mGridUnitSize;
    }
}
