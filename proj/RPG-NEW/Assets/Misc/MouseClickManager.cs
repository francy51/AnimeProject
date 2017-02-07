using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace Project.Misc
{
    public class MouseClickManager : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    //Debug.Log("hit " + hit.transform.name);
                    //Debug.DrawRay(Camera.main.transform.position, hit.point);
                    //handle any misc click logic here
                    if (SceneManager.GetActiveScene().name == "sandBox")
                    {
                        //Sandbox mouse logic here
                    }


                }
            }

        }
    }
}

