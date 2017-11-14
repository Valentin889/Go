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
        private bool bIsAlreadyVisite;
        private int iEndGameColor;
        private occupate enumOcupation;

        public enum occupate
        {
            Null, Neutral,White,Black
        }
        public void SetEnum(int i)
        {
            switch(i)
            {
                case 0:
                    enumOcupation = occupate.Null;
                    break;
                case 1:
                    enumOcupation = occupate.Neutral;
                    break;
                case 2:
                    enumOcupation = occupate.White;
                    break;
                case 3:
                    enumOcupation = occupate.Black;
                    break;
            }
        } 
        public occupate GetEnumOccupation()
        {
            return enumOcupation;
        }
        public Square(int x, int y, Board board)
        {
            iPositionX = x;
            iPositionY = y;
            parent = board;
            bIsAlreadyVisite=false;
        }
        public void SetHitbox(int x, int y,int width, int heigth)
        {
            hitbox = new Rectangle(x, y, width, heigth);
        }

        public Square Clone()
        {
            Square returnSquare = new Square(this.hitbox.X, this.hitbox.Y, parent);
            returnSquare.hitbox = this.hitbox;
            returnSquare.iPositionX = this.iPositionX;
            returnSquare.iPositionY = this.iPositionY;
            return returnSquare;
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
        public bool IsAlreadyVisit
        {
            get
            {
                return bIsAlreadyVisite;
            }
            set
            {
                bIsAlreadyVisite = value;
            }
        }
        public int EndGameColor
        {
            get
            {
                return iEndGameColor;
            }
            set
            {
                iEndGameColor = value;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressource.GetSquare(), this.hitbox, Color.Black);
        }
    }
}
