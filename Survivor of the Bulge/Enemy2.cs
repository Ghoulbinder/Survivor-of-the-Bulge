using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survivor_of_the_Bulge
{
    class Enemy2
    {
        enum animState
        {
            
            walkingBack,
            walkingFront
        }
        public enum GameState
        {
          
            walkingBack,
            walkingFront

        }
        private animState m_currState;
        public Rectangle m_animSpriteWalkingBack, m_animSpriteWalkingFront;
        private Vector2 m_velocity;
        public Vector2 m_position;
        private int speed;
        
        public Texture2D m_walkingBackSprite;
        public Texture2D m_walkingFrontSprite;
        private float m_frameTimer;
        private float m_fps;
        public GameState CurrGameState = GameState.walkingBack;
        public Rectangle CollisionRect;

        public Enemy2(Texture2D walkSpriteFront,
                     Texture2D WalkSpriteBack, int x, int y, int initialSpeed, int fps)
        {
            m_currState = animState.walkingBack;
            m_position = new Vector2(x, y);

            speed = initialSpeed;
            m_velocity = new Vector2(0, 0);

            m_animSpriteWalkingBack = new Rectangle(0, 0, WalkSpriteBack.Width / 4, WalkSpriteBack.Height);
            m_animSpriteWalkingFront = new Rectangle(0, 0, walkSpriteFront.Width / 4, walkSpriteFront.Height);

            CollisionRect = new Rectangle(x, y, WalkSpriteBack.Width, WalkSpriteBack.Height);

           
            m_walkingBackSprite = WalkSpriteBack;
            m_walkingFrontSprite = walkSpriteFront;
            m_frameTimer = 1;
            m_fps = fps;


        }

        public void updateMe(int walkDistanceUp, int walkDistandDown)
        {
           
            m_position.Y += speed;
            //need to find out the distance the enemy can walk back and forth from
           
            
            if (m_position.Y > walkDistanceUp)
            {
                speed = 1;
                m_currState = animState.walkingFront;
                CurrGameState = GameState.walkingFront;
            }
            else if (m_position.Y < walkDistandDown)
            {
                speed = -1;
                m_currState = animState.walkingBack;
                CurrGameState = GameState.walkingBack;
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
             
                m_animSpriteWalkingBack.X = (m_animSpriteWalkingBack.X + m_animSpriteWalkingBack.Width);
                if (m_animSpriteWalkingBack.X >= m_walkingBackSprite.Width)
                {
                    m_animSpriteWalkingBack.X = 0;
                }
                m_animSpriteWalkingFront.X = (m_animSpriteWalkingFront.X + m_animSpriteWalkingFront.Width);
                if (m_animSpriteWalkingFront.X >= m_walkingFrontSprite.Width)
                {
                    m_animSpriteWalkingFront.X = 0;
                }
                m_frameTimer = 1;
            }
            else
            {
                m_frameTimer -= (float)gt.ElapsedGameTime.TotalSeconds * m_fps;
            }
            switch (m_currState)
            {
                
                case animState.walkingBack:
                    sb.Draw(m_walkingBackSprite, m_position, m_animSpriteWalkingBack, Color.White);
                    break;
                case animState.walkingFront:
                    sb.Draw(m_walkingFrontSprite, m_position, m_animSpriteWalkingFront, Color.White);
                    break;
            }
        }


    }
}