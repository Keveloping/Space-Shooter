using OpenTK;

namespace SpaceShooter {
    public class EnemyBullet : Bullet {

        public EnemyBullet (string textureName , int damage , float speed , BulletType type) : base (textureName , damage , speed , type) {
            rigidbody.Velocity = -Vector2.UnitX * speed;

            rigidbody.Type = RigidbodyType.EnemyBullet;
            rigidbody.AddCollisionType (RigidbodyType.Player);
            rigidbody.Collider = ColliderFactory.CreateCircleFor (this);

        }

        public override void OnCollide (GameObject other) {
            ((Player) other).TakeDamage (damage);
            Destroy ();
        }

    }
}
