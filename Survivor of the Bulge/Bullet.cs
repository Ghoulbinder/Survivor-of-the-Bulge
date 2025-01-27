using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class Bullet
    {

        
        
            public Rectangle Frame;
            public Texture2D Image;
            public Color Tint;

            public Bullet(int x, int y, Texture2D txr, Color col)
            {
                // Set Image to txr
                Image = txr;
                // Set Frame to a new Rectangle at (x, y) with Width of txr.Width and height of txr.Height
                Frame = new Rectangle(x, y, txr.Width, txr.Height);
                // Set Tint to col
                Tint = col;

            }
            public void DrawMe(SpriteBatch sb)
            {
                // Draw the Image using the given spriteBatch in Frame with colour Tint
                sb.Draw(Image, Frame, Tint);
            }
    }


        class MovingBullet
        {

            public Rectangle Frame;
            private Texture2D image;
            private Color tint;
            private float xspeed = 2;


            public MovingBullet(Rectangle rect, Texture2D txr, Color col, int speed)
            {
                // Set Frame to rect
                Frame = rect;
                // Set image to txr
                image = txr;
                // Set tint to col
                tint = col;
                // Set yspeed to 0
                xspeed = speed;

            }

            public void UpdateMe()
            {
           

                Frame.X += (int)xspeed;
               // Frame.Y += (int)xspeed;

            }

            public void DrawMe(SpriteBatch sb)
            {
                // Draw the image using the given spriteBatch in Frame with colour tint
                sb.Draw(image, Frame, tint);
            }
        }

    
}
