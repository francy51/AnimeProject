using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Project.CharacterCreation;

namespace Project.Misc
{
    public class MouseClickManager : MonoBehaviour
    {

        CharacterCreationManager charactercreationManager;

        // Use this for initialization
        void Start()
        {
            if (SceneManager.GetActiveScene().name == "CharacterCreation")
            {
                charactercreationManager = FindObjectOfType<CharacterCreationManager>().GetComponent<CharacterCreationManager>();
            }

        }

        // Update is called once per frame
        void Update()
        {

            if (SceneManager.GetActiveScene().name == "CharacterCreation")
            {
                if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (charactercreationManager.choosingCharacter)
                    {
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                        {

                            Debug.Log("hit " + hit.transform.name);
                            Debug.DrawRay(Camera.main.transform.position, hit.point);
                            charactercreationManager.checkClickTarget(hit.transform.gameObject);

                        }
                    }
                }
            }

            if (SceneManager.GetActiveScene().name == "sandBox")
            {
                //Sandbox mouse logic here
            }


        }
    }
}

