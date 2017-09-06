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
    public class MainGo
    {
        private Board board;
        private List<Player> lstPlayers;
        private Stone[][] tabStone;

        private Button btnReturn;


        private bool bStonePosed;
        private const int lengthBoard = 9;
        private const int sizeBoard=MainGame.windowsHeight - 200;
        private const int seperateLine= sizeBoard / (lengthBoard - 1);
        private const int boardPositionX = 150;
        private const int boardPositionY = 120;

        public MainGo()
        {

            board = new Board(this);
            btnReturn = new Button("return",Ressource.GetBtnReturn(),10,10,0,120,50,this);
            lstPlayers = new List<Player>();
            lstPlayers.Add(new Player(Color.Black,this));
            lstPlayers.Add(new Player(Color.White, this));

            tabStone = new Stone[lengthBoard][];
            for(int i=0; i< lengthBoard; i++)
            {
                tabStone[i] = new Stone[lengthBoard];
            }
            bStonePosed = false;
        }

        public int GetLengthBoard()
        {
            return lengthBoard;
        }
        public int GetSizeBoard()
        {
            return sizeBoard;
        }
        public int GetSeperateLine()
        {
            return seperateLine;
        }

        public int GetBoardPositionX()
        {
            return boardPositionX;
        }
        public int GetBoardPositionY()
        {
            return boardPositionY;
        }
        private void FillTabStone()
        {
            for(int i=0;i<lengthBoard;i++)
            {
                for(int j=0; j<lengthBoard;j++)
                {
                    tabStone[i][j] = null;
                }
            }
            foreach(Player p in lstPlayers)
            {
                foreach(Stone s in p.GetLstStone())
                {
                    tabStone[s.PositionX][s.PositionY] = s;
                }
            }
        }
         public Board GetBoard()
        {
            return board;
        }
        public Stone[][] getTabStone()
        {
            return tabStone;
        }
        public List<Player> GetLstPlayers()
        {
            return lstPlayers;
        }

        private void SetDeadStones(Player p)
        {
            foreach (Stone s in p.GetLstStone())
            {
                s.IsAlive = false;
                s.IsAlreadyVisit = false;
            }

            foreach (Stone s in p.GetLstStone())
            {
                s.IsAlive = IsCaptured(s,p.Color);
            }
            
        }
        private bool IsCaptured(Stone s,Color c)
        {
                bool bReturn = false;
                s.IsAlreadyVisit = true;

                int x = s.PositionX;
                int y = s.PositionY;

                int x1;
                int y1;

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (!bReturn)
                        {
                            if (i == 0 && j != 0 || j == 0 && i != 0)
                            {
                                x1 = x+i;
                                y1 = y+j;
                                if (x1 >= 0 && y1 >= 0 && x1 < lengthBoard && y1 < lengthBoard)
                                {
                                    if (tabStone[x1][y1] == null)
                                    {
                                        bReturn = true;
                                    }
                                    else
                                    {
                                        if (tabStone[x1][y1].Color == c && !tabStone[x1][y1].IsAlreadyVisit)
                                        {
                                            bReturn = IsCaptured(tabStone[x1][y1], c);
                                        }
                                    }
                                }
                            }
                        }
                    }
            }
            return bReturn;
        }
        public void Update(MouseState mouseState, KeyboardState keyBoard)
        {
            btnReturn.Update(mouseState);
            if(btnReturn.getbtnReturnIsDelete())
            {
                FillTabStone();
                lstPlayers.Add(lstPlayers[0]);
                lstPlayers.Remove(lstPlayers[0]);
            }
            board.Update(mouseState, keyBoard);
            if (!bStonePosed)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (lstPlayers[0].Update(mouseState, keyBoard))
                    {
                        if (!lstPlayers[0].GetStoneHere())
                        {
                            lstPlayers.Add(lstPlayers[0]);
                            lstPlayers.Remove(lstPlayers[0]);
                            FillTabStone();
                            bStonePosed = true;

                            SetDeadStones(lstPlayers[0]);

                        }
                    }
                }
            }
            else
            {
                if(mouseState.LeftButton==ButtonState.Released)
                {
                    bStonePosed = false;
                }
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            board.Draw(spriteBatch);
            foreach(Player p in lstPlayers)
            {
                p.Draw(spriteBatch);
            }
            btnReturn.Draw(spriteBatch);
        }
    }
}
