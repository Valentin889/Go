﻿using System;
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
        
        public void Update(MouseState mouseState, KeyboardState keyBoard)
        {
            btnReturn.Update(mouseState);
            if(btnReturn.getbtnReturnIsDelete())
            {
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
