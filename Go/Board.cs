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
        private List<Player> lstPlayers;
        private List<Line> lstLines;

        private int iSizeBoard;
        private int iLengthBoard;
        private int iSeperateLine;

        public Board(int length)
        {

            iSizeBoard = MainGame.windowsHeight - 200;
            Ressource.SetBoard();
            


            iLengthBoard = length;

            iSeperateLine = iSizeBoard / (length-1);
            lstLines = new List<Line>();
            InitialiseLines();

            lstPlayers = new List<Player>();
            lstPlayers.Add(new Player(Color.Black));
            lstPlayers.Add(new Player(Color.White));


        }
        private void InitialiseLines ()
        {
            for(int i=0; i< iLengthBoard; i++)
            {

                lstLines.Add(new Line(20, iSizeBoard+20,20+i * iSeperateLine, 20 + i * iSeperateLine));
                lstLines.Add(new Line(20+i*iSeperateLine, 20+i*iSeperateLine,20,iSizeBoard+20));
            }
        }
        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            foreach(Player p in lstPlayers)
            {
                p.Update(mouseState,keyboardState);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressource.GetBoard(),new Rectangle(20,20,iSizeBoard,iSizeBoard),Color.White);
            


           foreach(Line l in lstLines)
            {
                l.Draw(spriteBatch);
            }
            


            /*
            foreach (Player p in lstPlayers)
            {
                p.Draw(spriteBatch);
            }
            */

        }
       
    }
}
