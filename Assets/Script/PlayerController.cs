using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PLayerMovement")]
    private float gravity = 20f;
    public float Speed = 1.5f;
    public float rotationSpeed = 5f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;

    [Header("Grounded")]

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        controller.Move(moveDir * Time.deltaTime * Speed);
    }
    void movePlayer(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(controller.isGrounded){
            if(horizontalInput != 0f || verticalInput != 0f){

                moveDir = new Vector3(horizontalInput, 0.0f, verticalInput);
                //moveDir.y -= gravity * Time.deltaTime;

                //PlayerRotation...
                Quaternion lookRotation = Quaternion.LookRotation(moveDir, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }
        }else{
            moveDir.y -= 0.02f;
        }
    }
}
