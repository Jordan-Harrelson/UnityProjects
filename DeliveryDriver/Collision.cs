using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;                            //boolean to determine if we have picked up a package                  
    Color32 begin;                                      //our starting color value for the car
    // Start is called before the first frame update
    private void Start()
    {
        begin = GetComponent<SpriteRenderer>().color;   //set the starting color value for the car
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)  //if the object we've gone over is a package and we don't have one
        {   
            GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color; //set the car's color to the packages
            Debug.Log("picked up package");                                                                   //alert the player that we've picked up a package
            hasPackage = true;                                                                                //set our boolean to true
            Destroy(collision.gameObject);                                                                    //destroy the package
        }
        Color32 color1 = collision.gameObject.GetComponent<SpriteRenderer>().color;                           //create a color value for the object we've collided with
        Color32 color2 = GetComponent<SpriteRenderer>().color;                                                //create a color value for our car
        if (collision.tag == "Customer" && hasPackage && color1.Equals(color2))                               //if we've hit a customer and we have a package and our package is the same color as our customer
        {                                                           
            Debug.Log("Packaged delivered");                                                                  //alert the player we've delivered the package
            hasPackage = false;                                                                               //set our boolean to false
            Destroy(collision.gameObject);                                                                    //destroy the customer object
            GetComponent<SpriteRenderer>().color = begin;                                                     //set our car to it's default value
        }
            
    }
}
