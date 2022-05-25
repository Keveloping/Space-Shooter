using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter {
    public class ProgressBar : GameObject {

        private Texture barTexture;
        private Sprite barSprite;

        private Vector2 barOffset;

        protected int barWidth;

        public override Vector2 Position
        {
            get => base.Position;
            set { sprite.position = value; barSprite.position = value + barOffset; }
        }

        public ProgressBar (string textureName, string barName, Vector2 offset) : base (textureName) {
            barTexture = GfxMgr.GetTexture (barName);
            barSprite = new Sprite (barTexture.Width , barTexture.Height);
            barWidth = (int) barSprite.Width;
            barOffset = offset;
        }

        public virtual void Scale (float scale) {
            if (scale < 0) scale = 0;
            if (scale > 1) scale = 1;

            barSprite.scale.X = scale;
            barWidth = (int) (barSprite.Width * scale);

            barSprite.SetMultiplyTint ((1 - scale) * 50, scale * 2, scale, 1);
        }

        public override void Draw () {
            base.Draw ();
            barSprite.DrawTexture (barTexture , 0 , 0 , barWidth , (int) barSprite.Height);
        }

    }
}
