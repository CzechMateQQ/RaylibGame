using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{

    struct Vector2Int
    {
        public int x;
        public int y;
    }
    class Player
    {
        public int timer = 0;
        public Vector2Int Position = new Vector2Int();
        public Color MyColor = Color.MAROON;
        public bool playerEnabled = true;

        public void RunUpdate()
        {
            if (rl.IsKeyDown(KeyboardKey.KEY_W))
            {
                Position.y--;
            }

            if (rl.IsKeyDown(KeyboardKey.KEY_S))
            {
                Position.y++;
            }

            if (rl.IsKeyDown(KeyboardKey.KEY_A))
            {
                Position.x--;
            }

            if (rl.IsKeyDown(KeyboardKey.KEY_D))
            {
                Position.x++;
            }

            timer++;

        }
        public void Draw()
        {
            if (!playerEnabled)
            {
                return;
            }

            rl.DrawCircle(Position.x, Position.y, 9f, MyColor);
            rl.DrawCircle(Position.x - 3, Position.y - 1, 2f, Color.BLACK);
            rl.DrawCircle(Position.x + 3, Position.y - 1, 2f, Color.BLACK);
            rl.DrawRectangle(Position.x - 5, Position.y + 5, 10, 30, MyColor);
            rl.DrawRectangle(Position.x - 15, Position.y + 10, 30, 7, MyColor);
            rl.DrawRectangle(Position.x - 10, Position.y + 30, 20, 7, MyColor);
            rl.DrawCircle(Position.x, Position.y + 15, 2f, Color.GOLD);
            rl.DrawCircle(Position.x, Position.y + 20, 2f, Color.GOLD);
            rl.DrawCircle(Position.x, Position.y + 25, 2f, Color.GOLD);
        }
    }
}
