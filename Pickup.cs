using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{

    class Pickup
    {
        public Vector2Int Position;
        Color MyColor = Color.BLUE;
        public bool Enabled = true;

        public static Texture2D MyTexture;
        public static Sound MySound;

        public static void SetTexture (string _Filename)
        {
            MyTexture = rl.LoadTexture(_Filename);
        }

        public static void SetSound(string _Filename)
        {
            MySound = rl.LoadSound(_Filename);
        }

        public static void PlayClip()
        {
             rl.PlaySound(MySound);
        }

        public void Draw()
        {
            if (!Enabled)
            {
                return;
            }

            rl.DrawTextureEx(MyTexture, new Vector2(Position.x, Position.y), 0f, 0.5f, Color.WHITE);

        }
    }
}
