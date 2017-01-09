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
        MoveSettings moveSet;
        [SerializeField]
        InputSettings inputSet;
        [SerializeField]
        PhysicsSettings physicsSet;

        Rigidbody rb;
        [SerializeField]
        float VertInput, HorizInput, TurnInput, JumpInput;
        CameraController cam;
        Quaternion targetRotation;


        [SerializeField]
        Vector3 Displacement;


        public Quaternion TargetRotation
        {
            get
            {
                return targetRotation;
            }
        }

        // Use this for initialization
        void Start()
        {
            cam = FindObjectOfType<CameraController>().GetComponent<CameraController>();
            cam.setCameraTarget(transform);
            Displacement = Vector3.zero;
            TurnInput = VertInput = HorizInput = JumpInput = 0;
            targetRotation = transform.rotation;
            rb = GetComponent<Rigidbody>();
            stats = FindObjectOfType<playerStats>().GetComponent<playerStats>();
            Displacement = new Vector3();
        }

        private void Update()
        {
            GatherInput();
            Turn();
        }


        void FixedUpdate()
        {
            Run();
            Jump();

            //Move
            rb.velocity = transform.TransformDirection(Displacement);
        }

        private void Jump()
        {
            if (moveSet.MoveState == 0)
            {

                if (JumpInput > 0 && Grounded())
                {
                    //Jump up
                    Displacement.y = moveSet.JumpVel;
                }
                else if (JumpInput == 0 && Grounded())
                {
                    //grounded so don't add gravity
                    Displacement.y = 0;
                }
                else
                {
                    // in the air so add gravity
                    Displacement.y -= physicsSet.gravity;
                }
                    
            }
        }

        void GatherInput()
        {
            if (moveSet.MoveState == 0)
            {
                //collects the inputs
                VertInput = Input.GetAxis("Vertical");
                TurnInput = Input.GetAxis("Turn");
                JumpInput = Input.GetAxisRaw("Jump");
            }
        }

        void Run()
        {
            if (moveSet.MoveState == 0)
            {
                //makes sure that the value is greater than the delay then add the forward input to the displacement
                if (Mathf.Abs(VertInput) > inputSet.inputDelay)
                {
                    Displacement.z = VertInput * moveSet.ForwardVel;
                }
                else
                {
                    Displacement.z = 0f;
                }
            }

        }

        void Turn()
        {
            if (moveSet.MoveState == 0)
            {

                //makes sure that the value is greater than the delay then add the turn input to the target rotation
                if (Mathf.Abs(TurnInput) > inputSet.inputDelay)
                {
                    targetRotation *= Quaternion.AngleAxis(moveSet.RotateVel * TurnInput * Time.deltaTime, Vector3.up);
                    transform.rotation = targetRotation;
                }
            }

        }

        //checks if player is grounded
        bool Grounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, moveSet.DistToGround, moveSet.Ground);
        }

    }
}
