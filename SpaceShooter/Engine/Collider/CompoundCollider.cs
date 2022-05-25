using System.Collections.Generic;
using OpenTK;

namespace SpaceShooter {
    public class CompoundCollider : Collider{

        public Collider BoundingCollider; //collider che racchiude tutto

        protected List<Collider> colliders;

        public CompoundCollider (Rigidbody owner , Collider BoundingCollider) : base (owner , Vector2.Zero) {
            this.BoundingCollider = BoundingCollider;
            colliders = new List<Collider> ();
        }

        public virtual void AddCollider (Collider collider) {
            colliders.Add (collider);
        }

        protected virtual bool InnerCollidersCollide (Collider collider) {
            for (int i = 0; i < colliders.Count; i++) {
                if (collider.Collides (colliders[i])) {
                    return true;
                }
            }
            return false;
        }

        public override bool Collides (Collider collider) {
            return collider.Collides (this);
        }

        //COMPOUND VS CIRCLE
        public override bool Collides (CircleCollider circle) {
            return BoundingCollider.Collides (circle) && InnerCollidersCollide (circle);
        }

        //COMPOUND VS BOX
        public override bool Collides (BoxCollider box) {
            return BoundingCollider.Collides (box) && InnerCollidersCollide (box);
        }

        //COMPOUND VS COMPOUND
        public override bool Collides (CompoundCollider compound) {
            if (compound.BoundingCollider.Collides (this.BoundingCollider)) {
                foreach (Collider i in colliders) {
                    if (compound.InnerCollidersCollide (i)) {
                        return true;
                    }
                }
            }
            return false;
            //if (compound.BoundingCollider.Collides (BoundingCollider)) {
            //    for (int i = 0; i < colliders.Count; i++) {
            //        for (int j = 0; j < compound.colliders.Count; j++) {
            //            if (colliders[i].Collides (compound.colliders[j])) {
            //                return true;
            //            }
            //        }
            //    }
            //}
            //return false;
        }



        //CONTAINS
        public override bool Contains (Vector2 point) {
            if (BoundingCollider.Contains (point)) {
                for (int i = 0; i < colliders.Count; i++) {
                    if (colliders[i].Contains (point)) {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
