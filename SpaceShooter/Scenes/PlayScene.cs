using OpenTK;


namespace SpaceShooter {
    public class PlayScene : Scene {



        private Player player;
        public Player Player
        {
            get { return player; }
        }
        private EnemyMgr enemyMgr;
        public EnemyMgr EnemyMgr
        {
            get { return enemyMgr; }
        }
        private PowerUpMgr powerUpMgr;
        public PowerUpMgr PowerUpMgr
        {
            get { return powerUpMgr; }
        }

        private Background background;


        public override void Start () {
            base.Start ();
            background = new Background ();
            player = new Player (new Vector2 (Game.Win.Width * 0.1f , Game.Win.Height * 0.5f) , "player" , 40 , 0.33f);
            BulletMgr.Init ();
            enemyMgr = new EnemyMgr (4 , 6);
            powerUpMgr = new PowerUpMgr ();
        }

        public override void Input () {
            if (Game.Win.GetKey (Aiv.Fast2D.KeyCode.Esc)) {
                IsPlaying = false;
                nextScene = null;
            }
            player.Input ();
        }

        public override void Update () {
            base.Update ();
            if (!player.IsActive) {
                IsPlaying = false;
                nextScene = new GameOverScene ();
            }
        }

        protected override void LoadAssets () {
            GfxMgr.AddTexture ("player" , "Assets/player_ship.png");
            GfxMgr.AddTexture ("enemy_0" , "Assets/enemy_ship.png");
            GfxMgr.AddTexture ("enemy_1" , "Assets/redEnemy_ship.png");
            GfxMgr.AddTexture ("blueLaser" , "Assets/blueLaser.png");
            GfxMgr.AddTexture ("greenGlobe" , "Assets/greenGlobe.png");
            GfxMgr.AddTexture ("fireGlobe" , "Assets/fireGlobe.png");
            GfxMgr.AddTexture ("healthBar" , "Assets/loadingBar_bar.png");
            GfxMgr.AddTexture ("healthBackground" , "Assets/loadingBar_frame.png");
            GfxMgr.AddTexture ("energyPowerUp" , "Assets/powerUp_battery.png");
            GfxMgr.AddTexture ("triplePowerUp" , "Assets/powerUp_triple.png");
        }

        public override Scene OnExit () {
            player = null;
            enemyMgr = null;
            powerUpMgr = null;
            background = null;
            BulletMgr.ClearAll ();
            return base.OnExit ();
        }


    }
}
