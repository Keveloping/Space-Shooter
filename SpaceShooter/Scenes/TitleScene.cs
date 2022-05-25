namespace SpaceShooter {
    public class TitleScene : Scene {

        public override void Start () {
            base.Start ();
            new StaticGameObject ("titleBackground");
        }

        protected override void LoadAssets () {
            GfxMgr.AddTexture ("titleBackground","Assets/aivBG.png");
        }

        public override void Input () {
            if (Game.Win.GetKey (Aiv.Fast2D.KeyCode.Return)) {
                IsPlaying = false;
                nextScene = new PlayScene ();
            }
        }

    }
}
