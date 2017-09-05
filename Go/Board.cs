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
        



        public Board(MainGo Parent)
        {
            parent = Parent;
            
            hitbox = new Rectangle(parent.GetBoardPositionX(), parent.GetBoardPositionY(), parent.GetSizeBoard(), parent.GetSizeBoard());
            



            Ressource.SetBoard();

            
            lstLines = new List<Line>();
            InitialiseLines();

            


        }
        private void InitialiseLines ()
        {
            
            for(int i=0; i< parent.GetLengthBoard(); i++)
            {
                lstLines.Add(new Line(parent.GetBoardPositionX(), parent.GetSizeBoard() + parent.GetBoardPositionX(), parent.GetBoardPositionY() + i * parent.GetSeperateLine(), parent.GetBoardPositionY() + i * parent.GetSeperateLine()));
                lstLines.Add(new Line(parent.GetBoardPositionX() + i * parent.GetSeperateLine(), parent.GetBoardPositionX() + i * parent.GetSeperateLine(), parent.GetBoardPositionY(), parent.GetSizeBoard() + parent.GetBoardPositionY()));
            }
            
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
            
          

        }
       
    }
}
