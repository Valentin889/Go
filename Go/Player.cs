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
        private List<Stone> lstStones;
        private Color myColor;


        public Player(Color c)
        {
            lstStones = new List<Stone>();
            lstStones.Add(new Stone(Color.Black));
            myColor = c;
        }



       
        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            if(mouseState.LeftButton==ButtonState.Pressed)
            {

                Stone s = new Stone(myColor);
                s.PositionX = mouseState.Position.X;
                s.PositionY = mouseState.Position.Y;
                s.DefinitivePosition = true;
                lstStones.Add(s);
            }



            foreach (Stone s in lstStones)
            {
                s.Update(mouseState, keyboardState);
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
