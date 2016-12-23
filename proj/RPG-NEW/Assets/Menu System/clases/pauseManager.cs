using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Project.menuManager
{
    public class pauseManager : MonoBehaviour
    {

        public GameObject menuHolder;
        public GameObject quitConfirmation;
        public GameObject optionsHolder;

        bool isPaused;

        // Use this for initialization
        void Start()
        {
            //int cntofMangers = GameObject.FindGameObjectsWithTag("Manager").Length;
            //if (cntofMangers > 1)
            //{
            //    Destroy(this.gameObject);
            //}
            //else
            //{
            //    DontDestroyOnLoad(this.transform);
            //}
            menuHolder.SetActive(false);
            quitConfirmation.SetActive(false);
            optionsHolder.SetActive(false);

        }

        public void changePause()
        {
            isPaused = !isPaused;
            pauseGame(isPaused);

        }

        void pauseGame(bool curPauseState)
        {
            if (curPauseState)
            {
                Time.timeScale = 0f;
                menuHolder.SetActive(isPaused);
            }
            else
            {
                Time.timeScale = 1f;
                menuHolder.SetActive(isPaused);
                optionsHolder.SetActive(false);
                quitConfirmation.SetActive(false);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                changePause();
            }
        }

        public void Save()
        {
            Debug.Log("Save the cur game");
        }

        public void MainMenu()
        {
            SceneManager.LoadSceneAsync(0);
            Debug.Log("Go to main menu");
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

    }
}