namespace SpaceShooter {
    public abstract class Scene {


        public bool IsPlaying { get; protected set; }

        protected Scene nextScene;

        public Scene () {

        }


        public virtual void Start () {
            LoadAssets ();
            IsPlaying = true;
        }

        protected virtual void LoadAssets () {

        }

        public virtual void Input () {

        }

        public virtual void Update () {
            PhysicsMgr.FixedUpdate ();
            PhysicsMgr.CheckCollisions ();
            UpdateMgr.Update ();
        }

        public virtual void Draw () {
            DrawMgr.Draw ();
        }

        public virtual Scene OnExit () {
            //IsPlaying = false; --> deve essere già false per permettere a Game di capire che la scena non sta più andando
            DrawMgr.ClearAll ();
            UpdateMgr.ClearAll ();
            GfxMgr.ClearAll ();
            PhysicsMgr.ClearAll ();
            return nextScene;
        }
    }
}
