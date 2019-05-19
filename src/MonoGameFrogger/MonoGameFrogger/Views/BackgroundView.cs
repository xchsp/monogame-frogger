﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.General;

namespace MonoGameFrogger.Views
{
    class BackgroundView : BaseView
    {
        private readonly SpriteSheet _blocks;
        private readonly Texture2D _home;

        public BackgroundView(ContentManager contentManager, SpriteBatch spriteBatch) 
            : base(contentManager, spriteBatch)
        {
                var blocksTexture = contentManager.Load<Texture2D>("blocks");
                _blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);
            _home = contentManager.Load<Texture2D>("home");
        }

        public override void Draw()
        {
            // Blue river
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 14; x++)
                {
                    _blocks.Draw(new Vector2(x * 16, y * 16), 43, Color.White);
                }
            }

            // The frog homes
            SpriteBatch.Draw(_home, new Vector2(0, 24), Color.White);

            // Sidewalk
            for (int x = 0; x < 14; x++)
            {
                _blocks.Draw(new Vector2(x * 16, 8 * 16), 0, Color.White);
                _blocks.Draw(new Vector2(x * 16, 14 * 16), 0, Color.White);
            }
        }
    }
}
