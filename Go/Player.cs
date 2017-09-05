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
        public Player(Color c, MainGo Parent)
        {
            parent = Parent;
            lstStones = new List<Stone>();
            myColor = c;
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
        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            if(mouseState.LeftButton==ButtonState.Pressed)
            {
                s = new Stone(myColor, this);
                
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
