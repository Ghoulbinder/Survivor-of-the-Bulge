using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Survivor_of_the_Bulge
{
    //WORK ON SOLDIER ANIMATION FRONT AND BACK
    // work on player limited animation for diagonal directions
    //firgure out why the enemy is walking offscreen 

    //working on the play buttoon which is not working
    
   //work on facts screen
   
    //TRESSBOXES TO PREVENT PLAYER FORM GOING TRHOUGH THE FORESTS
    //loads list of enemies
    //TO DO FOR LOOP FOR ADDING ENEMIES
    //need to find out the distance the enemy can walk back and forth from
    //set some trees in the forground so player can walk behind them
    //add notes for the player to find
    //add the silos
    // make a cutscene in illustrator for solder jumping into the forest if possible
    // add more boxes for the forest
    // need to figure out why the player is not animating properly

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public readonly static Random RNG = new Random();

        public bool playerMovingRight, playerMovingUp;

        SpriteFont jungleFont;
        public Texture2D background;
        Bullet bullet;

        Enemy enemy;
        Enemy2 enemy2;
        List<Enemy> enemies;
        List<Enemy2> enemies2;
        List<MovingBullet> ammo;
        List<TreesBox> boxes, boxes2, boxes3;

        Leafs[] leafs, snowFlake;
        const int leafsFall = 32;
        soldier player;
       

        public Texture2D ammotxr;


        MouseState ms;
        GamePadState currPad, oldPad;
        KeyboardState kb, oldkb;
        enum GameState
        {
            mainMenu,
            forestCentre,
            forestTop,
            forestButtom,
            forestLeft,
            forestRight,
            factsScreen

        }

        GameState CurrentGameState = GameState.mainMenu;
        ClassButton playButton, factsScreenButton;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            leafs = new Leafs[leafsFall];
            snowFlake = new Leafs[leafsFall];

            playerMovingRight = true;
            playerMovingUp = true;

           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("Maps/greenForestCentre");

            ammotxr = Content.Load<Texture2D>("bullet");
            ammo = new List<MovingBullet>();


            player = new soldier(Content.Load<Texture2D>("Soldier/walkLeft"),
               Content.Load<Texture2D>("Soldier/frontWalking"),
               Content.Load<Texture2D>("Soldier/backWalking"), 800, 400, 24);


            bullet = new Bullet(player.collisionRect.X, player.collisionRect.Y,
                Content.Load<Texture2D>("bullet"), Color.White);

           


            enemies = new List<Enemy>();
            enemies2 = new List<Enemy2>();
    
            enemy = new Enemy(Content.Load<Texture2D>("Enemy/enemyLeftWalking"), 1200, 600, 2, 24);
            enemy2 = new Enemy2(Content.Load<Texture2D>("Enemy/enemyFrontWalking"),
                                 Content.Load<Texture2D>("Enemy/enemyBackWalking"), 1000, 700, 2, 24);

            jungleFont = Content.Load<SpriteFont>("Maps/jungleFont");
            playButton = new ClassButton(Content.Load<Texture2D>("Maps/playButton"), _graphics.GraphicsDevice);
            playButton.SetPosition(new Vector2(1450, 1300));

            for (int i = 0; i < 5; i++)
            {
                enemies.Add(new Enemy(enemy.m_walkingLeftSprite, 1300, 600, 0, 24));

            }
            for (int i = 0; i < 5; i++)
            {
                enemies2.Add(new Enemy2(enemy2.m_walkingFrontSprite, enemy2.m_walkingBackSprite, 1400, 600, 0, 24));

            }

            for (int i = 0; i < leafs.GetLength(0); i++)
            {
                //   set the current ("i"ith) element of the leaves array to be a new Leafs a random location using the texture "tinyleaf" and a random location on the X
                leafs[i] = new Leafs(Content.Load<Texture2D>("Maps/tinyleaf"), RNG, _graphics.PreferredBackBufferWidth);

            }

            for (int i = 0; i < snowFlake.GetLength(0); i++)
            {
                //   set the current ("i"ith) element of the leaves array to be a new Leafs a random location using the texture "tinyleaf" and a random location on the X
                snowFlake[i] = new Leafs(Content.Load<Texture2D>("Maps/snowFlake"), RNG, _graphics.PreferredBackBufferWidth);

            }
           

        }

        void mainMenuUpdate(GameTime gameTime)
        {
            ms = Mouse.GetState();
            kb = Keyboard.GetState();
            oldkb = kb;
            //playbutton
            playButton.SetPosition(new Vector2(800, 500));
            if (playButton.isClicked == true)
            {
                CurrentGameState = GameState.forestCentre;
                
            }
            playButton.Update(ms);
            //playButton.SetPosition(ms.Position.ToVector2());
        }

        void mainMenuDraw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            //draws the background of the main menu
            _spriteBatch.Draw(Content.Load<Texture2D>("Maps/mmBackground"), new Rectangle(0, 0, _graphics.PreferredBackBufferWidth,
               _graphics.PreferredBackBufferHeight), Color.White);

            
            //pitch
            _spriteBatch.DrawString(jungleFont, "It is 1944, the second world war is coming to an end." + ms, new Vector2(800, 400), Color.Black);
            _spriteBatch.DrawString(jungleFont, "You are stuck in the forest somewhere around Ardennes. ", new Vector2(800, 430), Color.Black);
            _spriteBatch.DrawString(jungleFont, "You are a soldier in world war II at the battle of the Bulge. ", new Vector2(800, 460), Color.Black);
            _spriteBatch.DrawString(jungleFont, "Your scouting plane was destroyed by the Germans, you parachuted to safety.", new Vector2(750, 490), Color.Black);
            _spriteBatch.DrawString(jungleFont, "You will need to find all your scouting documents to complete your misiion. ", new Vector2(750, 520), Color.Black);
            _spriteBatch.DrawString(jungleFont, "Beware of the Germain patrol troops, destroy their fuel silos, when possible. ", new Vector2(740, 550), Color.Black);
            _spriteBatch.DrawString(jungleFont, "Your mission is of uptmost importance, as you documents could decide the outcome of the war.", new Vector2(700, 580), Color.Black);
            _spriteBatch.DrawString(jungleFont, "When you are ready to explore the forest of Ardennes, press the play button.", new Vector2(800, 610), Color.Black);

            playButton.Draw(_spriteBatch);

            _spriteBatch.End();
        }

        void forestCentreUpdate(GameTime gametime)
        {

            currPad = GamePad.GetState(PlayerIndex.One);

            

            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingRight == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingRight == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }

            //updating bullets
            foreach (var currammo in ammo)
            {
                currammo.UpdateMe();
            }

            foreach (var curenemy in enemies)
            {
                curenemy.updateMe(1200, 800);
            }
            foreach (var curenemy2 in enemies2)
            {
                curenemy2.updateMe(200, 400);
            }

            
            boxes = new List<TreesBox>();
            boxes2 = new List<TreesBox>();
            boxes3 = new List<TreesBox>();
            //lake
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 610, 635));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 740, 635));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 740, 740));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 610, 740));
            //forests
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 180, 400));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 205, 400));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 90, 150));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 125, 160));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 930, 300));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 955, 300));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 1000, 100));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 1020, 100));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 920, 950));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 940, 950));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 250, 900));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 280, 900));

            //bottom forests left
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 90, 1400));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 100, 1400));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 320, 1300));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 360, 1300));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 520, 1300));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 560, 1300));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 320, 1400));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 360, 1400));
                                                                              
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 520, 1400));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 560, 1400));
            //right 
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 800, 1320));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 860, 1320));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 1020, 1320));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 1060, 1320));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 800, 1400));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 860, 1400));

            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 1020, 1400));
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 1060, 1400));


            //top and bottom horizontal
            boxes2.Add(new TreesBox(Content.Load<Texture2D>("Maps/box2"), 135, 1500));
            boxes2.Add(new TreesBox(Content.Load<Texture2D>("Maps/box2"), 800, 1500));
            boxes2.Add(new TreesBox(Content.Load<Texture2D>("Maps/box2"), 135, 100));
            boxes2.Add(new TreesBox(Content.Load<Texture2D>("Maps/box2"), 800, 50));
            
            //left vritical
            boxes3.Add(new TreesBox(Content.Load<Texture2D>("Maps/box3"), 115, 90));
            boxes3.Add(new TreesBox(Content.Load<Texture2D>("Maps/box3"), 70, 750));
            boxes3.Add(new TreesBox(Content.Load<Texture2D>("Maps/box3"), 70, 1000));
            //right veritcal
            boxes3.Add(new TreesBox(Content.Load<Texture2D>("Maps/box3"), 1500, 100));
            boxes3.Add(new TreesBox(Content.Load<Texture2D>("Maps/box3"), 1500, 770));
            boxes3.Add(new TreesBox(Content.Load<Texture2D>("Maps/box3"), 1500, 1000));
            // add more boxes for the forest
            player.updateMe(currPad, oldPad);
            //leafs
            for (int i = 0; i < leafs.GetLength(0); i++)
            {

                leafs[i].Updateme(RNG, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
            //snowflakes
            for (int i = 0; i < snowFlake.GetLength(0); i++)
            {

                snowFlake[i].Updateme(RNG, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
            if (player.m_position.Y <= 50)
            {
                CurrentGameState = GameState.forestTop;
            }
            //removes ammo and emeny that the ammo colides with
            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = 0; j < ammo.Count; j++)
                {
                    if (enemies[i].CollisionRect.Intersects(ammo[j].Frame))
                    {
                        enemies.RemoveAt(i);
                        
                        
                        ammo.RemoveAt(j);
                        
                        break;

                    }
                }
            }
            //handles  draw boxes
            //foreach (var box in boxes)
            //{
            //    if(player.collisionRect.Intersects(box.Surface))
            //    {
            //        player.m_position = box.Surface - (int)player.m_position;
            //    }
            ////}
            //foreach (var box2 in boxes2)
            //{
            //    box2.DrawMe(_spriteBatch);
            //}
            //foreach (var box3 in boxes3)
            //{
            //    box3.DrawMe(_spriteBatch);
            //}

        }

        void forestCentreDraw(GameTime gametime)
        {
            
            _spriteBatch.Begin();
            _spriteBatch.Draw(Content.Load<Texture2D>("Maps/greenForestCentre"), new Rectangle(0, 0, _graphics.PreferredBackBufferWidth,
               _graphics.PreferredBackBufferHeight), Color.White);

          
            //draws ammo
            foreach (var currammo in ammo)
            {
                currammo.DrawMe(_spriteBatch);
            }
            //handles  draw boxes
            //foreach (var box in boxes)
            //{
            //    box.DrawMe(_spriteBatch);
            //}
            //foreach (var box2 in boxes2)
            //{
            //    box2.DrawMe(_spriteBatch);
            //}
            //foreach (var box3 in boxes3)
            //{
            //    box3.DrawMe(_spriteBatch);
            //}

            player.drawMe(_spriteBatch, gametime);
            //draw leafs
            for (int i = 0; i < leafs.GetLength(0); i++)
            {

                leafs[i].DrawMe(_spriteBatch);
            }
            //draw snowflakes
            for (int i = 0; i < snowFlake.GetLength(0); i++)
            {

                snowFlake[i].DrawMe(_spriteBatch);
            }

            foreach(var curenemy in enemies)
            {
                curenemy.drawMe(_spriteBatch, gametime);
            }
            foreach (var curenemy2 in enemies2)
            {
                curenemy2.drawMe(_spriteBatch, gametime);
            }

            _spriteBatch.End();
        }

        void forestTopUpdate(GameTime gametime)
        {

            
            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingRight == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingRight == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }

            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingUp == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingUp == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }

            //updating bullets
            foreach (var currammo in ammo)
            {
                currammo.UpdateMe();
            }

            boxes = new List<TreesBox>();
            boxes.Add(new TreesBox(Content.Load<Texture2D>("Maps/box"), 1000, 700));
            // add more boxes for the forest
            player.updateMe(currPad, oldPad);
            
        }

        void forestTopDraw(GameTime gametime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(Content.Load<Texture2D>("Maps/snowForestTop"), new Rectangle(0, 0, _graphics.PreferredBackBufferWidth,
               _graphics.PreferredBackBufferHeight), Color.White);

            player.drawMe(_spriteBatch, gametime);

            //draws ammo
            foreach (var currammo in ammo)
            {
                currammo.DrawMe(_spriteBatch);
            }
            foreach (var box in boxes)
            {
                box.DrawMe(_spriteBatch);
            }
            _spriteBatch.End();
        }

        void forestButtomUpdate(GameTime gametime)
        {
            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingRight == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingRight == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }

            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingUp == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingUp == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }

            //updating bullets
            foreach (var currammo in ammo)
            {
                currammo.UpdateMe();
            }

            boxes = new List<TreesBox>();
            boxes.Add(new TreesBox(Content.Load<Texture2D>("box"), 1000, 700));
            // add more boxes for the forest
        }

        void forestButtomDraw(GameTime gametime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(Content.Load<Texture2D>("Maps/greenForestButtom"), new Rectangle(0, 0, _graphics.PreferredBackBufferWidth,
               _graphics.PreferredBackBufferHeight), Color.White);
            player.drawMe(_spriteBatch, gametime);
            //draws ammo
            foreach (var currammo in ammo)
            {
                currammo.DrawMe(_spriteBatch);
            }
            foreach (var box in boxes)
            {
                box.DrawMe(_spriteBatch);
            }
            _spriteBatch.End();
        }

        void forestLeftUpdate(GameTime gametime)
        {
            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingRight == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingRight == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }

            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingUp == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingUp == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }

            //updating bullets
            foreach (var currammo in ammo)
            {
                currammo.UpdateMe();
            }

            boxes = new List<TreesBox>();
            boxes.Add(new TreesBox(Content.Load<Texture2D>("box"), 1000, 700));
            // add more boxes for the forest
        }

        void forestLeftDraw(GameTime gametime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(Content.Load<Texture2D>("Maps/greenForestLeft"), new Rectangle(0, 0, _graphics.PreferredBackBufferWidth,
               _graphics.PreferredBackBufferHeight), Color.White);

            //draws ammo
            foreach (var currammo in ammo)
            {
                currammo.DrawMe(_spriteBatch);
            }
            foreach (var box in boxes)
            {
                box.DrawMe(_spriteBatch);
            }
            _spriteBatch.End();
        }

        void forestRightUpdate(GameTime gametime)
        {
            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingRight == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingRight == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }

            //firing a bullet
            if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && playerMovingUp == true)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, -15));
                //shoot.Play();
            }
            else if (currPad.Buttons.A == ButtonState.Pressed && oldPad.Buttons.A == ButtonState.Released && player.playerMovingUp == false)
            {
                ammo.Add(new MovingBullet(new Rectangle(player.collisionRect.X, player.collisionRect.Y, bullet.Image.Width, bullet.Image.Height), bullet.Image, bullet.Tint, 15));
                //shoot.Play();
            }

            //updating bullets
            foreach (var currammo in ammo)
            {
                currammo.UpdateMe();
            }

            boxes = new List<TreesBox>();
            boxes.Add(new TreesBox(Content.Load<Texture2D>("box"), 1000, 700));
            // add more boxes for the forest
        }

        void forestRightDraw(GameTime gametime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(Content.Load<Texture2D>("Maps/greenForestLeft"), new Rectangle(0, 0, _graphics.PreferredBackBufferWidth,
               _graphics.PreferredBackBufferHeight), Color.White);

            //draws ammo
            foreach (var currammo in ammo)
            {
                currammo.DrawMe(_spriteBatch);
            }
            foreach (var box in boxes)
            {
                box.DrawMe(_spriteBatch);
            }
            _spriteBatch.End();
        }

        void factsScreenUpdate(GameTime gametime)
        {
           
        }

        void factsScreenDraw(GameTime gametime)
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (CurrentGameState)
            {
                case GameState.mainMenu:
                    mainMenuUpdate(gameTime);
                    break;
                case GameState.forestCentre:
                    forestCentreUpdate(gameTime);
                        break;
                case GameState.forestTop:
                    forestTopUpdate(gameTime);
                    break;
                case GameState.forestButtom:
                    forestButtomUpdate(gameTime);
                    break;
                case GameState.forestLeft:
                    forestLeftUpdate(gameTime);
                    break;
                case GameState.forestRight:
                    forestRightUpdate(gameTime);
                    break;
                case GameState.factsScreen:
                    factsScreenUpdate(gameTime);
                    break;


            }
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            switch (CurrentGameState)
            {
                case GameState.mainMenu:
                    mainMenuDraw(gameTime);
                    break;
                case GameState.forestCentre:
                    forestCentreDraw(gameTime);
                    break;
                case GameState.forestTop:
                    forestTopDraw(gameTime);
                    break;
                case GameState.forestButtom:
                    forestButtomDraw(gameTime);
                    break;
                case GameState.forestLeft:
                    forestLeftDraw(gameTime);
                    break;
                case GameState.forestRight:
                    forestRightDraw(gameTime);
                    break;
                case GameState.factsScreen:
                    factsScreenDraw(gameTime);
                    break;


            }

         



            base.Draw(gameTime);
        }
    }
}
