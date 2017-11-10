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
        

        private MainGo oldGame;

        private List<Player> lstPlayers;
        private Stone[][] tabStone;
        private int iCountMove;

        private Button btnReturn;
        private Button btnPass;


        private bool bStonePosed;
        private const int lengthBoard = 7;
        private const int sizeBoard=   MainGame.windowsHeight - 200;
        private const int seperateLine= sizeBoard / (lengthBoard - 1);
        private const int boardPositionX = 150;
        private const int boardPositionY = 120;
        private const int btnSizeX = 120;
        private const int btnSizeY = 50;
        private bool bIsOver;
        private Color colorDeadStoneEndGame;

        public MainGo()
        {

            board = new Board(this);
            btnReturn = new Button("return",Ressource.GetBtnReturn(),10,10,0, btnSizeX, btnSizeY, this);
            btnPass = new Button("pass", Ressource.GetBtnPass(), 10, 200, 1, btnSizeX, btnSizeY, this);


            lstPlayers = new List<Player>();
            lstPlayers.Add(new Player(Color.Black,this));
            lstPlayers.Add(new Player(Color.White, this));

            tabStone = new Stone[lengthBoard][];
            for(int i=0; i< lengthBoard; i++)
            {
                tabStone[i] = new Stone[lengthBoard];
            }
            bStonePosed = false;
            bIsOver = false;
            iCountMove = 0;
        }
        public MainGo OldGame
        {
            get
            {
                return oldGame;
            }
            set
            {
                oldGame = value;
            }
        }
        public MainGo Clone()
        {
            MainGo returnMainGo = new MainGo();

            returnMainGo.board = this.board.Clone();
            returnMainGo.lstPlayers = new List<Player>();
            foreach(Player p in this.lstPlayers)
            {
                returnMainGo.lstPlayers.Add(p.Clone());
            }
            returnMainGo.tabStone = new Stone[this.GetLengthBoard()][];
            for (int i = 0; i < this.GetLengthBoard(); i++)
            {
                returnMainGo.tabStone[i] = new Stone[this.GetLengthBoard()];
                
            }
            returnMainGo.btnReturn = this.btnReturn;
            returnMainGo.bStonePosed = this.bStonePosed;
            returnMainGo.FillTabStone();

            if (this.oldGame != null)
            {
                returnMainGo.oldGame = this.oldGame.Clone();
            }
            returnMainGo.iCountMove = this.iCountMove;
            return returnMainGo;
        }

        private bool CompareThisAndOldGame()
        {
            
            
            for (int i = 0; i < lstPlayers.Count; i++)
            {
                if(lstPlayers[i].Color!=oldGame.oldGame.lstPlayers[i].Color)
                {
                    return false;
                }
                if(lstPlayers[i].GetLstStone().Count!=oldGame.oldGame.lstPlayers[i].GetLstStone().Count)
                {
                    return false;
                }
            }
           
            return true;
        }
        private void CopyOldGame()
        {
            try
            {
                this.board = oldGame.board.Clone();
                this.lstPlayers = new List<Player>();
                foreach (Player p in oldGame.lstPlayers)
                {
                    this.lstPlayers.Add(p.Clone());
                }
                this.tabStone = new Stone[this.GetLengthBoard()][];

                for (int i = 0; i < this.GetLengthBoard(); i++)
                {
                    this.tabStone[i] = new Stone[this.GetLengthBoard()];
                }
                this.bStonePosed = oldGame.bStonePosed;
                this.FillTabStone();
                if (oldGame.oldGame != null)
                {
                    this.oldGame = oldGame.oldGame.Clone();
                }
            }
            catch
            {

            }
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
        public Stone[][] GetTabStone()
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
                foreach(Stone s1 in p.GetLstStone())
                {
                    s1.IsAlreadyVisit = false;
                }
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
        private bool Collision(Square s, MouseState mouseState)
        {

            //gauche
            if (s.GetHitbox().X + s.GetHitbox().Width < mouseState.X)
            {
                return false;
            }
            //droite
            if (s.GetHitbox().X > mouseState.X)
            {
                return false;
            }

            //haut
            if (s.GetHitbox().Y + s.GetHitbox().Height < mouseState.Y)
            {

                return false;
            }
            //bas
            if (s.GetHitbox().Y > mouseState.Y)
            {
                return false;
            }

            return true;
        }
        private Square GetSquareInPosition(int x, int y)
        {
            Square square=null;
            foreach(Square s in board.GetSquare())
            {
                if(s.GetPositionX()==x&&s.GetPositionY()==y)
                {
                    square = s;
                }
            }

            return square;
        }
        private void SuppStoneEndGame(Square s)
        {
            if (!s.IsAlreadyVisit)
            {
                bool b = true;
                s.IsAlreadyVisit = true;
                Stone stone = tabStone[s.GetPositionX()][s.GetPositionY()];

                if (stone != null)
                {
                    if (stone.Color == colorDeadStoneEndGame)
                    {
                        stone.IsAlive = false;
                    }
                    else
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    int x = s.GetPositionX() - 1;
                    int y = s.GetPositionY();
                    if (x >= 0)
                    {
                        Square square = GetSquareInPosition(x, y);
                        SuppStoneEndGame(square);
                    }
                    x = s.GetPositionX() + 1;
                    if (x < lengthBoard)
                    {
                        Square square = GetSquareInPosition(x, y);
                        SuppStoneEndGame(square);
                    }
                    x = s.GetPositionX();
                    y = s.GetPositionY() - 1;
                    if (y >= 0)
                    {
                        Square square = GetSquareInPosition(x, y);
                        SuppStoneEndGame(square);
                    }
                    y = s.GetPositionY() + 1;
                    if (y < lengthBoard)
                    {
                        Square square = GetSquareInPosition(x, y);
                        SuppStoneEndGame(square);
                    }
                }
            }
        }
        public void Update(MouseState mouseState, KeyboardState keyBoard)
        {
            if (bIsOver)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    foreach(Square s in board.GetSquare())
                    {
                        if(Collision(s,mouseState))
                        {
                            if(tabStone[s.GetPositionX()][s.GetPositionY()]!=null)
                            {
                                colorDeadStoneEndGame = tabStone[s.GetPositionX()][s.GetPositionY()].Color;
                                SuppStoneEndGame(s);
                                List<Stone> deadStone = new List<Stone>();
                                for (int i = 0; i < lengthBoard; i++)
                                {
                                    for (int j = 0; j < lengthBoard; j++)
                                    {
                                        Stone stone = tabStone[i][j];
                                        if(stone!=null)
                                        {
                                            if (!stone.IsAlive)
                                            {
                                                deadStone.Add(stone);
                                            }
                                        }
                                    }
                                }
                                foreach(Player p in lstPlayers)
                                {
                                    if (p.Color == colorDeadStoneEndGame)
                                    {
                                        foreach (Stone stone in deadStone)
                                        {
                                            p.GetLstStone().Remove(stone);
                                        }
                                    }
                                }
                                FillTabStone();
                                foreach(Square square in board.GetSquare())
                                {
                                    square.IsAlreadyVisit = false;
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                btnReturn.Update(mouseState);
                if (btnReturn.GetbtnReturnIsDelete())
                {
                    this.CopyOldGame();
                    iCountMove--;
                }
                btnPass.Update(mouseState);
                if (btnPass.GetbtnPassIsPass())
                {
                    this.oldGame = this.Clone();
                    lstPlayers.Add(lstPlayers[0]);
                    lstPlayers.Remove(lstPlayers[0]);
                    btnPass.CountClickPass++;
                    if (btnPass.CountClickPass == 2)
                    {
                        bIsOver = true;
                    }
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

                                iCountMove++;
                                btnPass.CountClickPass = 0;
                                lstPlayers.Add(lstPlayers[0]);
                                lstPlayers.Remove(lstPlayers[0]);
                                FillTabStone();
                                bStonePosed = true;

                                SetDeadStones(lstPlayers[0]);
                                List<Stone> deadStone = new List<Stone>();
                                foreach (Stone s in lstPlayers[0].GetLstStone())
                                {
                                    if (!s.IsAlive)
                                    {
                                        deadStone.Add(s);
                                    }
                                }
                                List<Stone> newList = lstPlayers[0].GetLstStone();
                                foreach (Stone s in deadStone)
                                {
                                    newList.Remove(s);
                                }
                                lstPlayers[0].SetListStone(newList);
                                FillTabStone();


                                SetDeadStones(lstPlayers[1]);
                                bool b = false;
                                foreach (Stone s in lstPlayers[1].GetLstStone())
                                {
                                    if (!s.IsAlive)
                                    {
                                        b = true;
                                    }
                                }
                                if (b)
                                {
                                    Stone s = lstPlayers[1].GetLstStone()[lstPlayers[1].GetLstStone().Count - 1];
                                    newList = lstPlayers[1].GetLstStone();
                                    newList.Remove(s);
                                    lstPlayers.Add(lstPlayers[0]);
                                    lstPlayers.Remove(lstPlayers[0]);
                                    FillTabStone();
                                }
                                if (iCountMove > 1)
                                {
                                    if (CompareThisAndOldGame())
                                    {
                                        this.CopyOldGame();
                                        iCountMove--;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (mouseState.LeftButton == ButtonState.Released)
                    {
                        bStonePosed = false;
                    }
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
            btnPass.Draw(spriteBatch);
        }
    }
}
