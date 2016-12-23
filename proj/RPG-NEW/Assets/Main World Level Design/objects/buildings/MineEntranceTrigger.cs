using UnityEngine;
using System.Collections;

namespace Project.WorldScripts.ForestHills
{
    public class MineEntranceTrigger : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("Player detected.");
            }
            else
            {
                Debug.Log("TEST FALSE");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}