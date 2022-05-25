using System.Collections.Generic;
using OpenTK;

namespace SpaceShooter {
    public class EnemyMgr : IUpdatable {


        private const int poolSize = 20;

        private Queue<Enemy> pool;
        private RandomTimer timer;

        public bool IsActive
        {
            get { return true; }
        }

        public EnemyMgr (int timeMin, int timeMax) {
            timer = new RandomTimer (timeMin , timeMax);
            timer.Reset ();
            pool = new Queue<Enemy> (poolSize);

            for (int i = 0; i < poolSize; i++) {
                if (RandomGenerator.GetRandomInt ((int) EnemyType.Enemy_0,(int) EnemyType.Last) == 0) {
                    pool.Enqueue (new Enemy_0 ());
                } else {
                    pool.Enqueue (new Enemy_1 ());
                }
            }
            UpdateMgr.AddItem (this);
        }

        public void Update () {
            timer.Tick ();
            if (timer.IsOver ()) {
                SpawnEnemy ();
            }
        }

        private void SpawnEnemy () {
            if (pool.Count > 0) {
                Enemy e = pool.Dequeue ();
                e.Reset ();
                Vector2 spawnPostion = new Vector2 ();
                spawnPostion.X = Game.Win.Width + e.Width * 0.5f;
                spawnPostion.Y = RandomGenerator.GetRandomInt (e.Height , Game.Win.Height - e.Height);
                e.SpawnMe (spawnPostion);
                timer.Reset ();
            }
        }


        public void ReturnBack (Enemy enemy) {
            pool.Enqueue (enemy);
        }

    }
}
