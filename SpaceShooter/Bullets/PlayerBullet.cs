namespace SpaceShooter {
    public class PlayerBullet : Bullet {

        public PlayerBullet (string textureName, int damage, float speed, BulletType type) : base (textureName, damage, speed, type) {
            rigidbody.Type = RigidbodyType.PlayerBullet;
            rigidbody.AddCollisionType (RigidbodyType.Enemy);
            rigidbody.AddCollisionType (RigidbodyType.EnemyBullet);
        }

        public override void OnCollide (GameObject other) {
            if (other is Enemy) {
                Enemy enemy = (Enemy) other;
                enemy.TakeDamage (damage);
            } else if (other is EnemyBullet) {
                ((EnemyBullet) other).Destroy ();
            }
            Destroy ();
        }

    }
}
