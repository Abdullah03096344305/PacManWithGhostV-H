using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class VerticalGhost : Ghost
    {
        GameDirection direction = GameDirection.Up;
        public VerticalGhost(GameCell startCell) : base('V', startCell)
        {

        }
        public override GameCell Move()
        {           
            GameCell currentCell = CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObjectType nextCellObjectType = nextCell.CurrentGameObject.GameObjectType;
                if (nextCellObjectType == GameObjectType.REWARD || nextCellObjectType == GameObjectType.WALL)
                {                   
                    if (direction == GameDirection.Up)
                    {
                        direction = GameDirection.Down;
                    }
                    else
                    {
                        direction = GameDirection.Up;
                    }
                }
                else if (nextCellObjectType == GameObjectType.REWARD)
                {
                    Program.clearGameCellContent(currentCell, new GameObject(GameObjectType.NONE, ' '));
                    CurrentCell = nextCell;
                    Program.printGameObject(this);
                }
                else
                {                  
                    Program.clearGameCellContent(currentCell, new GameObject(GameObjectType.NONE, ' '));
                    CurrentCell = nextCell;
                    Program.printGameObject(this);
                }
            }
            else
            {
                if (direction == GameDirection.Up)
                {
                    direction = GameDirection.Down;
                }
                else
                {
                    direction = GameDirection.Up;
                }
            }
            return CurrentCell;
        }
    }
}
