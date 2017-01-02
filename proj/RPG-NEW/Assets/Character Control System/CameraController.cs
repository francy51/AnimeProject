using UnityEngine;
using System.Collections;
using System;

namespace Project.CharacterControl
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        float Horizontal;
        [SerializeField]
        float Vertical;
        [SerializeField]
        float Jump;
        [SerializeField]
        float yOffset;
        [SerializeField]
        float xOffset;
        [SerializeField]
        float zOffset;
        [SerializeField]
        Vector3 Displacement;
        [SerializeField]
        Vector3 curPlayerPos;
        [SerializeField]
        GameObject Player;
        [SerializeField]
        public int CameraState;

        Rigidbody rb;
        // Use this for initialization
        void Start()
        {
            Player = GameObject.Find("Player");
            rb = GetComponent<Rigidbody>();
            CameraState = 1;
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            if (curPlayerPos != Player.transform.position)
            {
                CalculateMoveAmount();
                MovePlayer();
                curPlayerPos = Player.transform.position;
            }
            else
            {
                Displacement = Vector3.zero;
                rb.velocity = Vector3.zero;
            }
        }

        private void MovePlayer()
        {
            rb.velocity = Displacement;
        }

        private void CalculateMoveAmount()
        {
            // Camera Move State 1
            // Classis RPG movement camera system where you move the player with wasdqe and rotate the camera with the mouse.
            if (CameraState == 1)
            {
                Horizontal = Player.transform.position.x - transform.position.x;
                Vertical = Player.transform.position.z - transform.position.z;
                Jump = Player.transform.position.y - transform.position.y;
                zOffset += Input.GetAxis("Mouse ScrollWheel");

                //work in progress move camera angle with right mouse button
                if (Input.GetMouseButtonDown(1))
                {
                    float startMousePosX = Input.mousePosition.x;
                    float startMousePosY = Input.mousePosition.y;
                    if (Input.GetMouseButton(1))
                    {
                        transform.rotation = new Quaternion(transform.rotation.x, transform.position.y + (startMousePosX - Input.mousePosition.x), transform.rotation.z, transform.rotation.w);
                    }
                }
            

                Displacement = Vector3.Lerp(transform.position, new Vector3(Horizontal + xOffset, Jump + yOffset, Vertical + zOffset), 1f);
                

                
            }
        }
    }
}