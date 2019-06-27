using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ImpHunter
{
    class SwarmImp : Imp
    {
        Vector2 startPosition;
        Vector2 targetStartPosition;
        GameObject target;
        public SwarmImp(GameObject target, float offsetAngle, float offsetDistance) : base(target)
        {
            this.target = target;

            position.X = target.Position.X + offsetDistance * (float)Math.Cos(offsetAngle);
            position.Y = target.Position.Y + offsetDistance * (float)Math.Sin(offsetAngle);

            startPosition = position;
            targetStartPosition = target.Position;

            scale = 0.5f;

        }

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
            base.Update(gameTime);
        }

        public void Movement(GameTime gameTime)
        {
            position.X = startPosition.X + target.Position.X - targetStartPosition.X + 50f * (float)Math.Sin(gameTime.TotalGameTime.TotalMilliseconds / 200f);
            position.Y = startPosition.Y + target.Position.Y - targetStartPosition.Y + 50f * (float)Math.Sin(gameTime.TotalGameTime.TotalMilliseconds / 100f);
        }
    }
}
