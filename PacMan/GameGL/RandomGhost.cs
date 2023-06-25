using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class RandomGhost : Ghost
    {
        GameDirection direction = GameDirection.Up;
        GameDirection direction2 = GameDirection.Right;
        public RandomGhost(GameCell startCell) : base('R', startCell)
        {

        }
        static int GhostDirection()
        {
            Random r = new Random();
            int value = r.Next(2);
            return value;
        }
        public override GameCell Move()
        {
            int value = GhostDirection();
            GameCell currentCell = CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction2);
            if (value == 0)
            {
                if (nextCell != null)
                {
                    GameObjectType nextCellObjectType = nextCell.CurrentGameObject.GameObjectType;
                    if (nextCellObjectType == GameObjectType.REWARD || nextCellObjectType == GameObjectType.WALL)
                    {
                        if (direction2 == GameDirection.Up)
                        {
                            direction2= GameDirection.Down;
                        }
                        else
                        {
                            direction2 = GameDirection.Up;
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
                    if (direction2 == GameDirection.Up)
                    {
                        direction2 = GameDirection.Down;
                    }
                    else
                    {

                        direction = GameDirection.Up;
                    }
                }
                return CurrentCell;
            }
            if (value == 1)
            {
                if (nextCell != null)
                {
                    GameObjectType nextCellObjectType = nextCell.CurrentGameObject.GameObjectType;
                    if (nextCellObjectType == GameObjectType.REWARD || nextCellObjectType == GameObjectType.WALL)
                    {
                        if (direction2 == GameDirection.Right)
                        {
                            direction2 = GameDirection.Left;
                        }
                        else
                        {
                            direction2 = GameDirection.Right;
                        }
                    }

                    else if (nextCellObjectType == GameObjectType.WALL)
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
                    if (direction2 == GameDirection.Right)
                    {
                        direction2 = GameDirection.Left;
                    }
                    else
                    {
                        direction2 = GameDirection.Right;
                    }
                }
                return CurrentCell;
            }
            return CurrentCell;


            /*if (nextCell != null)
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
        }*/

        }
    }
}
