using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter
{
    class Ball : PhysicsObject
    {
        Vector2 gravity = new Vector2(0, 4f);
        float bounce = 0.6f;
        float friction = 0.99f;

        public Ball(Vector2 position, Vector2 velocity) : base("spr_cannon_ball")
        {
            this.position = position;
            this.velocity = velocity;
            origin = new Vector2(this.sprite.Width / 2, this.sprite.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            velocity += gravity;
            velocity.X *= friction;

            base.Update(gameTime);
        }

        public void CheckBounce(SpriteGameObject other)
        {
            if (!CollidesWith(other)) return;

            CollisionResult side = CollisionSide(other);

            switch (side)
            {
                case CollisionResult.LEFT:
                    position.X = other.Position.X + other.Width + Center.X;
                    velocity.X *= -bounce;
                    break;
                case CollisionResult.RIGHT:
                    position.X = other.Position.X - Center.X;
                    velocity.X *= -bounce;
                    break;
                case CollisionResult.TOP:
                    position.Y = other.Position.Y - Center.Y;
                    velocity.Y *= -bounce;
                    break;
                case CollisionResult.BOTTOM:
                    position.Y = other.Position.Y - Center.Y + 1;
                    velocity.Y *= -bounce;
                    break;
            }
        }
    }
}
