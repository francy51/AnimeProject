using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


namespace Project.menuManager
{
    public class menuSystem : MonoBehaviour
    {

        public GameObject crosshair;
        public GameObject quitConfirmation;
        public GameObject optionsHolder;
        public GameObject menu;
        bool paused;

        // Use this for initialization
        void Start()
        {
            optionsHolder.SetActive(false);
            quitConfirmation.SetActive(false);
        }

        public void play()
        {
            SceneManager.LoadSceneAsync(1);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switchPause();
            }
        }

        void switchPause()
        {
            if (paused)
            {
                Time.timeScale = 1f;
                menu.SetActive(false);
                paused = false;
            }
            else if (!paused)
            {
                Time.timeScale = 0f;
                menu.SetActive(true);
                paused = true;
            }
        }

        public void Quit()
        {
            Debug.Log("exit game");
            quitConfirmation.SetActive(true);
        }

        public void confirmedQuit()
        {
            Application.Quit();
        }

        public void deniedQuit()
        {
            quitConfirmation.SetActive(false);
        }


        public void openOptions()
        {
            optionsHolder.SetActive(true);
        }

        public void closeOptions()
        {
            optionsHolder.SetActive(false);
        }

        public void ChangeMoveSettings()
        {

        }

    }
}
