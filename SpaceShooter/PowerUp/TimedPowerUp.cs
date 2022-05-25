
namespace SpaceShooter {
    public class TimedPowerUp : PowerUp {

        protected float counter;
        protected float duration;

        public TimedPowerUp (string textureName, float duration) : base (textureName) {
            this.duration = duration;
        }

        public override void OnAttach (Player p) {
            base.OnAttach (p);
            counter = duration;
        }

        public override void Update () {
            if (attachedPlayer != null) {
                counter -= Game.Win.DeltaTime;
                if (counter <= 0) {
                    OnDetach ();
                }
            }
            base.Update ();
        }


    }
}
