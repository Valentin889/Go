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
        private Button btnEndGame;
        private Button btnViewEndGame;

        private bool bStonePosed;
        private const int lengthBoard = 9;
        private const int sizeBoard = MainGame.windowsHeight - 200;
        private const int seperateLine = sizeBoard / (lengthBoard - 1);
        private const int boardPositionX = 150;
        private const int boardPositionY = 120;
        private const int btnSizeX = 120;
        private const int btnSizeY = 50;
        private bool bIsInCount;
        private bool bIsOver;
        private Color colorDeadStoneEndGame;
        private Color COLOR_PLAYER1;
        private Color COLOR_PLAYER2;

        public MainGo()
        {
            initialise();
        }
        private void initialise()
        {
            board = new Board(this);
            btnReturn = new Button("return", Ressource.GetTexBtnDefault(), 10, 10, 0, btnSizeX, btnSizeY, this);
            btnPass = new Button("pass", Ressource.GetTexBtnDefault(), 10, 200, 1, btnSizeX, btnSizeY, this);
            btnEndGame = new Button("End", Ressource.GetTexBtnDefault(), 10, 300, 2, btnSizeX, btnSizeY, this);
            btnViewEndGame = new Button("ViewEnd", Ressource.GetTexBtnDefault(), 0, 0, 3, sizeBoard, sizeBoard, this);

            COLOR_PLAYER1 = Color.Black;
            COLOR_PLAYER2 = Color.White;

            lstPlayers = new List<Player>();
            lstPlayers.Add(new Player(COLOR_PLAYER1, this));
            lstPlayers.Add(new Player(COLOR_PLAYER2, this));

            tabStone = new Stone[lengthBoard][];
            for (int i = 0; i < lengthBoard; i++)
            {
                tabStone[i] = new Stone[lengthBoard];
            }
            bStonePosed = false;
            bIsInCount = false;
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
            foreach (Player p in this.lstPlayers)
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
                if (lstPlayers[i].Color != oldGame.oldGame.lstPlayers[i].Color)
                {
                    return false;
                }
                if (lstPlayers[i].GetLstStone().Count != oldGame.oldGame.lstPlayers[i].GetLstStone().Count)
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
            for (int i = 0; i < lengthBoard; i++)
            {
                for (int j = 0; j < lengthBoard; j++)
                {
                    tabStone[i][j] = null;
                }
            }
            foreach (Player p in lstPlayers)
            {
                foreach (Stone s in p.GetLstStone())
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
                foreach (Stone s1 in p.GetLstStone())
                {
                    s1.IsAlreadyVisit = false;
                }
                s.IsAlive = IsCaptured(s, p.Color);
            }

        }
        private bool IsCaptured(Stone s, Color c)
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
                            x1 = x + i;
                            y1 = y + j;
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
        private bool Collision(Object o, MouseState mouseState)
        {
            if (o.GetType() == typeof(Square))
            {
                Square s = (Square)o;
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
            }
            else if (o.GetType() == typeof(Button))
            {
                Button b = (Button)o;
            }
            return true;
        }
        private Square GetSquareInPosition(int x, int y)
        {
            Square square = null;
            foreach (Square s in board.GetLstSquare())
            {
                if (s.GetPositionX() == x && s.GetPositionY() == y)
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

        private Stone GetStoneInPosition(int x, int y)
        {
            Stone stone = null;
            foreach (Player p in lstPlayers)
            {
                foreach (Stone s in p.GetLstStone())
                {
                    if (s.PositionX == x && s.PositionY == y)
                    {
                        stone = s;
                    }
                }
            }
            return stone;
        }

        private int AddInGrSquare(List<Square> emptySquare, List<Square> grSquare, int x, int y)
        {
            bool bWhite = false;
            bool bBlack = false;
            if (x >= 0 && x < lengthBoard && y >= 0 && y < lengthBoard)
            {
                Square square = GetSquareInPosition(x, y);
                if (emptySquare.Contains(square))
                {
                    if (!grSquare.Contains(square))
                    {
                        grSquare.Add(square);
                    }
                }
                else
                {
                    if (GetStoneInPosition(x, y).Color == COLOR_PLAYER1)
                    {
                        bBlack = true;
                    }
                    else if (GetStoneInPosition(x, y).Color == COLOR_PLAYER2)
                    {
                        bWhite = true;
                    }
                }
            }
            if (bWhite && bBlack)
            {
                return 3;
            }
            if (bWhite)
            {
                return 2;
            }
            if (bBlack)
            {
                return 1;
            }
            return 0;
        }
        private void CountPointEndGame()
        {
            List<Square> emptySquare = new List<Square>();
            foreach (Square s in board.GetLstSquare())
            {
                bool b = true;
                foreach (Player p in lstPlayers)
                {
                    foreach (Stone stone in p.GetLstStone())
                    {
                        if (stone.PositionX == s.GetPositionX() && stone.PositionY == s.GetPositionY())
                        {
                            b = false;
                        }
                    }
                }
                if (b)
                {
                    emptySquare.Add(s);
                }
            }
            foreach (Square s in emptySquare)
            {
                List<Square> grSquare = new List<Square>();
                if (s.GetEnumOccupation() == Square.occupate.Null)
                {
                    grSquare.Add(s);
                }
                bool bWhite = false;
                bool bBlack = false;
                int i = 0;
                while (i < grSquare.Count)
                {
                    int x = grSquare[i].GetPositionX() - 1;
                    int y = grSquare[i].GetPositionY();
                    if (grSquare[i].GetEnumOccupation() == Square.occupate.Null)
                    {
                        int j = AddInGrSquare(emptySquare, grSquare, x, y);
                        switch (j)
                        {
                            case 3:
                                bWhite = true;
                                bBlack = true;
                                break;
                            case 2:
                                bWhite = true;
                                break;
                            case 1:
                                bBlack = true;
                                break;
                            case 0:
                                break;
                        }
                    }
                    x += 2;
                    if (grSquare[i].GetEnumOccupation() == Square.occupate.Null)
                    {
                        int j = AddInGrSquare(emptySquare, grSquare, x, y);
                        switch (j)
                        {
                            case 3:
                                bWhite = true;
                                bBlack = true;
                                break;
                            case 2:
                                bWhite = true;
                                break;
                            case 1:
                                bBlack = true;
                                break;
                            case 0:
                                break;
                        }
                    }
                    x = grSquare[i].GetPositionX();
                    y -= 1;
                    if (grSquare[i].GetEnumOccupation() == Square.occupate.Null)
                    {
                        int j = AddInGrSquare(emptySquare, grSquare, x, y);
                        switch (j)
                        {
                            case 3:
                                bWhite = true;
                                bBlack = true;
                                break;
                            case 2:
                                bWhite = true;
                                break;
                            case 1:
                                bBlack = true;
                                break;
                            case 0:
                                break;
                        }
                    }
                    y += 2;
                    if (grSquare[i].GetEnumOccupation() == Square.occupate.Null)
                    {
                        int j = AddInGrSquare(emptySquare, grSquare, x, y);
                        switch (j)
                        {
                            case 3:
                                bWhite = true;
                                bBlack = true;
                                break;
                            case 2:
                                bWhite = true;
                                break;
                            case 1:
                                bBlack = true;
                                break;
                            case 0:
                                break;
                        }
                    }
                    i++;
                }
                foreach (Square square in grSquare)
                {
                    if (bWhite && bBlack)
                    {
                        square.SetEnum(1);
                    }
                    else if (bWhite)
                    {
                        square.SetEnum(2);
                    }
                    else if (bBlack)
                    {
                        square.SetEnum(3);
                    }
                    else
                    {
                        square.SetEnum(0);
                    }
                }
            }
            int iBlack = 0;
            int iWhite = 0;
            foreach (Square s in emptySquare)
            {
                if (s.GetEnumOccupation() == Square.occupate.Black)
                {
                    iBlack++;
                }
                else if (s.GetEnumOccupation() == Square.occupate.White)
                {
                    iWhite++;
                }
            }
            if (lstPlayers[0].Color == COLOR_PLAYER1)
            {
                lstPlayers[0].CountPoint = iBlack + lstPlayers[0].CountTakenStone;
                lstPlayers[1].CountPoint = iWhite + lstPlayers[1].CountTakenStone + 6.5;
            }
            else
            {
                lstPlayers[0].CountPoint = iWhite + lstPlayers[0].CountTakenStone;
                lstPlayers[1].CountPoint = iBlack + lstPlayers[1].CountTakenStone + 6.5;

            }
        }
        public void Update(MouseState mouseState, KeyboardState keyBoard)
        {
            if (bIsOver)
            {
                bool b = true;
                if(bIsInCount)
                {
                    if (mouseState.LeftButton == ButtonState.Released)
                    {
                        bIsInCount = false;
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    btnViewEndGame.Update(mouseState);
                    if (btnViewEndGame.GetBtnIsViewEndGame())
                    {
                        initialise();
                    }
                }
            }
            else
            {
                if (bIsInCount)
                {
                        btnEndGame.Update(mouseState);
                    if (btnEndGame.GetBtnIsEndGame())
                    {
                        CountPointEndGame();
                        if (lstPlayers[0].CountPoint > lstPlayers[1].CountPoint)
                        {
                            lstPlayers[0].IsWin = true;
                        }
                        else
                        {
                            lstPlayers[1].IsWin = true;
                        }
                        bIsOver = true;
                    }
                    else
                    {
                        foreach (Square s in board.GetLstSquare())
                        {
                            if (Collision(s, mouseState))
                            {
                                if (tabStone[s.GetPositionX()][s.GetPositionY()] != null)
                                {
                                    colorDeadStoneEndGame = tabStone[s.GetPositionX()][s.GetPositionY()].Color;
                                    SuppStoneEndGame(s);
                                    List<Stone> deadStone = new List<Stone>();
                                    for (int i = 0; i < lengthBoard; i++)
                                    {
                                        for (int j = 0; j < lengthBoard; j++)
                                        {
                                            Stone stone = tabStone[i][j];
                                            if (stone != null)
                                            {
                                                if (!stone.IsAlive)
                                                {
                                                    deadStone.Add(stone);
                                                }
                                            }
                                        }
                                    }
                                    foreach (Player p in lstPlayers)
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
                                    foreach (Square square in board.GetLstSquare())
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
                            bIsInCount = true;
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
                                            lstPlayers[1].CountTakenStone++;
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
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (bIsOver)
            {
                string strMessage;
                double dblCountDifference;
                if (lstPlayers[0].IsWin)
                {
                    if (lstPlayers[0].Color == COLOR_PLAYER1)
                    {
                        dblCountDifference = lstPlayers[0].CountPoint - lstPlayers[1].CountPoint;
                        strMessage = "joueur 1 a gagne de " + dblCountDifference + " points";
                    }
                    else
                    {
                        dblCountDifference = lstPlayers[0].CountPoint - lstPlayers[1].CountPoint;
                        strMessage = "joueur 2 a gagne de " + dblCountDifference + " points";
                    }
                }
                else
                {
                    if (lstPlayers[1].Color == COLOR_PLAYER1)
                    {
                        dblCountDifference = lstPlayers[1].CountPoint - lstPlayers[0].CountPoint;
                        strMessage = "joueur 1 a gagne de " + dblCountDifference + " points";
                    }
                    else
                    {
                        dblCountDifference = lstPlayers[1].CountPoint - lstPlayers[0].CountPoint;
                        strMessage = "joueur 2 a gagne de " + dblCountDifference + " points";
                    }

                }
                btnViewEndGame.ViewWhenWinner = strMessage;
                btnViewEndGame.Draw(spriteBatch);
            }
            else
            {
                board.Draw(spriteBatch);
                foreach (Player p in lstPlayers)
                {
                    p.Draw(spriteBatch);
                }
                btnReturn.Draw(spriteBatch);
                btnPass.Draw(spriteBatch);
                if (bIsInCount)
                {
                    btnEndGame.Draw(spriteBatch);
                }
            }
        }
    }
}
