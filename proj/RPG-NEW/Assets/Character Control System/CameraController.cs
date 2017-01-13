using UnityEngine;
using System.Collections;
using System;

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
        public Vector2 minMaxPitch = new Vector2(-20,85);
        public float rotationSmoothTime = 0.12f;
        Vector3 currentRotation;
        Vector3 rotationSmoothVelocity;
        Transform target;

        Vector3 destination = Vector3.zero;
        CharacterControllerCustom player;
        float rotateVel = 0;

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
                yaw -= Input.GetAxis("Mouse X") * mouseSensitivity;
                pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
                pitch = Mathf.Clamp(pitch, minMaxPitch.x, minMaxPitch.y);

                currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
                transform.eulerAngles = currentRotation;
                transform.position = player.transform.position + transform.forward * offsetFromTarget.z;

            }
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