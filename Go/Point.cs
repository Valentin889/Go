using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Go
{
    public class Point
    {
        private int iPosX;
        private int iPosY;
        private int iSize;
        public Point(int x , int y , int size)
        {
            iPosX = x;
            iPosY = y;
            iSize = size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressource.GetStone(), new Rectangle(iPosX-iSize/2, iPosY - iSize / 2, iSize, iSize), Color.Black);
        }
    }
}
