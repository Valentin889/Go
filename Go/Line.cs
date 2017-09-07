using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Go
{
    public class Line
    {
        private int iStartX;
        private int iEndX;
        private int iStartY;
        private int iEndY;
        public Line(int isx, int ienx, int isy, int ieny)
        {
            iStartX = isx;
            iStartY = isy;
            iEndX = ienx;
            iEndY = ieny;
        }

        public Line Clone()
        {
            Line returnLine = new Line(this.iStartX,this.iEndX,iStartY,iEndY);
            return returnLine;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Ressource.CreateLine(spriteBatch, new Vector2(iStartX,iStartY), new Vector2(iEndX, iEndY));

        }
    }
}
