
namespace SpaceShooter {
    public class GameOverScene : Scene {

        public override void Start () {
            base.Start ();
            new StaticGameObject ("gameOverBg");
        }

        protected override void LoadAssets () {
            GfxMgr.AddTexture ("gameOverBg" , "Assets/gameOverBG.png");
        }

        public override void Input () {
            if (Game.Win.GetKey (Aiv.Fast2D.KeyCode.Y)) {
                IsPlaying = false;
                nextScene = new PlayScene ();
            } else if (Game.Win.GetKey (Aiv.Fast2D.KeyCode.N)) {
                IsPlaying = false;
                nextScene = null;
            }
        }
    }
}
