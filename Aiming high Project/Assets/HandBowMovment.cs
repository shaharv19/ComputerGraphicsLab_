using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBowMovment : MonoBehaviour
{

    public float rotationSpeed = 1f; // Speed of the hand rotation
    public float rotationAngle = 5f; // Angle to rotate the hand
    public bool rotateUp = true; // Flag to determine the direction of rotation
    public Transform hand;
    public Transform player;
    public Transform playerCamera;

    private Quaternion initialRotationHand; // Initial rotation of the hand
    private Quaternion targetRotationHand; // Target rotation of the hand
    private Quaternion initialRotationBow; // Initial rotation of the hand
    private Quaternion targetRotationBow; // Target rotation of the hand
    private float t = 0f; // Interpolation variable

    [SerializeField] PlayerControl controller;
    [SerializeField] CameraPlace _cam;

    private void Start()
    {
        initialRotationHand = hand.transform.localRotation;
        Quaternion rotationOffset = Quaternion.Euler(rotateUp ? rotationAngle : -rotationAngle, 0f, 0f);
        targetRotationHand = initialRotationHand * rotationOffset;
    }

    private void Update()
    {
        if (controller.isPullingString)
        {
            /* Quaternion rotationOffset = Quaternion.Euler(_cam.getX, 0f, 0f);
             targetRotationHand = initialRotationHand * rotationOffset;

             // Perform interpolation to rotate the hand gradually
             transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationHand, rotationSpeed * Time.deltaTime);*/
            float cameraRotationX = _cam.getX;

            // Calculate the target rotation for the hand
            Quaternion targetRotation = Quaternion.Euler(0f, cameraRotationX, 0f);

            // Apply rotation gradually to the hand
            hand.rotation = Quaternion.Lerp(hand.rotation, targetRotation, 2f * Time.deltaTime);
        }
    

       /* else
        {
            ResetRotation();
        }*/

    }

    public void ResetRotation()
    {
        hand.transform.localRotation = initialRotationHand;
    }
}