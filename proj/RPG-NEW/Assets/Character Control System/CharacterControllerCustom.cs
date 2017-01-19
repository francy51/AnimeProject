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
            setInputAxis();
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
            rb.velocity = Camera.main.transform.TransformDirection(Displacement);
        }

        private void Jump()
        {
            if (MoveSettings.MoveState == 0 || MoveSettings.MoveState == 1)
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
            VertInput = Input.GetAxis(inputSet.VertAxis);
            HorizInput = Input.GetAxis(inputSet.HorizAxis);
            JumpInput = Input.GetAxisRaw(inputSet.JumpAxis);
            if (MoveSettings.MoveState == 0)
            {
                TurnInput = Input.GetAxis(inputSet.TurnAxis);
            }
        }

        public void setInputAxis()
        {
            //set the axis for each float
            if (MoveSettings.MoveState == 0)
            {
                inputSet.VertAxis = "Vertical";
                inputSet.HorizAxis = "Horizontal";
                inputSet.TurnAxis = "Turn";
                inputSet.JumpAxis = "Jump";
            }
            else if (MoveSettings.MoveState == 1)
            {
                inputSet.VertAxis = "Vertical";
                inputSet.HorizAxis = "Turn";
                inputSet.JumpAxis = "Jump";

                //TODO: figure out how to handle turning
            }
        }

        void Run()
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
            if (Mathf.Abs(HorizInput) > inputSet.inputDelay)
            {
                Displacement.x = HorizInput * moveSet.ForwardVel;
            }
            else
            {
                Displacement.x = 0f;
            }
        }

        void Turn()
        {
            if (MoveSettings.MoveState == 0)
            {

                //makes sure that the value is greater than the delay then add the turn input to the target rotation
                if (Mathf.Abs(TurnInput) > inputSet.inputDelay)
                {
                    targetRotation *= Quaternion.AngleAxis(moveSet.RotateVel * TurnInput * Time.deltaTime, Vector3.up);
                    transform.rotation = targetRotation;
                }
            }
            if (MoveSettings.MoveState == 1)
            {
                //TODO: Make it so that the player only copies the cameras Y rotation and not everything
                // This is because when we add the x tilt on camera the camera will copy that to.
                transform.rotation = Camera.main.transform.rotation;
            }

        }

        //checks if player is grounded
        bool Grounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, moveSet.DistToGround, moveSet.Ground);
        }

    }
}
