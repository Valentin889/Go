using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go
{
    public class Stone
    {
        private Player parent;

        private int iPositionX;
        private int iPositionY;
        private int iSize;
        private Color color;
        private bool bIsAlive;
        private bool bIsAlreadyVisit;

        public Stone(Color c, Player player, int size)
        {
            parent = player;
            color = c;
            iSize = size;
        }
        public int PositionX
        {
            get
            {
                return iPositionX;
            }
            set
            {
                iPositionX = value;
            }
        }
        public int PositionY
        {
            get
            {
                return iPositionY;
            }
            set
            {
                iPositionY = value;
            }
        }
        public bool IsAlive
        {
            get
            {
                return bIsAlive;
            }
            set
            {
                bIsAlive = value;
            }
        }
        public bool IsAlreadyVisit
        {
            get
            {
                return bIsAlreadyVisit;
            }
            set
            {
                bIsAlreadyVisit = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
           
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            int i = parent.getParent().GetSeperateLine();
            int j = parent.getParent().GetBoardPositionX();
            spriteBatch.Draw(Ressource.GetStone(), new Rectangle(iPositionX*parent.getParent().GetSeperateLine() +parent.getParent().GetBoardPositionX()-iSize/2, iPositionY*parent.getParent().GetSeperateLine()+parent.getParent().GetBoardPositionY()-iSize / 2, iSize, iSize), color);
        }
    }
}
