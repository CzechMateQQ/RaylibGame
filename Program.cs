using Raylib;
using rl = Raylib.Raylib;
using System;

namespace ConsoleApp1
{
    static class Program
    {

        public static bool CheckCollisionV1(Player _pl,Pickup _pu)
        {
            bool rtn = false;
            Rectangle PickUpColl;
            //= new Rectangle(_pu.Position.x - 10, _pu.Position.y - 10, 20, 20);
            float w = Pickup.MyTexture.width * 0.25f;
            float h = Pickup.MyTexture.height * 0.25f;

            PickUpColl = new Rectangle(_pu.Position.x - 0.5f * w, _pu.Position.y - 0.5f * h, w, h);

            Rectangle PlayerCol = new Rectangle(_pl.Position.x - 5, _pl.Position.y - 5, 10, 40);

            rtn = rl.CheckCollisionRecs(PlayerCol, PickUpColl);
            if (rtn)
            {
                _pu.Enabled = false;
            }
            return rtn;
        }
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;

            int score = 0;

            Player myPlayer = new Player();
            myPlayer.Position.x = 50;
            myPlayer.Position.y = 125;


            Pickup[] Test = new Pickup[10];
            int idx = 0;
            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            Pickup.SetTexture("diamond.png");
            Pickup.LoadSound("laser1.ogg");

            for (int x = 100; x < 700 && idx < 10; x+= 40)
            {
                Test[idx] = new Pickup();
                Test[idx].Position.x = x;
                Test[idx].Position.y = 150;
                idx++;
            }


            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------
                myPlayer.RunUpdate();
                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.LIGHTGRAY);
                rl.DrawText($"Score: {score}", 50, 50, 30, Color.DARKBLUE);
                rl.DrawText($"Time Limit: {myPlayer.timer/60}", 500, 50, 30, Color.DARKBLUE);


                myPlayer.Draw();

                if (myPlayer.Position.x > 800)
                {
                    myPlayer.Position.x = 5;
                }

                if (myPlayer.Position.x < 0)
                {
                    myPlayer.Position.x = 795;
                }

                if (myPlayer.Position.y > 450)
                {
                    myPlayer.Position.y = 5;
                }

                if (myPlayer.Position.y < 0)
                {
                    myPlayer.Position.y = 445;
                }

                foreach (Pickup pickup in Test)
                {
                    if (pickup.Enabled)
                    {
                        pickup.Draw();
                        if (CheckCollisionV1(myPlayer, pickup))
                        {
                            score++;
                        }
                    }
                }


                if (score == 10)
                {
                    rl.DrawText("You Win!", 300, 250, 50, Color.MAROON);
                }
                
                //Console.WriteLine(CheckCollisionV1(myPlayer, Test));

                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}

