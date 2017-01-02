using UnityEngine;
using System.Collections;
using Project.StatSystem;
using System;

namespace Project.CharacterControl
{
    public class CharacterControllerCustom : MonoBehaviour
    {

        playerStats stats;

        [SerializeField]
        float WalkSpeed;

        Rigidbody rb;

        [SerializeField]
        float Horizontal;
        [SerializeField]
        float Vertical;
        [SerializeField]
        float Jump;
        [SerializeField]
        Vector3 Displacement;
        [SerializeField]
        LayerMask Ground;
        [SerializeField]
        float JumpSpeed;
        [SerializeField]
        bool isGrounded;
        [SerializeField]
        float Gravity = 10f;
        [SerializeField]
        float Rotation;
        [SerializeField]
        Quaternion targetRotation;

        CameraController camera;

        Ray ray;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Physics.gravity = new Vector3(0, -Gravity * rb.mass);
            stats = FindObjectOfType<playerStats>().GetComponent<playerStats>();
            WalkSpeed = stats.WalkSpeed;
            JumpSpeed = stats.JumpHeight;
            Displacement = new Vector3();
            targetRotation = Quaternion.identity;
            camera = FindObjectOfType<CameraController>().GetComponent<CameraController>();
        }

        private void Update()
        {
            ray = new Ray(transform.position, Vector3.down);
            checkGrounded();
        }


        void FixedUpdate()
        {
            GatherInput();
            AddInputsTogether();
            MoveCharacter();
        }

        private void MoveCharacter()
        {

            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + Rotation, transform.rotation.z, transform.rotation.w);
            rb.velocity = Displacement;



        }

        private void AddInputsTogether()
        {
            Displacement = new Vector3(Horizontal, Jump, Vertical);
        }

        void GatherInput()
        {

            Horizontal = Input.GetAxis("Horizontal") + (Input.GetAxis("Horizontal") * WalkSpeed);
            Vertical = Input.GetAxis("Vertical") + (Input.GetAxis("Vertical") * WalkSpeed);
            Jump = Input.GetAxisRaw("Jump") * JumpSpeed;
            if (camera.CameraState == 1)
            {
                Rotation = Input.GetAxis("Turn");

            }

            if (isGrounded)
            {
                Jump = Input.GetAxisRaw("Jump") * JumpSpeed;
                // print(isGrounded);
            }

        }

        private void checkGrounded()
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, JumpSpeed))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (hit.collider.tag == "Ground")
                {
                    isGrounded = true;
                    //   print("enter Loop");
                }
            }
            else
            {
                isGrounded = false;
            }
        }
    }
}
