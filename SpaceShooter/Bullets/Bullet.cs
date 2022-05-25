using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter {
    public abstract class Bullet : GameObject {

        public BulletType Type { get; protected set; }

        protected int damage;
        protected Actor owner;

        public Bullet (string textureName, int damage, float speed,
            BulletType type) : base (textureName) {
            this.damage = damage;
            this.speed = speed;
            switch (Type) {
                case BulletType.BlueLaser:
                case BulletType.GreenGlobe:
                    sprite.pivot = new Vector2 (0 , texture.Height * 0.5f);
                    break;
                case BulletType.FireGlobe:
                case BulletType.IceGlobe:
                    sprite.pivot = new Vector2 (texture.Width , texture.Height * 0.5f);
                    break;
            }
            Type = type;
            IsActive = false;
        }

        public virtual void Shoot (Vector2 startPosition, Actor shotBy) {
            Position = startPosition;
            owner = shotBy;
            IsActive = true;
        }

        public virtual void Shoot (Vector2 startPosition, Vector2 direction, Actor shotBy) {
            Shoot (startPosition , shotBy);
            rigidbody.Velocity = direction.Normalized () * speed;
        }

        public override void Update () {
            if (!InsideBorder ()) {
                Destroy ();
            }
        }

        public virtual bool InsideBorder () {
            return Position.X >= 0 && Position.X <= Game.Win.Width && Position.Y + Height * 0.5f >= 0 && Position.Y - Height * 0.5f <= Game.Win.Height;
        }

        public virtual void Destroy () {
            IsActive = false;
            BulletMgr.RestoreBullet (this);
        }

    }
}
