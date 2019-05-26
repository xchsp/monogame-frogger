﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.General;
using MonoGameFrogger.Models;
using System.Collections.Generic;

namespace MonoGameFrogger.Views
{
    class VehicleView: BaseView
    {
        private readonly SpriteSheet _blocks;
        private readonly List<VehicleRowModel> _rows = new List<VehicleRowModel>();
        
        public VehicleView(ContentManager contentManager, SpriteBatch spriteBatch, IEnumerable<VehicleRowModel> rows) 
            : base(contentManager, spriteBatch)
        {
            var blocksTexture = contentManager.Load<Texture2D>("blocks");
            _blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);

            _rows.AddRange(rows);
        }

        public override void Draw()
        {
            foreach (var row in _rows)
            {
                if (row.IsCoolingDown) continue;

                foreach (var vehicle in row.Vehicles)
                {
                    var xr = vehicle.Positon + row.OffsetRight;
                    var posRight = new Vector2((int)xr.X, (int)xr.Y);
                    _blocks.Draw(posRight, vehicle.Frame, Color.White);

                    if (row.Ghost == VehicleGhost.Ghost)
                    {
                        var xl = vehicle.Positon + row.OffsetLeft;
                        var posLeft = new Vector2((int)xl.X, (int)xl.Y);
                        _blocks.Draw(posLeft, vehicle.Frame, Color.White);
                    }
                }
            }
        }
    }
}
