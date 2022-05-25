namespace SpaceShooter {
    public class IceGlobe : EnemyBullet {


        public IceGlobe () : base ("fireGlobe" , 10, 500, BulletType.IceGlobe) {
            sprite.SetAdditiveTint (128 , 255 , 255 , 0);
        }

    }
}
