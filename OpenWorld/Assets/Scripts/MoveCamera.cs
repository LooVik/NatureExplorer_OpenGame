using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
  //Make Camera Move along with Player.
  public Transform cameraPosition;

  private void Update()
  {
    transform.position = cameraPosition.position;
  }
}
