using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
   
    private float minX, minY, maxX, maxY;

    private void Awake()
    {
      
            minX = -8.5f;
            maxX = 8.5f;
            minY = -4.5f;
            maxY = 4.5f;
       
        RandomizePosition();
    }
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
         if (hitObject.gameObject.tag == "Player")
         {
            
             RandomizePosition();
            

         }
       
       
    }
    private void RandomizePosition()
    {
        float xpos = Mathf.Round(Random.Range(minX, maxX));
        float ypos = Mathf.Round(Random.Range(minY, maxY));
        this.transform.position = new Vector2(xpos, ypos);

    }
    
}
