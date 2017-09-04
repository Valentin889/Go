using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go
{
    public class Ressource
    {
        private static Texture2D goban1;
        private static Texture2D stone;
        private static Texture2D line;

        public static void LoadContent(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            goban1 = Content.Load<Texture2D>("goban1");
            stone = CreateCircle(30, graphicsDevice);
            line = new Texture2D(graphicsDevice, 1, 1);
            line.SetData<Color>(new Color[] {Color.White});
        }

        public static Texture2D GetGoban1()
        {
            return goban1;
        }

        public static Texture2D GetStone()
        {
            return stone;
        }
        private static Texture2D CreateCircle(int radius, GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }


        public static void CreateLine(SpriteBatch sb, Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), 1);



            sb.Draw(line,
            new Rectangle(// rectangle defines shape of line and position of start of line
                (int)start.X,
                (int)start.Y,
                (int)edge.Length(), //sb will strech the texture to fill this rectangle
                5), //width of line, change this to make thicker line
            null,
            Color.Black, //colour of line
            angle,     //angle of line (calulated above)
            new Vector2(0, 0), // point in line about which to rotate
            SpriteEffects.None,
            0);


        }


    }
}
