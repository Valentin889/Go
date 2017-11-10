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
    public class Player
    {
        private MainGo parent;
        private List<Stone> lstStones;
        private Color myColor;
        Stone s;
        bool bStoneHere;
        private int iCountTakenStone;
        private int iCountPoints;
        public Player(Color c, MainGo mainGo)
        {
            parent = mainGo;
            lstStones = new List<Stone>();
            myColor = c;
            bStoneHere = false;
            iCountTakenStone = 0;
            iCountPoints = 0;
        }


        public List<Stone> GetLstStone()
        {
             return lstStones;
        }
        public void SetListStone(List<Stone> newList)
        {
            lstStones = newList;
        }
       public int CountTakenStone
        {
            get
            {
                return iCountTakenStone;
            }
            set
            {
                iCountTakenStone = value;
            }
        }

        public int CountPoint
        {
            get
            {
                return iCountPoints;
            }
            set
            {
                iCountPoints = value;
            }
        }

        public Player Clone()
        {
            Player returnplayer = new Player(this.Color, this.parent);

            returnplayer.lstStones = new List<Stone>();
            foreach(Stone s in this.lstStones)
            {
                returnplayer.lstStones.Add(s.Clone());
            }


            return returnplayer;
        }

        public MainGo getParent()
        {
            return parent;
        }

        public bool GetStoneHere()
        {
            return bStoneHere;
        }

        public Color Color
        {
            get
            {
                return myColor;
            }
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
        public bool Update(MouseState mouseState, KeyboardState keyboardState)
        {
            bStoneHere = false;
            int iCountStone = lstStones.Count();
            foreach (Square t in parent.GetBoard().GetLstSquare())
            {
                if (Collision(t, mouseState))
                {
                    int iSizeStone = t.GetHitbox().Width;
                    s = new Stone(myColor, this, iSizeStone);
                    s.PositionX = t.GetPositionX();
                    s.PositionY = t.GetPositionY();

                    if (parent.GetTabStone()[s.PositionX][s.PositionY] == null)
                    {
                        parent.OldGame = parent.Clone();
                        lstStones.Add(s);
                    }
                    else
                    {
                        bStoneHere = true;
                    }

                }
            }
            if(iCountStone==lstStones.Count)
            {
                return false;
            }
            else
            {
                return true;
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
