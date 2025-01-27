using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class Enemy
    {
        enum animState
        {
            walkingRight,
            walkingLeft,
          
        }
        public enum GameState 
        { 
         walkingRight,
         walkingLeft,
         
        
        }
        private animState m_currState;
        public Rectangle m_animSpriteWalkingLeft;
        private Vector2 m_velocity;
        public Vector2 m_position;
        private int speed;
        public Texture2D m_walkingLeftSprite;
        private float m_frameTimer;
        private float m_fps;
        public GameState CurrGameState;// = GameState.walkingRight;
        public Rectangle CollisionRect;

        public Enemy(Texture2D walkSpriteLeft, 
                      int x, int y, int initialSpeed, int fps)
        {
            m_currState = animState.walkingLeft;
            m_position = new Vector2(x, y);

            speed = initialSpeed;
            m_velocity = new Vector2(0, 0);

            m_animSpriteWalkingLeft = new Rectangle(0, 0, walkSpriteLeft.Width / 4, walkSpriteLeft.Height);
       
            CollisionRect = new Rectangle(x, y, walkSpriteLeft.Width /4, walkSpriteLeft.Height);

            m_walkingLeftSprite = walkSpriteLeft;
            m_frameTimer = 1;
            m_fps = fps;


        }

        public void updateMe(int walkDistanceRight, int walkDistnaceLeft)
        {
            m_position.X += speed;
            
            //need to find out the distance the enemy can walk back and forth from
            if (m_position.X > walkDistanceRight)
            {
                speed = -1;
                m_currState = animState.walkingLeft;
                CurrGameState = GameState.walkingLeft;
            }
            else if(m_position.X < walkDistnaceLeft)
            {
                speed = 1;
                m_currState = animState.walkingRight;
                CurrGameState = GameState.walkingRight;

            }
       

            //collision
            m_position += m_velocity;
            CollisionRect.X = (int)m_position.X;
            CollisionRect.Y = (int)m_position.Y;

        }
            
        public void drawMe(SpriteBatch sb, GameTime gt)
        {
            if (m_frameTimer <= 0)
            {
                m_animSpriteWalkingLeft.X = (m_animSpriteWalkingLeft.X + m_animSpriteWalkingLeft.Width);
                if( m_animSpriteWalkingLeft.X >= m_walkingLeftSprite.Width)
                {  
                    m_animSpriteWalkingLeft.X = 0;
                }
                m_frameTimer = 1;

            }
            else
            {
                m_frameTimer -= (float)gt.ElapsedGameTime.TotalSeconds * m_fps;
            }
            switch (m_currState)
            {
                case animState.walkingLeft:
                    sb.Draw(m_walkingLeftSprite, m_position, m_animSpriteWalkingLeft, Color.White);
                    break;
                case animState.walkingRight:
                    sb.Draw(m_walkingLeftSprite, m_position, m_animSpriteWalkingLeft, Color.White,
                        0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                    break;
               
            }
        }


    }
}
