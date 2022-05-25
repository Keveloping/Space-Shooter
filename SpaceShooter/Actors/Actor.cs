using System;
using OpenTK;

namespace SpaceShooter {
    public abstract class Actor : GameObject {

        protected BulletType bulletType;
        public BulletType BulletType
        {
            set { bulletType = value; }
        }

        protected int maxHP;
        protected int hp;

        protected virtual int Energy
        {
            get { return hp; }
            set { hp = Math.Min (value , maxHP); }
        }

        public Actor (Vector2 position , string texturePath , int hp, BulletType bulletType) :
            base (texturePath) {
            Position = position;
            sprite.pivot = new Vector2 (sprite.Width * 0.5f , sprite.Height * 0.5f);
            maxHP = hp;
            this.hp = hp;
            speed = 250;
            this.bulletType = bulletType;

            rigidbody.Collider = ColliderFactory.CreateBoxFor (this);
        }

        public virtual void TakeDamage (int damage) {
            Energy -= damage;
        }

        public virtual void OnDie () {
            IsActive = false;
        }

        public virtual void Reset () {
            IsActive = true;
            Energy = maxHP;
        }

    }
}
