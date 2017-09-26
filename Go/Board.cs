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
    public class Board
    {
        private MainGo parent;
        private Rectangle hitbox;
        
        private List<Line> lstLines;
        private List<Square> lstSquare;
        private List<Point> lstPoint;
        
        public Board(MainGo mainGo)
        {
            parent = mainGo;
            hitbox = new Rectangle(parent.GetBoardPositionX(), parent.GetBoardPositionY(), parent.GetSizeBoard(), parent.GetSizeBoard());

            Ressource.SetBoard();

            
            lstLines = new List<Line>();
            lstSquare = new List<Square>();
            lstPoint = new List<Point>();

            InitialiseLines();
            InitialiseSquare();
            InitialisePoint();
        }

        public Board Clone()
        {
            Board boardReturn = new Board(this.parent);
            boardReturn.hitbox = this.hitbox;
            boardReturn.lstLines = new List<Line>();
            foreach (Line l in lstLines)
            {
                boardReturn.lstLines.Add(l.Clone());
            }


            boardReturn.lstSquare = new List<Square>();
            foreach(Square s in lstSquare)
            {
                boardReturn.lstSquare.Add(s.Clone());
            }

            return boardReturn;

        }
        private void InitialiseLines ()
        {
            
            for(int i=0; i< parent.GetLengthBoard(); i++)
            {
                lstLines.Add(new Line(parent.GetBoardPositionX(), parent.GetSizeBoard() + parent.GetBoardPositionX(), parent.GetBoardPositionY() + i * parent.GetSeperateLine(), parent.GetBoardPositionY() + i * parent.GetSeperateLine()));
                lstLines.Add(new Line(parent.GetBoardPositionX() + i * parent.GetSeperateLine(), parent.GetBoardPositionX() + i * parent.GetSeperateLine(), parent.GetBoardPositionY(), parent.GetSizeBoard() + parent.GetBoardPositionY()));
            }
            
        }
        private void InitialiseSquare()
        {
            for(int i=0; i<parent.GetLengthBoard();i++)
            {
                for(int j=0; j<parent.GetLengthBoard();j++)
                {
                    Square s = new Square(i, j, this);
                    s.SetHitbox(parent.GetBoardPositionX() + i * parent.GetSeperateLine()-parent.GetSeperateLine()/2, parent.GetBoardPositionY() + j * parent.GetSeperateLine() - parent.GetSeperateLine() / 2, parent.GetSeperateLine()-2, parent.GetSeperateLine()-2);
                    lstSquare.Add(s);    
                
                }
            }
        }

        private void InitialisePoint()
        {
            
            if (parent.GetLengthBoard() <= 9)
            {
                for (int i = 2; i < parent.GetLengthBoard()-2; i += parent.GetLengthBoard()-5)
                {
                    for (int j = 2; j < parent.GetLengthBoard()-2; j += parent.GetLengthBoard() - 5)
                    {
                        lstPoint.Add(new Point(i * parent.GetSeperateLine() + parent.GetBoardPositionX(), j * parent.GetSeperateLine() + parent.GetBoardPositionY(), lstSquare[0].GetHitbox().X / 5));
                    }
                }
            }
            else
            {
                int iInterval = (parent.GetLengthBoard() - 7) / 2;

                for (int i = 3; i < parent.GetLengthBoard()-3; i+=iInterval)
                {
                    for (int j = 3; j < parent.GetLengthBoard() - 3; j += iInterval)
                    {
                        lstPoint.Add(new Point(i * parent.GetSeperateLine() + parent.GetBoardPositionX(), j * parent.GetSeperateLine() + parent.GetBoardPositionY(), lstSquare[0].GetHitbox().X / 5));
                    }
                }
            }
        }
        public List<Square> GetSquare()
        {
            return lstSquare;
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressource.GetBoard(),this.hitbox,Color.White);
            


           foreach(Line l in lstLines)
            {
                l.Draw(spriteBatch);
            }
            foreach(Square s in lstSquare)
            {
                s.Draw(spriteBatch);
            }
          
            foreach(Point p in lstPoint)
            {
                p.Draw(spriteBatch);
            }
        }
       
    }
}
