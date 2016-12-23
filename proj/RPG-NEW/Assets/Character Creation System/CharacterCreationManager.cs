using UnityEngine;
using Project.StatSystem;
using System.Collections;

namespace Project.CharacterCreation
{
    public class CharacterCreationManager : MonoBehaviour
    {

        public bool choosingCharacter;
        public bool choosingName;
        animationController controller;
        GameObject chosenCharacter;
        public GameObject chooseStat;
        public GameObject chooseName;

        // Use this for initialization
        void Start()
        {
            controller = GetComponent<animationController>();
            choosingName = false;
            chooseStat.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (chosenCharacter == null)
            {

                choosingCharacter = true;
            }
            else
                choosingCharacter = false;

            if (!choosingCharacter && !choosingName)
            {
                //then choosing class and ect.
                chooseStat.SetActive(true);
                chooseName.SetActive(false);
            }
            else if (choosingName)
            {
                chooseName.SetActive(true);
                chooseName.SetActive(false);
            }
        }

        public void pressedBack()
        {
            if (!choosingCharacter && !choosingName)
            {
                chosenCharacter = null;
            }
            else if (choosingName)
            {
                choosingName = false;
            }
        }

        public void pressedContinue()
        {
            if (!choosingCharacter && !choosingName)
            {
                choosingName = true;
            }
            else if (choosingName)
            {
                //Confirm Everything in the player stats

            }
        }

        public void checkClickTarget(GameObject trigger)
        {
            chosenCharacter = controller.characterSelected(trigger);
        }
    }
}