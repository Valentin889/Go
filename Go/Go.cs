using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Go
{
    public class Go
    {
        private List<Player> lstPlayers;
        private Board board;



        public Go()
        {
            lstPlayers = new List<Player>();
            lstElement = new List<Element>();

            initialise();
        }

        private void initialise()
        {
            lstElement.Add(new Board(9));

        }

        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            foreach(Element e in lstElement)
            {
                
            }
            foreach(Player p in lstPlayers)
            {
                p.Update(mouseState, keyboardState);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           
        }

    }
}
