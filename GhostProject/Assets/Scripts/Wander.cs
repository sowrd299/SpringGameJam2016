using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour
{
    int Speed= 20;
    Vector3 wayPoint;
    int Range = 10;
    void Start(){
        //initialise the target way point
        move();
       }
 
     void Update() 
     {
        // this is called every frame
        // do move code here
        transform.position += transform.TransformDirection(Vector3.forward)*Speed*Time.deltaTime;
         if((transform.position - wayPoint).magnitude < 3)
         {
             // when the distance between us and the target is less than 3
             // create a new way point target
             move();
         }
     }
 
     void move()
     { 
        // does nothing except pick a new destination to go to

         wayPoint = new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), Random.Range(transform.position.y - Range, transform.position.y + Range), 1);

        // don't need to change direction every frame seeing as you walk in a straight line only
         transform.LookAt(wayPoint);
         Debug.Log(wayPoint + " and " + (transform.position - wayPoint).magnitude);
     }
}