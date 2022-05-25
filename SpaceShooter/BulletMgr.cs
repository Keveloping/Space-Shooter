using System.Collections.Generic;

namespace SpaceShooter {

    public enum BulletType { BlueLaser = 0, FireGlobe = 1, IceGlobe = 2, GreenGlobe = 3 , Last = 4}

    public static class BulletMgr {

        const int poolSize = 50;

        static Queue<Bullet>[] bullets;

        public static void Init () {

            bullets = new Queue<Bullet>[(int)BulletType.Last];

            for (int i = 0; i < bullets.Length; i++) {

                bullets[i] = new Queue<Bullet> (poolSize);

                for (int b = 0; b < poolSize; b++) {

                    Bullet bullet;

                    switch ((BulletType) i) {
                        case BulletType.BlueLaser:
                            bullet = new BlueLaser ();
                            break;
                        case BulletType.FireGlobe:
                            bullet = new FireGlobe ();
                            break;
                        case BulletType.IceGlobe:
                            bullet = new IceGlobe ();
                            break;
                        case BulletType.GreenGlobe:
                            bullet = new GreenGlobe ();
                            break;
                        default:
                            bullet = new BlueLaser ();
                            break;
                    }
                    bullets[i].Enqueue (bullet);

                }

            }


        }

        public static Bullet GetBullet (BulletType type) {
            Bullet b = null;
            if (bullets[(int) type].Count > 0) {
                b = bullets[(int) type].Dequeue ();
            }
            return b;
        }

        public static void RestoreBullet (Bullet b) {
            bullets[(int)b.Type].Enqueue (b);
        }

        public static void ClearAll () {
            bullets = new Queue<Bullet>[0];
        }

    }
}
