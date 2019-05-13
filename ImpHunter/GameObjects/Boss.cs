using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter
{
    class Boss : PhysicsObject
    {
        Vector2[] targets;
        Vector2 target;
        Random random = new Random();
        float speed = 50;
        float range = 40;

        public Boss(Vector2[] targets) : base("spr_imp_flying")
        {
            origin = new Vector2(this.Sprite.Width / 2, this.Sprite.Height / 2);
            position = new Vector2(GameEnvironment.Screen.X / 2, 0 - this.Sprite.Height);
            this.targets = targets;
            target = targets[random.Next(targets.Length)];
        }

        public override void Update(GameTime gameTime)
        {
            
            float distance = Vector2.Distance(target, position);

            if (distance < range)
            {
                velocity = Vector2.Normalize(target - position) * speed * (distance / range);

            }
            else if (distance < 50)
            {
                target = targets[random.Next(targets.Length)];
            }
            else
            {
                velocity = Vector2.Normalize(target - position) * speed;
            }

            Console.WriteLine(target);

            base.Update(gameTime);
        }
         
    }

}
