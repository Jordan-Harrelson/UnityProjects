using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 1f;         //serialize the field for our steering speed
    [SerializeField] float moveSpeed = 0.01f;       //serialize the filed for our move speed

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; //move to the left our right according to the player input and turn speed
        float accelerate = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;     //accelerate or reverse according to player input and move speed
        transform.Rotate(0, 0, -steerAmount);                                          //rotate accordingly
        transform.Translate(0, accelerate, 0);                                         //accelerate accordingly 
    }
}
