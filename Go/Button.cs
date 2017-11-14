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
        private bool bBtnViewEndGame;
        private bool bIsViewEndGame;
        private int iCountClickPass;
        private string strViewWhenWinner;

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
            strViewWhenWinner = "";
            bBtnViewEndGame = false;
            bIsViewEndGame = false;
        }
        public string ViewWhenWinner
        {
            set
            {
                strViewWhenWinner = value;
            }
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

        public bool GetBtnIsViewEndGame()
        {
            return bBtnViewEndGame;
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
            bBtnViewEndGame = false;
            if (EnterButton(mouseState) && mouseState.LeftButton == ButtonState.Pressed)
            {
                switch (iId)
                {
                    case 0:
                        if (!bIsStoneDelete)
                        {
                            bIsStoneDelete = true;
                            bIsPass = true;
                            bIsEndGame = true;
                            bIsViewEndGame = true;

                            bBtnReturnIsDelete = true;
                        }
                        break;
                    case 1:
                        if (!bIsPass)
                        {
                            bIsStoneDelete = true;
                            bIsPass = true;
                            bIsEndGame = true;
                            bIsViewEndGame = true;

                            bBtnIsPass = true;
                        }
                        break;
                    case 2:
                        if(!bIsEndGame)
                        {
                            bIsStoneDelete = true;
                            bIsPass = true;
                            bIsEndGame = true;
                            bIsViewEndGame = true;

                            bBtnEndgame = true;
                        }
                        break;
                    case 3:
                        if(!bIsViewEndGame)
                        {
                            bIsStoneDelete = true;
                            bIsPass = true;
                            bIsEndGame = true;
                            bIsViewEndGame = true;

                            bBtnViewEndGame = true;
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
                    switch (iId)
                    {
                        case 0:
                    bIsStoneDelete = false;
                            break;
                        case 1:
                    bIsPass = false;
                            break;
                        case 2:
                    bIsEndGame = false;
                            break;
                        case 3:
                    bIsViewEndGame = false;
                            break;
                    }
                }
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
          
            spriteBatch.Draw(texture, new Rectangle((int)ButtonX, (int)ButtonY, iSizeX, iSizeY), Color.White);

            switch(iId)
            {
                case 0:
                    spriteBatch.DrawString(Ressource.GetDefaultText(), "revenir en arriere ", new Vector2(buttonX,ButtonY), Color.Black);
                    break;
                case 1:
                    spriteBatch.DrawString(Ressource.GetDefaultText(), "Passer", new Vector2(buttonX, buttonY), Color.Black);
                    break;
                case 2:
                    spriteBatch.DrawString(Ressource.GetDefaultText(), "fin du jeu?", new Vector2(buttonX, buttonY), Color.Black);
                    break;
                case 3:
                    spriteBatch.DrawString(Ressource.GetDefaultText(), strViewWhenWinner, new Vector2(buttonX, buttonY), Color.Black);
                    break;
            }

        }
    }
}
