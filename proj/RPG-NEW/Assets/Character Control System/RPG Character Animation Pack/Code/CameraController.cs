using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{
    GameObject cameraTarget;
    public float rotateSpeed;
    float rotate;
    public float offsetDistance;
    public float offsetHeight;
    public Vector3 offset;
    public float smoothing;
    float Ymove;
    Vector3 targetRotation;
    [SerializeField]
    float mouseSensitivity;
    Vector3 SmoothVel;
    [SerializeField]
    float rotationSmoothTime;


    void Start()
    {

        cameraTarget = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(cameraTarget.transform.position.x, offsetHeight, -offsetDistance);
    }

    void Update()
    {
        moveToTarget();
        rotateToTarget();    
    }

    private void rotateToTarget()
    {
        Ymove += Input.GetAxis("Mouse X") * mouseSensitivity;
        //print(Ymove);
        targetRotation = Vector3.Lerp(targetRotation, new Vector3(0, Ymove), rotationSmoothTime);
        transform.eulerAngles = targetRotation;
    }

    private void moveToTarget()
    {
       Vector3 targetPosition = transform.rotation * offset;
       targetPosition += cameraTarget.transform.position;
       transform.position = Vector3.Lerp(transform.position, targetPosition, 1);
    }
}