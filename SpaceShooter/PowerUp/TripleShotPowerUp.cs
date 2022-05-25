

namespace SpaceShooter {
    class TripleShotPowerUp : TimedPowerUp {

        public TripleShotPowerUp () : base ("triplePowerUp", 5) {

        }

        public override void OnAttach (Player p) {
            base.OnAttach (p);
            attachedPlayer.BulletType = BulletType.GreenGlobe;
        }

        public override void OnDetach () {
            attachedPlayer.BulletType = BulletType.BlueLaser;
            base.OnDetach ();
        }

    }
}
