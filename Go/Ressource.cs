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
        private static Texture2D stone;
        private static Texture2D line;
        private static Texture2D square;
        private static Texture2D board;
        private static GraphicsDevice graphic;

        public static void LoadContent(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            graphic = graphicsDevice;
            

            stone = CreateCircle(30, graphic);
            line = new Texture2D(graphic, 1, 1);
            square = new Texture2D(graphic, 1, 1);
            //square.SetData<Color>(new Color[] { Color.White });
            line.SetData<Color>(new Color[] {Color.White});
            
        }
        

        public static Texture2D GetStone()
        {
            return stone;
        }

        public static Texture2D GetBoard()
        {
            return board;
        }

        public static Texture2D GetSquare()
        {
            return square;
        }
        public static void SetBoard()
        {
            board = new Texture2D(graphic, 1,1);
            board.SetData<Color>(new Color[] { Color.White });

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

            sb.Draw(line, new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), 5),null,Color.Black, angle, new Vector2(0, 0), SpriteEffects.None, 0);


        }


    }
}
