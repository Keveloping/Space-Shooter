using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter {
    public class Background : IUpdatable, IDrawable {

        private Texture texture;
        private Sprite head;
        private Sprite tail;

        private float speed = -400f;

        public bool IsActive
        {
            get { return true; }
        }

        public Background () {
            texture = new Texture ("Assets/spaceBg.png");
            head = new Sprite (Game.Win.Width , Game.Win.Height);
            tail = new Sprite (Game.Win.Width , Game.Win.Height);
            DrawMgr.AddItem (this);
            UpdateMgr.AddItem (this);
        }

        public void Update () {
            head.position += speed * Game.Win.DeltaTime * Vector2.UnitX;

            if (head.position.X < -Game.Win.Width) {
                head.position.X += Game.Win.Width;
            }

            tail.position.X = head.position.X + Game.Win.Width;
        }

        public void Draw () {
            head.DrawTexture (texture);
            tail.DrawTexture (texture);
        }

    }
}
