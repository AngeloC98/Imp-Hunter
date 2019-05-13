using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter
{
    class Imp : PhysicsObject
    {
        GameObject target;
        float speed = 50;
        float range = 400;

        public Imp(GameObject target) : base("spr_imp_flying")
        {
            origin = new Vector2(this.Sprite.Width / 2, this.Sprite.Height / 2);
            position = new Vector2(GameEnvironment.Screen.X / 2, 0 - this.Sprite.Height);
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            
            float distance = Vector2.Distance(target.Position, position);

            if (distance < range)
            {
                velocity = Vector2.Normalize(target.Position - position) * speed * (distance / range);
            }
            else
            {
                velocity = Vector2.Normalize(target.Position - position) * speed;
            }

            Console.WriteLine(position + " - " + velocity);
            base.Update(gameTime);
        }
         
    }

}
