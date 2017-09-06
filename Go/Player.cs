﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go
{
    public class Player
    {
        private MainGo parent;
        private List<Stone> lstStones;
        private Color myColor;
        Stone s;
        bool bStoneHere;
        public Player(Color c, MainGo mainGo)
        {
            parent = mainGo;
            lstStones = new List<Stone>();
            myColor = c;
            bStoneHere = false;
        }


        public List<Stone> GetListStone
        {
            get
            {
                return lstStones;
            }
        }
       
        public MainGo getParent()
        {
            return parent;
        }

        public bool GetStoneHere()
        {
            return bStoneHere;
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
        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            bStoneHere = false;
            foreach (Square t in parent.GetBoard().GetSquare())
            {
                if (Collision(t, mouseState))
                {
                    int iSizeStone = t.GetHitbox().Width / 2;
                    s = new Stone(myColor, this, iSizeStone);
                    s.PositionX = t.GetPositionX();
                    s.PositionY = t.GetPositionY();

                    if (parent.getTabStone()[s.PositionX][s.PositionY] == null)
                    {
                        lstStones.Add(s);
                    }
                    else
                    {
                        bStoneHere = true;
                    }

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Stone s in lstStones)
            {
                s.Draw(spriteBatch);
            }
        }
    }
}
