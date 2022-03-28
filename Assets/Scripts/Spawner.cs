using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject egg;
    private float minX, minY, maxX, maxY;
    private bool hit;
    private void Awake()
    {
        hit = true;
        minX = -8.5f;
        maxX = 8.5f;
        minY = -4.5f;
        maxY = 4.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(startSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator startSpawning()
    {
            while(hit)
        {
            GameObject food = Instantiate(egg);
            float xpos = Random.Range(minX, maxX);
            float ypos = Random.Range(minY, maxY);
            food.transform.position = new Vector2(xpos, ypos);
            hit = false;
            yield return new WaitForSecondsRealtime(1.0f);
            StartCoroutine(startSpawning());
        }
          
            
    }
    public bool getHit()
    {
        return hit;
    }
    public void setHit(bool hit)
    {
        this.hit = hit;
    }
}
