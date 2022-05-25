using Aiv.Fast2D;
using System.Collections.Generic;

namespace SpaceShooter {
    public static class GfxMgr {

        private static Dictionary<string,Texture> textures;

        static GfxMgr () {
            textures = new Dictionary<string , Texture> ();
        }

        public static Texture AddTexture (string textureName, string path) {
            Texture t = new Texture (path);
            textures.Add (textureName , t);
            return t;
        }

        public static Texture GetTexture (string textureName) {
            Texture t = null;
            if (textures.ContainsKey (textureName)) {
                t = textures[textureName];
            }
            return t;
        }

        public static void ClearAll () {
            textures.Clear ();
        }

    }
}
