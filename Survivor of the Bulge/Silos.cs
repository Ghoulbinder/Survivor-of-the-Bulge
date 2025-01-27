using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class Silos
    {
        private Texture2D m_art;
        private Vector2 m_position;
        public Rectangle CollisionRect;
        public Silos(Texture2D art, int xPos, int yPos)
        {
            m_art = art;
            m_position = new Vector2(xPos, yPos);
            CollisionRect = new Rectangle(xPos, yPos, art.Width, art.Height);
        }
        public void moveTo(int xpos, int ypos)
        {
            m_position.X = xpos;
            m_position.Y = ypos;

            CollisionRect.X = (int)m_position.X;
            CollisionRect.Y = (int)m_position.Y;
        }

        public void drawME(SpriteBatch sb)
        {
            sb.Draw(m_art, m_position, CollisionRect, Color.White);
        }

    }
}
