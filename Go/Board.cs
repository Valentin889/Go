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

        private int iLength;
        private int iSeperateLine;

        public Board(int length)
        {
            iLength = length;
            iSeperateLine = MainGame.windowsHeight / (length-1);
            lstLines = new List<Line>();
            InitialiseLines();

            lstPlayers = new List<Player>();
            lstPlayers.Add(new Player(Color.Black));
            lstPlayers.Add(new Player(Color.White));


        }
        private void InitialiseLines ()
        {
            for(int i=0; i<iLength;i++)
            {
                lstLines.Add(new Line(0, MainGame.windowsWidth, i*iSeperateLine, i*iSeperateLine));
                lstLines.Add(new Line(i*iSeperateLine, i*iSeperateLine,0,MainGame.windowsHeight));
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
