using System;


namespace SpaceShooter {
    public class RandomTimer {

        private int timeMin;
        private int timeMax;
        private Random rand;
        private float remainingSeconds;

        public RandomTimer (int timeMin, int timeMax) {
            this.timeMax = timeMax;
            this.timeMin = timeMin;
            rand = new Random ();
        }

        public void Tick () {
            remainingSeconds -= Game.Win.DeltaTime;
            if (remainingSeconds < 0) remainingSeconds = 0;
        }

        public bool IsOver () {
            return remainingSeconds <= 0;
        }

        public void Reset () {
            remainingSeconds = rand.Next (timeMin , timeMax);
        }

    }
}
