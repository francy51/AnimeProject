using UnityEngine;
using System.Collections;

namespace Project.Misc
{
    public class GlobalManagerReplication : MonoBehaviour
    {

        public static bool GlobalManagerExists ;

        //Making sure one global anager is ever present
        private void Awake()
        {
            if (GlobalManagerExists)
            {
                Destroy(this.gameObject);

            }
            else
            {
                DontDestroyOnLoad(this);
                GlobalManagerExists = true;
            }
        }

    }
}