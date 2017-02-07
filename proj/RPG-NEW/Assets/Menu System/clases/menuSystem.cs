using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Project.CharacterControl;

namespace Project.menuManager
{
    public class menuSystem : MonoBehaviour
    {

        public GameObject crosshair;
        public GameObject quitConfirmation;
        public GameObject optionsHolder;
        public GameObject menu;
        MoveSettings moveset;
        CharacterControllerCustom player;
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

            if (player == null)
            {
                player = FindObjectOfType<CharacterControllerCustom>().GetComponent<CharacterControllerCustom>();
                if (player == null)
                {
                    Debug.Log("No player available");
                    return;
                }
            }
            switch (MoveSettings.MoveState)
            {
                case 0:
                    //print(MoveSettings.MoveState);
                    MoveSettings.MoveState = 1;
                    try
                    {
                        GameObject.Find("crosshair").SetActive(true);
                    }
                    catch (System.Exception)
                    {
                        print("No crosshair found.");
                    }
                    closeOptions();
                    switchPause();
                    player.setInputAxis();
                    //print(MoveSettings.MoveState);
                    break;
                case 1:
                    //print(MoveSettings.MoveState);
                    MoveSettings.MoveState = 0;
                    try
                    {
                        GameObject.Find("crosshair").SetActive(false);
                    }
                    catch (System.Exception)
                    {
                        print("No crosshair found.");
                    }
                    closeOptions();
                    switchPause();
                    player.setInputAxis();
                    //print(MoveSettings.MoveState);
                    break;
                default:
                    //print(MoveSettings.MoveState);
                    MoveSettings.MoveState = 1;
                    try
                    {
                        GameObject.Find("crosshair").SetActive(false);
                        closeOptions();
                        switchPause();
                    }
                    catch (System.Exception)
                    {
                        print("No crosshair found.");
                    }
                    player.setInputAxis();
                    //print(MoveSettings.MoveState);
                    break;


            }

        }

    }
}
