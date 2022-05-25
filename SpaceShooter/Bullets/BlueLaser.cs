namespace SpaceShooter {
    public class BlueLaser : PlayerBullet {

        public BlueLaser () : base ("blueLaser" , 5, 400, BulletType.BlueLaser) {
            rigidbody.Collider = ColliderFactory.CreateBoxFor (this);
        }

    }
}
