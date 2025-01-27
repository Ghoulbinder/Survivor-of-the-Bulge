using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class ClassButton
    {
        Texture2D txr;
        Vector2 position;
       private Rectangle rect;
        Color tint = new Color(255, 255, 255, 255);

       // public Vector2 size;
       

        public ClassButton(Texture2D newtxr, GraphicsDevice graphics)
        {
            txr = newtxr;

           // size = new Vector2(graphics.Viewport.Width / 15, graphics.Viewport.Height / 36.5f);
            rect = new Rectangle((int)position.X, (int)position.Y, txr.Width, txr.Height);
        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
           
            
            //adds a fade and glow effect to the button when the mouse is hovering over th button
            if (rect.Contains(mouse.X, mouse.Y))
            {
                if (tint.A >= 225)
                    down = false;
                if (tint.A <= 0)
                    down = true;
                if (down == true)
                    tint.A += 3;
                else
                    tint.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed)
                    isClicked = true;
            }

            else if (tint.A < 225)
            {
                tint.A = +3;
                isClicked = false;
            }


        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
            rect.Location = position.ToPoint();
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(txr, rect, tint);
        }
    }
}
