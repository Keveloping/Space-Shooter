namespace SpaceShooter {
    public class GreenGlobe : PlayerBullet {

        public GreenGlobe () : base ("greenGlobe" , 30, 600, BulletType.GreenGlobe) {
            rigidbody.Collider = ColliderFactory.CreateCircleFor (this);
        }

    }
}
