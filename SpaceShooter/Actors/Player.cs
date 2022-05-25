using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter {
    public class Player : Actor {

        private float reloadTime;
        private float currentReloadTime;

        private ProgressBar energyBar;

        protected override int Energy {
            get => base.Energy;
            set {
                base.Energy = value;
                energyBar.Scale ((float) hp / maxHP);
            }
        }

        public Player (Vector2 position, string texturePath, int hp, float reloadTime) : 
            base (position, texturePath,hp, BulletType.BlueLaser) {
            this.reloadTime = reloadTime;

            rigidbody.Type = RigidbodyType.Player;
            energyBar = new ProgressBar ("healthBackground" , "healthBar", new Vector2 (4,4));
            energyBar.Position = new Vector2 (60 , 50);
        }

        public void Input () {
            Vector2 inputDirection = Vector2.Zero;
            if (Game.Win.GetKey (KeyCode.W)) {
                inputDirection -= Vector2.UnitY;
                //inputDirection.Y = -1;
            } else if (Game.Win.GetKey (KeyCode.S)) {
                inputDirection += Vector2.UnitY;
                //inputDirection.Y = 1;
            }
            if (Game.Win.GetKey (KeyCode.D)) {
                inputDirection += Vector2.UnitX;
                //inputDirection.X = 1;
            } else if (Game.Win.GetKey (KeyCode.A)) {
                inputDirection -= Vector2.UnitX;
                //inputDirection.X = -1;
            }
            if (inputDirection != Vector2.Zero) {
                rigidbody.Velocity = inputDirection.Normalized () * speed;
            } else {
                rigidbody.Velocity = Vector2.Zero;
            }

            currentReloadTime -= Game.Win.DeltaTime;
            if (Game.Win.GetKey (KeyCode.Space) && currentReloadTime <= 0) {
                Shoot ();
            }
        }

        private void Shoot () {
            Vector2 bulletPosition = new Vector2 (Position.X + Width * 0.5f , Position.Y);
            Bullet b;
            switch (bulletType) {
                case BulletType.BlueLaser:
                    b = BulletMgr.GetBullet (bulletType);
                    if (b != null) {
                        b.Shoot (bulletPosition , Vector2.UnitX , this);
                        currentReloadTime = reloadTime;
                    }
                    break;
                case BulletType.GreenGlobe:
                    Vector2 bulletDirection = new Vector2 (1 , -1);
                    for (int i = 0; i < 3; i++) {
                        b = BulletMgr.GetBullet (bulletType);
                        if (b == null) break;
                        b.Shoot (bulletPosition , bulletDirection , this);
                        bulletDirection.Y += 1;
                        currentReloadTime = reloadTime;
                    }
                    break;
            }
        }

        public override void Update () {
            KeepInBorder ();
        }

        public override void TakeDamage (int damage) {
            base.TakeDamage (damage);
            if (hp <= 0) {
                hp = 0;
                OnDie ();
            }
        }

        private void KeepInBorder () {
            if (Position.X - Width * 0.5f < 0) {
                Position = new Vector2 (Width * 0.5f , Position.Y);
            } else if (Position.X + Width * 0.5f > Game.Win.Width) {
                Position = new Vector2 (Game.Win.Width - Width * 0.5f , Position.Y);
            }
            if (Position.Y - Height * 0.5f < 0) {
                Position = new Vector2 (Position.X , Height * 0.5f);
            } else if (Position.Y + Height * 0.5f > Game.Win.Height) {
                Position = new Vector2 (Position.X , Game.Win.Height - Height * 0.5f);
            }
        }
    }
}
