
using OpenTK;

namespace SpaceShooter {
    public class StaticGameObject : GameObject {

        public StaticGameObject (string textureName) : base (textureName) {
            rigidbody.Velocity = Vector2.Zero;
        }

    }
}
