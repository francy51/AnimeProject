using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Project.menuManager
{
    public class menuSystem : MonoBehaviour
    {

        public GameObject quitConfirmation;
        public GameObject optionsHolder;

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
