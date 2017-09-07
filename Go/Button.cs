using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Go
{
    public class Button
    {
        private int buttonX;
        private int buttonY;
        private Texture2D texture;
        private String strName;
        private int iId;
        private int iSizeX;
        private int iSizeY;
        private MainGo parent;
        private bool bBtnReturnIsDelete;
        private bool bIsStoneDelete;

        public int ButtonX
        {
            get
            {
                return buttonX;
            }
        }

        public int ButtonY
        {
            get
            {
                return buttonY;
            }
        }

        public Button(string name, Texture2D texture, int buttonX, int buttonY, int id, int sizeX, int sizeY,MainGo mainGo)
        {
            this.strName = name;
            this.texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            this.iId = id;
            this.iSizeX = sizeX;
            this.iSizeY = sizeY;
            this.parent = mainGo;
            this.bBtnReturnIsDelete = false;
            this.bIsStoneDelete = false;
            this.parent = mainGo;
        }

       
        public bool enterButton(MouseState mouseState)
        {
            if (mouseState.X < buttonX + iSizeX &&
                    mouseState.X > buttonX &&
                    mouseState.Y < buttonY + iSizeY &&
                    mouseState.Y > buttonY)
            {
                return true;
            }
            return false;
        }
        public bool getbtnReturnIsDelete()
        {
            return bBtnReturnIsDelete;
        }
        public void Update(MouseState mouseState)
        {
            bBtnReturnIsDelete = false;
            if (!bIsStoneDelete)
            {
                if (enterButton(mouseState) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    switch (iId)
                    {
                        case 0:
                            bBtnReturnIsDelete = true;
                            bIsStoneDelete = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if(mouseState.LeftButton==ButtonState.Released)
                {
                    bIsStoneDelete = false;
                }
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            texture.Name = "salut";
            spriteBatch.Draw(texture, new Rectangle((int)ButtonX, (int)ButtonY, iSizeX, iSizeY), Color.White);
        }
    }
}
