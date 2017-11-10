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
        private bool bBtnIsPass;
        private bool bIsPass;
        private bool bBtnEndgame;
        private bool bIsEndGame;
        private int iCountClickPass;

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
            this.bBtnIsPass = false;
            this.iCountClickPass = 0;
            this.bBtnEndgame = false;
            this.bIsEndGame = false;
        }

       
        public bool EnterButton(MouseState mouseState)
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
        public bool GetbtnReturnIsDelete()
        {
            return bBtnReturnIsDelete;
        }
        public bool GetbtnPassIsPass()
        {
            return bBtnIsPass;
        }
        public bool GetBtnIsEndGame()
        {
            return bBtnEndgame;
        }
        public int CountClickPass
        {
            get
            {
                return iCountClickPass;
            }
            set
            {
                iCountClickPass = value;
            }
        }
        public void Update(MouseState mouseState)
        {
            bBtnReturnIsDelete = false;
            bBtnIsPass = false;
            bBtnEndgame = false;
            if (EnterButton(mouseState) && mouseState.LeftButton == ButtonState.Pressed)
            {
                switch (iId)
                {
                    case 0:
                        if (!bIsStoneDelete)
                        {
                            bBtnReturnIsDelete = true;
                            bIsStoneDelete = true;
                            bBtnEndgame = true;
                        }
                        break;
                    case 1:
                        if (!bIsPass)
                        {
                            bIsPass = true;
                            bBtnIsPass = true;
                            bBtnEndgame = true;
                        }
                        break;
                    case 2:
                        if(!bIsEndGame)
                        {
                            bBtnReturnIsDelete = true;
                            bIsStoneDelete = true;
                            bBtnEndgame = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (mouseState.LeftButton == ButtonState.Released)
                {
                    bIsStoneDelete = false;
                    bIsPass = false;
                    bIsEndGame = false;
                }
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
          
            spriteBatch.Draw(texture, new Rectangle((int)ButtonX, (int)ButtonY, iSizeX, iSizeY), Color.White);

            switch(iId)
            {
                case 0:
                    spriteBatch.DrawString(Ressource.GetBtnReturntext(), "revenir en arriere ", new Vector2(buttonX,ButtonY), Color.Black);
                    break;
                case 1:
                    spriteBatch.DrawString(Ressource.GetBtnpassText(), "Passer", new Vector2(buttonX, buttonY), Color.Black);
                    break;
                case 2:
                    spriteBatch.DrawString(Ressource.GetBtnpassText(), "fin du jeu?", new Vector2(buttonX, buttonY), Color.Black);
                    break;
            }

        }
    }
}
