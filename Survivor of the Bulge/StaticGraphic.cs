using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class StaticGraphic
    {
        private Vector2 m_position;
        private Texture2D m_txr;
        
        public StaticGraphic(Texture2D txr, int xpos, int ypos)
        {
            m_position = new Vector2(xpos, ypos);
            m_txr = txr;
          
        }

        public void DrawMe(SpriteBatch sb)
        {

            sb.Draw(m_txr, m_position, Color.White);
        }

    }
}
