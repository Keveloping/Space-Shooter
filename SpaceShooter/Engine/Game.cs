using Aiv.Fast2D;
using System;

namespace SpaceShooter {
    public static class Game {

        public const float gravity = 400f;

        private static Window win;
        public static Window Win
        {
            get { return win; }
        }


        private static Scene currentScene;
        public static Scene CurrentScene
        {
            get { return currentScene; }
        }


        public static void Init () {
            win = new Window (1280 , 720 , "Space Shooter");
            win.SetVSync (false);
            currentScene = new TitleScene ();
            currentScene.Start ();
        }


        public static void Play () {
            while (Win.IsOpened) {
                //GameLoop
                CurrentScene.Input ();
                CurrentScene.Update ();
                CurrentScene.Draw ();
                

                Win.Update ();

                //Check change scene
                if (!CurrentScene.IsPlaying) {
                    if (!ChangeScene ()) {
                        break;
                    }
                }
            }
        }

        private static bool ChangeScene () {
            Scene nextScene = CurrentScene.OnExit ();
            GC.Collect (); //forzo garbage collector
            if (nextScene == null) return false;
            currentScene = nextScene;
            currentScene.Start ();
            return true;
        }

    }
}
