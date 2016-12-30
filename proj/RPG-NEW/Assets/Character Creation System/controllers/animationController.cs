using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Project.CharacterCreation
{
    public class animationController : MonoBehaviour
    {

        public Animator FemaleAnim;
        public Animator MaleAnim;
        public GameObject male;
        public GameObject female;
        float animSpeed;
  
        CharacterCreationManager manager;

        // Use this for initialization
        void Start()
        {
            manager = GetComponent<CharacterCreationManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (manager.choosingCharacter)
            {
                FemaleAnim.SetFloat("Blend", 1f);
                MaleAnim.SetFloat("Blend", 1f);
            }
        }

        public GameObject characterSelected (GameObject trigger)
        {
            if (trigger.name == male.name)
            {
                MaleAnim.SetBool("chosenCharacter", true);
                female.SetActive(false);
                return male;
            }
            else if (trigger.name == female.name)
            {
                FemaleAnim.SetBool("chosenCharacter", true);
                male.SetActive(false);
                return female;
            }
            else
                return null;
        }

        public void ResetCharacters()
        {
            MaleAnim.SetBool("chosenCharacter", false);       
            FemaleAnim.SetBool("chosenCharacter", false);
            FemaleAnim.SetFloat("Blend", 1f);
            MaleAnim.SetFloat("Blend", 1f);
            male.SetActive(true);
            female.SetActive(true);
        }

    }
}