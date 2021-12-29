using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject theCar; //serializeable field for the car
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = theCar.transform.position + new Vector3(0,0,-10);  //have the camera follow the car on late update
    }
}
