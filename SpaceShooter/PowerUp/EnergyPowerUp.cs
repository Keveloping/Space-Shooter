

namespace SpaceShooter {
    public class EnergyPowerUp : PowerUp {

        public EnergyPowerUp () : base ("energyPowerUp") {

        }

        public override void OnAttach (Player p) {
            base.OnAttach (p);
            attachedPlayer.Reset ();
            OnDetach ();
        }

    }
}
