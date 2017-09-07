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

        
        public Board(MainGo mainGo)
        {
            parent = mainGo;
            hitbox = new Rectangle(parent.GetBoardPositionX(), parent.GetBoardPositionY(), parent.GetSizeBoard(), parent.GetSizeBoard());

            Ressource.SetBoard();

            
            lstLines = new List<Line>();
            lstSquare = new List<Square>();
            InitialiseLines();
            InitialiseSquare();

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
          

        }
       
    }
}
