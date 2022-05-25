using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter {

    public enum EnemyType { Enemy_0, Enemy_1, Last}

    public abstract class Enemy : Actor {

        public EnemyType Type { get; protected set; }
        public RandomTimer timer;

        public Enemy (Vector2 position, string texturePath, int hp, 
            EnemyType enemyType, BulletType bulletType) : base (position, texturePath, hp, bulletType) {
            rigidbody.Velocity = -Vector2.UnitX * speed;
            sprite.FlipX = true;
            timer = new RandomTimer (1 , 3);
            timer.Reset ();
            Type = enemyType;
            IsActive = false;

            rigidbody.Type = RigidbodyType.Enemy;
            rigidbody.AddCollisionType (RigidbodyType.Player);
        }

        public void SpawnMe (Vector2 spawnPosition) {
            Position = spawnPosition;
            IsActive = true;
        }

        public override void Update () {
            if (Position.X < -Width * 0.5f) {
                OnDie ();
            } else {
                Shoot ();
            }
        }

        protected virtual void Shoot () {
            timer.Tick ();
            if (timer.IsOver ()) {
                Bullet bullet = BulletMgr.GetBullet (bulletType);
                if (bullet == null) return;
                timer.Reset ();
                Vector2 pos = new Vector2 (Position.X - sprite.Width * 0.5f , Position.Y);
                bullet.Shoot (pos, this);
            }
        }

        public override void TakeDamage (int damage) {
            base.TakeDamage (damage);
            if (hp <= 0) {
                OnDie ();
            }
        }

        public override void OnDie () {
            base.OnDie ();
            ((PlayScene)Game.CurrentScene).EnemyMgr.ReturnBack (this);
        }

        public override void OnCollide (GameObject other) {
            Player player = (Player) other;
            player.TakeDamage ((int) (hp * 0.25f));
            OnDie ();
        }

    }
}
