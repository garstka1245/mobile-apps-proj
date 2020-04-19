using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

public class PlayerMove : MonoBehaviour
{
    
    CharacterController characterController;
    
    //public Camera mainCamera;
    public float speed = 6.0f;
    //public float jumpMoveSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    //private Vector3 cameraDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        /*else {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= jumpMoveSpeed;
        }*/

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        //cameraDirection = mainCamera.transform.forward;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
