using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Go
{
    public class Square
    {
        private Rectangle hitbox;
        private Board parent;
        private int iPositionX;
        private int iPositionY;
        public Square(int x, int y, Board board)
        {
            iPositionX = x;
            iPositionY = y;
            parent = board;

        }
        public void SetHitbox(int x, int y,int width, int heigth)
        {
            hitbox = new Rectangle(x, y, width, heigth);
        }

        public Rectangle GetHitbox()
        {
            return hitbox;
        }
        public int GetPositionX()
        {
            return iPositionX;
        }
        public int GetPositionY()
        {
            return iPositionY;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressource.GetSquare(), this.hitbox, Color.Black);
        }
    }
}
