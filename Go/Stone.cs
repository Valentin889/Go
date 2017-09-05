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
        private Color color;
        private int iSeperateLine;

        public Stone(Color c, Player Parent)
        {
            parent = Parent;
            bDefinitivePosition = false;
            color = c;
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
            if(!bDefinitivePosition)
            {
               // iPositionX = mouseState.Position.X;
               // iPositionY = mouseState.Position.Y;
            }
        }



        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(Ressource.GetStone(), new Rectangle(iPositionX, iPositionY, 30, 30), Color.Black);
            
        }
    }
}
