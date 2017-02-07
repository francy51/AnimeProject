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

        [SerializeField]
        Animator playerAnimController;

        Rigidbody rb;
        [SerializeField]
        float VertInput, HorizInput, TurnInput, JumpInput;
        [SerializeField]
        bool AttackInput, SpecialAttackInput;
        CameraController cam;
        Quaternion targetRotation;

        GameObject playerPrefab;

        public GameObject specialAttackCollider;

        [SerializeField]
        Vector3 Displacement;


        public Quaternion TargetRotation
        {
            get
            {
                return targetRotation;
            }
        }

        public Animator PlayerAnimController
        {
            get
            {
                return playerAnimController;
            }

            set
            {
                playerAnimController = value;
            }
        }

        // Use this for initialization
        void Start()
        {
            //find the camera controller
            cam = FindObjectOfType<CameraController>().GetComponent<CameraController>();
            //set camera target
            cam.setCameraTarget(transform);
            //zero all input values
            TurnInput = VertInput = HorizInput = JumpInput = 0;
            //set all attack inputs to false
            AttackInput = SpecialAttackInput = false;
            //set initial target rotation
            targetRotation = transform.rotation;
            //Gather all the components
            rb = GetComponent<Rigidbody>();
            //Instantiate all classes containing movement settings and ect.
            //moveSet = new MoveSettings();
            //inputSet = new InputSettings();
            //physicsSet = new PhysicsSettings();
            //get player stats
            // stats = FindObjectOfType<playerStats>().GetComponent<playerStats>();
            //create a displacement vector with the values of 0,0,0
            Displacement = new Vector3();
            //Find the avatars animator
            playerAnimController = GameObject.Find("SapphiArtchan").GetComponent<Animator>();
            //Setup the input axis so that the character can be controlled using the desired method
            setInputAxis();
        }



        private void Update()
        {
            GatherInput();
            Turn();
            AttackAnimationHandler();
        }

        private void AttackAnimationHandler()
        {
            //if on the ground
            if (Grounded())
            {
                //jump animation is false
                playerAnimController.SetBool("Jump", false);
            }
            if (playerAnimController.GetBool("Attack_SpecialJump") == true)
            {
                SpecialAttackInput = false;
            }
            if (Grounded() && AttackInput)
            {
                NormalAttack();
                playerAnimController.SetBool("Attack_ground", AttackInput);
            }
            else if (playerAnimController.GetBool("Jump") && AttackInput)
            {

                playerAnimController.SetBool("Jump", false);
                playerAnimController.SetBool("Attack_falling", AttackInput);
            }
            else if (SpecialAttackInput && Grounded())
            {
                SpecialAttack();
                playerAnimController.SetBool("Attack_SpecialJump", true);
            }
            else
            {
                playerAnimController.SetBool("Attack_SpecialJump", false);

                playerAnimController.SetBool("Attack_ground", false);

                playerAnimController.SetBool("Attack_falling", false);
            }


        }

        private void SpecialAttack()
        {
            Instantiate(specialAttackCollider, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        }

        private void NormalAttack()
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (hit.collider.tag == "Enemy")
                {
                    //get enemy health script and deal damage
                }
                Debug.DrawRay(transform.position, hit.point);
                print(hit.collider.name);
            }
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
                    playerAnimController.SetBool("Jump", true);
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
            AttackInput = Input.GetButtonDown("Fire1");
            SpecialAttackInput = Input.GetButtonDown("Fire2");
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

            playerAnimController.SetFloat("Speed", (Displacement.z * 2) + Displacement.x);



            //        playerAnimController.SetFloat("Speed", Displacement.x);

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
        //TODO: Debug this since sometimes the games jump ranomdly even though no input was pressed
        bool Grounded()
        {
            RaycastHit hit;
            bool grounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f, moveSet.Ground);
            //if (grounded)
            //    Debug.Log(hit.collider.name);
            //else
            //    Debug.Log("HIT NOTHING SO NOT GROUNDED");
            //Debug.DrawRay(transform.position, hit.point, Color.red);
            return grounded;
        }

    }
}
