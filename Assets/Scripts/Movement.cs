using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
  
    [SerializeField]
    private int _speed;
    private float minX, minY, maxX, maxY;
    private bool down,up;
    private Vector2 dir;
    private List<Transform> _tails;
    [SerializeField]
    private Transform _tailPrefab;
    [SerializeField]
    private int initialSize = 1;
    private void Awake()
    {
        minX = -14.1f;
        maxX = 14.1f;
        minY =-8.0f;
        maxY =8.0f;
        Vector2 dir = Vector2.right;
        _tails = new List<Transform>();
        _tails.Add(this.transform);
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
        //movement();

    }

    // Update is called once per frame
    void Update()
    {
        movement(dir);
        
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
           // Debug.Log("Down");
            dir = Vector2.down;
            
        }else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
           // Debug.Log("up");
            dir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           // Debug.Log("right");
            dir = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // Debug.Log("Left");
            dir = Vector2.left;
        }


    }
    private void FixedUpdate()
    {
        for (int i = _tails.Count - 1; i > 0; i--)
        {
            _tails[i].position = _tails[i - 1].position;
        }
        this.transform.position = new Vector2(Mathf.Round(this.transform.position.x+dir.x) , Mathf.Round(this.transform.position.y + dir.y) );
    }
    private void movement(Vector2 dir)
    {
        
        if(transform.position.x >maxX)
        {
           transform.position=new Vector3(minX, transform.position.y, 0);
        }else if (transform.position.x < minX)
        {
            transform.position = new Vector3(maxX, transform.position.y, 0);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, minY, 0);
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, maxY, 0);
        }

        //transform.Translate(dir*speed*Time.deltaTime);
    }

    private void _growTail()
    {
        Transform segment = Instantiate(_tailPrefab);
        segment.position = _tails[_tails.Count - 1].position;
        _tails.Add(segment);

    }
    private void ReSetState()
    {
        /*  for (int i = 0; i < _tails.Count - 1; i++)
          {
              Destroy(_tails[i].gameObject);
          }
          _tails.Clear();
          _tails.Add(this.transform);
          this.transform.position = Vector3.zero;*/
        dir = Vector2.right;
        transform.position = Vector3.zero;

        // Start at 1 to skip destroying the head
        for (int i = 1; i < _tails.Count; i++)
        {
            Destroy(_tails[i].gameObject);
        }

        // Clear the list but add back this as the head
        _tails.Clear();
        _tails.Add(transform);

        // -1 since the head is already in the list
        for (int i = 0; i < initialSize - 1; i++)
        {
            _growTail();
        }
    }
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        
        if (hitObject.gameObject.tag == "Food")
        {

            _growTail();
        }
        else if(hitObject.gameObject.tag== "Obstacle")
        {
            ReSetState();
        }

       
    }
   

}
