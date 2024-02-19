using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  //Movement
  [Header("Movement")]
  public float movSpeed;
  public float groundDrag;

  [Header("Grounded Check")]
  public float playerHeight;
  public LayerMask Ground;
  bool grounded;

  public Transform orientation;

  float horizontalInput;
  float verticalInput;

  Vector3 movDirection;

  Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;
  }

  private void Update()
  {
    playerInput();
    SpeedControl();

    //Check hit ground
    grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);

    //Handle Drag
    if(grounded)
    {
      rb.drag = groundDrag;
    }
    else
    {
      rb.drag = 0;
    }
  }

  private void FixedUpdate()
  {
    PlayerMovement();
  }

  private void playerInput()
  {
    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");
  }


  private void PlayerMovement()
  {
    //Calculate Movement Direction
    //Always Walk in the Direction Looking.
    movDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

    //Add Force to Player.
    rb.AddForce(movDirection.normalized * movSpeed * 5f, ForceMode.Force);
  }

  private void SpeedControl()
  {
    //Get Velocity of Player in x and z axis.
    Vector3 flatVel = new Vector3(rb.velocity.x , 0f, rb.velocity.z);

    //Limit the Velocity if hit the max
    if(flatVel.magnitude > movSpeed)
    {
      Vector3 limitedVel = flatVel.normalized * movSpeed;
      rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
    }
  }
}
