using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class HorizontalGhost : Ghost
    {
        GameDirection direction = GameDirection.Right;

        public HorizontalGhost(GameCell startCell) : base('H', startCell)
        {

        }
        public override GameCell Move()
        {
            // Retrieve the current cell of the horizontal ghost
            GameCell currentCell = CurrentCell;

            // Get the next cell in the current movement direction
            GameCell nextCell = currentCell.nextCell(direction);

            // Check if the next cell is within the game grid boundaries
            if (nextCell != null)
            {
                // Retrieve the game object type of the next cell
                GameObjectType nextCellObjectType = nextCell.CurrentGameObject.GameObjectType;

                if ( nextCellObjectType == GameObjectType.REWARD||nextCellObjectType == GameObjectType.WALL )
                {
                    // If the next cell contains a wall, reverse the movement direction
                    if (direction == GameDirection.Right)
                    {
                        direction = GameDirection.Left;
                    }
                    else
                    {
                        direction = GameDirection.Right;
                    }
                }
                else if (nextCellObjectType == GameObjectType.REWARD )
                {
                    Program.clearGameCellContent(currentCell, new GameObject(GameObjectType.NONE, ' '));
                    CurrentCell = nextCell;
                    Program.printGameObject(this);
                }
                else
                {
                    // Clear the ghost from the current cell
                    Program.clearGameCellContent(currentCell, new GameObject(GameObjectType.NONE, ' '));

                    // Update the current cell of the ghost
                    CurrentCell = nextCell;

                    // Print the ghost in the new cell
                    Program.printGameObject(this);
                }
            }
            else
            {
                // If the next cell is null, reverse the movement direction
                if (direction == GameDirection.Right)
                {
                    direction = GameDirection.Left;
                }
                else
                {
                    direction = GameDirection.Right;
                }
            }

            // Return the new current cell
            return CurrentCell;
        }




    }
}
