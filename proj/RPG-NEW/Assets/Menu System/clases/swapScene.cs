using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Project.menuManager
{
    public class swapScene : MonoBehaviour
    {


        bool paused;
        Scene curScene;
        Scene[] loadedScenes;
        Scene game;
        Scene menu;
        void Start()
        {

            int cntofMangers = GameObject.FindGameObjectsWithTag("Manager").Length;
            if (cntofMangers > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.transform);
            }

         //   Scene curScene = SceneManager.GetActiveScene();

        }
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        public void Pause()
        {
            if (paused)
            {
                SceneManager.LoadSceneAsync(1);
                paused = !paused;
            }
            else
            {

                if (SceneManager.sceneCount == 1)
                {
                    SceneManager.LoadSceneAsync(0);
                    paused = !paused;
                }
                else
                {
                    switch (curScene.buildIndex)
                    {
                        case 0:
                            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
                            break;

                        case 1:
                            SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
                            break;
                        default:
                            break;
                    }
                }


                //SceneManager.SetActiveScene(loadedScenes[i]);
                //paused = !paused;


                //SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
                //paused = !paused;



            }

        }

    }
}