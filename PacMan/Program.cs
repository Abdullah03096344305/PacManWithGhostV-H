using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
using PacMan.GameGL;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            GameGrid grid = new GameGrid("maze.txt", 23, 71);
            GameCell start = new GameCell(12, 22, grid);
            GamePacManPlayer pacman = new GamePacManPlayer('p', start);
            HorizontalGhost horizontalGhost = new HorizontalGhost(grid.getCell(16, 10));
            VerticalGhost verticalGhost = new VerticalGhost(grid.getCell(20, 8));
            RandomGhost randomGhost = new RandomGhost(grid.getCell(5, 5));
           
           
            printMaze(grid);
            printGameObject(pacman);
            printGameObject(horizontalGhost);
            bool gameRunning = true;
            while (gameRunning)
            {
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveGameObject(pacman, GameDirection.Up);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveGameObject(pacman, GameDirection.Down);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, GameDirection.Right);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveGameObject(pacman, GameDirection.Left);
                }
                GameCell ghostCell = horizontalGhost.Move();
                GameCell ghostVCell = verticalGhost.Move();
                GameCell ghostRCell = randomGhost.Move();
                if (ghostCell == pacman.CurrentCell || ghostVCell == pacman.CurrentCell || ghostRCell == pacman.CurrentCell)
                {                    
                    Console.WriteLine("Game Over");                   
                    gameRunning = false;
                  
                }
            }
        }
        public static void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.CurrentGameObject = newGameObject;
            Console.SetCursorPosition(gameCell.Y, gameCell.X);
            Console.Write(newGameObject.DisplayCharacter);

        }

        public static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.CurrentCell.Y, gameObject.CurrentCell.X);
            Console.Write(gameObject.DisplayCharacter);

        }
        static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.CurrentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObject newGO = new GameObject(GameObjectType.NONE, ' ');
                GameCell currentCell = gameObject.CurrentCell;
                clearGameCellContent(currentCell, newGO);
                gameObject.CurrentCell = nextCell;
                printGameObject(gameObject);
            }
        }
        static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {               
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    printCell(cell);
                }

            }
        }
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }

    }
}
