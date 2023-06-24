using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class GameObject
    {
        public char displayCharacter;
        public GameObjectType gameObjectType;
        public GameCell currentCell;

        public GameObject(GameObjectType type, char displayCharacter)
        {           
            this.displayCharacter = displayCharacter;
            this.gameObjectType = type;
        }

        public static GameObjectType getGameObjectType(char displayCharacter)
        {          
            if(displayCharacter == '|' || displayCharacter == '%' || displayCharacter == '#')
            {
                return GameObjectType.WALL;
            }
            if (displayCharacter == '.' )
            {
                return GameObjectType.REWARD;
            }
            return GameObjectType.NONE;
        }
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public GameCell CurrentCell
        {
            get => currentCell;
            set
            {
                currentCell = value;
                currentCell.CurrentGameObject = this;
            }
        }

    }
}
