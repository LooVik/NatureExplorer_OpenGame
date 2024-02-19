using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
  //Player Camera Movement
  //VAriable for Camera
  public float senX;
  public float senY;

  public Transform orientation;

  float xRotation;
  float yRotation;

  private void Start()
  {

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

  }

  private void Update()
  {

    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

    yRotation += mouseX;
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    //Rotate Cam and orientation
    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    orientation.rotation = Quaternion.Euler(0, yRotation, 0);
  }
}
