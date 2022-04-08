using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Creating Food
/// </summary>
public class Food : MonoBehaviour
{
   // declaring for boundaries
    private float minX, minY, maxX, maxY;

    private void Awake()
    {
      
            minX = -16.0f;
            maxX = 16.0f;
            minY = -8.0f;
            maxY = 8.0f;

        randomizeFood();
    }
    // Detecting for collision with Trigger
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        // Checking for the hitObject to player
         if (hitObject.gameObject.tag == "Player")
         {
            //method to randomize the apple to eat
            randomizeFood();
            

         }
       
       
    }
    private void randomizeFood()
    {
        // getting the random position
        float xpos = Mathf.Round(Random.Range(minX, maxX));
        float ypos = Mathf.Round(Random.Range(minY, maxY));
        this.transform.position = new Vector2(xpos, ypos);

    }
    
}
