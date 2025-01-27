using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class Leafs
    {
        Texture2D m_txr;

        Vector2 m_position;
        Vector2 m_velocity;
        float m_rotation;
        float m_rotationSpeed;
        public Leafs(Texture2D txr, Random RNG, int maxX)
        {


            m_txr = txr;
            m_position = new Vector2(RNG.Next(0, maxX), 0);
            m_velocity = new Vector2(0, (float)RNG.NextDouble() + 0.25f);

            m_rotation = 0;
            m_rotationSpeed = ((float)RNG.NextDouble() - 0.5f) / 4;

        }

        public void Updateme(Random RNG, int maxX, int maxY)
        {
            m_position = m_position + m_velocity;
            m_rotation = m_rotation + m_rotationSpeed;

            if (m_position.Y > maxY)
            {
                m_position = new Vector2(RNG.Next(0, maxX), 0);
                m_velocity = new Vector2(0, (float)RNG.NextDouble() + 0.25f);
                m_rotationSpeed = ((float)RNG.NextDouble() - 0.5f) / 4;

            }
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, m_position, null, Color.White * 0.75f,
                m_rotation, Vector2.Zero, m_velocity.Y, SpriteEffects.None, 0);

        }


    }


}
