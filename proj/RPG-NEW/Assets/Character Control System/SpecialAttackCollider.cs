using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.CharacterControl
{
    [RequireComponent(typeof(Collider))]
    public class SpecialAttackCollider : MonoBehaviour
    {


        public SpecialAttackCollider(Vector3 Position)
        {
            Instantiate(this, Position, Quaternion.identity);
        }

        // Use this for initialization
        void Start()
        {
            // Instantiate(this, GameObject.Find("Player").transform.position, Quaternion.identity);
            WaitAndDestroy();
        }

        private void WaitAndDestroy()
        {
            Destroy(gameObject,0.3f);
        }

        void OnTriggerEnter(Collider other)
        {
            print(other.name);
            if (other.tag == "Enemy")
            {
                //Enemy knockBackLogic
            }
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}