using System.Collections.Generic;

namespace SpaceShooter {
    public class PowerUpMgr : IUpdatable {

        protected List<PowerUp> powerUps;

        protected RandomTimer timer;

        public bool IsActive
        {
            get { return true; }
        }

        public PowerUpMgr () {
            powerUps = new List<PowerUp> ();
            powerUps.Add (new EnergyPowerUp ());
            powerUps.Add (new TripleShotPowerUp ());
            timer = new RandomTimer (4 , 8);
            timer.Reset ();
            UpdateMgr.AddItem (this);
        }

        public void Update () {
            timer.Tick ();
            if (timer.IsOver ()) {
                if (powerUps.Count > 0) {
                    int randomIndex = RandomGenerator.GetRandomInt (0 , powerUps.Count);

                    PowerUp p = powerUps[randomIndex];
                    powerUps.RemoveAt (randomIndex);

                    p.Spawn ();
                    timer.Reset ();
                }
            }
        }

        public void Restore (PowerUp p) {
            powerUps.Add (p);
        }


    }
}
