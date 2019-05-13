using Microsoft.Xna.Framework;
using System;

namespace ImpHunter {
    class PlayingState : GameObjectList{
        Cannon cannon;
        Crosshair crosshair;
        Fortress fortress;
        GameObjectList balls;
        GameObjectList imps;

        private const int SHOOT_COOLDOWN = 20;
        const int BALL_SPEED = 500;
        private int shootTimer = SHOOT_COOLDOWN;

        /// <summary>
        /// PlayingState constructor which adds the different gameobjects and lists in the correct order of drawing.
        /// </summary>
        public PlayingState() {
            Add(new SpriteGameObject("spr_background"));

            Add(balls = new GameObjectList());

            Add(cannon = new Cannon());
            cannon.Position = new Vector2(GameEnvironment.Screen.X / 2, 490);

            Add(imps = new GameObjectList());
            imps.Add(new Imp(cannon));

            Add(fortress = new Fortress());

            // Always draw the crosshair last.
            Add(crosshair = new Crosshair());
        }
        
        /// <summary>
        /// Updates the PlayingState.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {
            foreach(SpriteGameObject tower in fortress.Towers.Children)
            {
                cannon.CheckBounce(tower);
                foreach(Ball ball in balls.Children)
                {
                    ball.CheckBounce(tower);
                    ball.CheckBounce(fortress.Wall);
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Allows the player to shoot after a cooldown.
        /// </summary>
        /// <param name="inputHelper"></param>
        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);

            shootTimer++;

            if (inputHelper.MouseLeftButtonDown() && shootTimer > SHOOT_COOLDOWN) {
                crosshair.Expand(SHOOT_COOLDOWN);
                shootTimer = 0;
                Vector2 direction = new Vector2(cannon.Position.X - inputHelper.MousePosition.X, cannon.Position.Y - inputHelper.MousePosition.Y) * -1;
                balls.Add(new Ball(cannon.Position, Vector2.Normalize(direction) * BALL_SPEED));
            }

        }
    }
}
