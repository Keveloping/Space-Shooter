using OpenTK;
using System;

namespace SpaceShooter {
    public class FireGlobe : EnemyBullet {

        protected float accumulator;

        public FireGlobe () : base ("fireGlobe" , 20 , 500 , BulletType.FireGlobe) {
            accumulator = 0;
        }

        public override void Update () {
            accumulator += Game.Win.DeltaTime * 10; //frequenza
            rigidbody.Velocity.Y = (float) Math.Cos (accumulator) * 350; //ampiezza

            base.Update ();
        }

    }
        
       
}
