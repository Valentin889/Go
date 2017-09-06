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
        private bool bDefinitivePosition;
        private int iSize;
        private Color color;

        public Stone(Color c, Player player, int size)
        {
            parent = player;
            bDefinitivePosition = false;
            color = c;
            iSize = size;
        }


        public bool DefinitivePosition
        {
            set
            {
                bDefinitivePosition = value;
            }
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
