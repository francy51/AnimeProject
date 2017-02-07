using UnityEngine;
using System.Collections;
using System;
using Project.StatSystem;

namespace Project.CharacterControl
{
    public class CameraController : MonoBehaviour
    {

        public bool OrbitMode;
        public Transform Target;
        private float lookSmooth = 0.09f;
        public Vector3 offsetFromTarget;
        public float xTilt = 10;

        public float mouseSensitivity;
        float yaw;
        float pitch;
        public Vector2 minMaxPitch = new Vector2(10, 50);
        public float rotationSmoothTime = 0.12f;
        Vector3 currentRotation;
        Vector3 rotationSmoothVelocity;
        Transform target;

        Vector3 destination = Vector3.zero;
        CharacterControllerCustom player;
        float rotateVel = 0;

        playerStats stats;

        public void setCameraTarget(Transform t)
        {
            Target = t;
            if (Target != null)
            {
                if (Target.GetComponent<CharacterControllerCustom>())
                {
                    player = Target.GetComponent<CharacterControllerCustom>();
                }
                else
                    Debug.Log("Target Not Player Errors");
            }
            else
                Debug.Log("No Target");
        }

        private void Update()
        {
            if (MoveSettings.MoveState == 1)
            {
                yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
               
                //TODO: Add an x tilt so that no matter how high the player zooms up you can still see the player
                currentRotation = new Vector3(0, yaw);
                transform.eulerAngles = currentRotation;
                transform.position = Target.position + transform.forward * offsetFromTarget.z + Vector3.up * offsetFromTarget.y;
            }
        }

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                offsetFromTarget.z += Input.GetAxisRaw("Mouse ScrollWheel");
            }
            else
                offsetFromTarget.y += Input.GetAxisRaw("Mouse ScrollWheel");


            if (MoveSettings.MoveState == 0)
            {
                MoveToTarget();
                LookAtTarget();
            }

        }

        private void MoveToTarget()
        {

            destination = player.TargetRotation * offsetFromTarget;
            destination += Target.position;
            transform.position = destination;

        }

        private void LookAtTarget()
        {

            float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Target.eulerAngles.y, ref rotateVel, lookSmooth);
            //float eulerXAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x, Target.eulerAngles.x + xTilt, ref rotateVel, lookSmooth);
            //transform.rotation = Quaternion.Euler(eulerXAngle,eulerYAngle,0);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);


        }
    }
}