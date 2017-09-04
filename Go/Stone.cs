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
        private int iPositionXTempory;
        private int iPositionYTempory;
        private int iPositionXDefinitive;
        private int iPositionYDefinitive;


        private bool bDefinitivePosition;
        private bool bIsClick;
        private Color color;

        public Stone(Color c)
        {
            bDefinitivePosition = false;
            bIsClick = false;
            color = c;

        }
        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            iPositionXTempory = mouseState.Position.X;
            iPositionYTempory = mouseState.Position.Y;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                bIsClick = true;
                bDefinitivePosition = true;
            }
            if (bIsClick)
            {
                iPositionXDefinitive = mouseState.Position.X;
                iPositionYDefinitive = mouseState.Position.Y;
                bIsClick = false;
            }
        }


        public int PositionX
        {
            get
            {
                return iPositionXDefinitive;
            }
            set
            {
                iPositionXDefinitive = value;
            }
        }

        public int PositionY
        {
            get
            {
                return iPositionYDefinitive;
            }
            set
            {
                iPositionYDefinitive = value;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (bDefinitivePosition)
            {
                spriteBatch.Draw(Ressource.GetStone(), new Rectangle(iPositionXDefinitive, iPositionYDefinitive, 30, 30), Color.Black);
            }
            else
            {
                spriteBatch.Draw(Ressource.GetStone(), new Rectangle(iPositionXTempory, iPositionYTempory, 30, 30), Color.Black);
            }
        }
    }
}
