using OpenTK;


namespace SpaceShooter {
    public abstract class PowerUp : GameObject {

        protected Player attachedPlayer;

        public PowerUp (string textureName) : base (textureName) {
            rigidbody.Type = RigidbodyType.PowerUp;
            rigidbody.AddCollisionType (RigidbodyType.Player);

            rigidbody.Collider = ColliderFactory.CreateCircleFor (this);
            rigidbody.Velocity = new Vector2 (-300 , 0);

            IsActive = false;
        }

        public virtual void OnAttach (Player p) {
            attachedPlayer = p;
        }

        public virtual void OnDetach () {
            attachedPlayer = null;
            Restore ();
        }

        public override void Update () {
            if (attachedPlayer != null) return;
            if (Position.X + Width * 0.5f < 0 ) {
                Restore ();
            }
        }

        public virtual void Spawn () {
            Vector2 pos = new Vector2 ();
            pos.X = Game.Win.Width + Width * 0.5f;
            pos.Y = RandomGenerator.GetRandomInt (Height , Game.Win.Height - Height);

            Position = pos;
            IsActive = true;
        }

        public override void Draw () {
            if (attachedPlayer != null) return;
            base.Draw ();
        }

        protected virtual void Restore () {
            IsActive = false;
            ((PlayScene)Game.CurrentScene).PowerUpMgr.Restore (this);
        }

        public override void OnCollide (GameObject other) {
            if (attachedPlayer != null) return;
            OnAttach ((Player) other);
        }

    }
}
