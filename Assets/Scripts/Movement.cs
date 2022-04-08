using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int score = 10;
    [SerializeField]
    private Uimanager _uiManager;
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
    private SpriteRenderer sr;
    [SerializeField] private Sprite frontFacing;
    [SerializeField] private Sprite leftFacing;
    [SerializeField] private Sprite rightFacing;
    [SerializeField] private Sprite topFacing;
    private bool isRestart = false;
    private void Awake()
    {
        
        minX = -16.0f;
        maxX = 16.0f;
        minY = -15.5f;
        maxY = 15.5f;
        sr = GetComponent<SpriteRenderer>();
        Vector2 dir = Vector2.right;
        _tails = new List<Transform>();
        _tails.Add(this.transform);
        
    }
    // Start is called before the first frame update
    void Start()
    {

        //movement();
        _uiManager = GameObject.Find("Canvas").GetComponent<Uimanager>();

    }

    // Update is called once per frame
    void Update()
    {
        movement(dir);
        if(Input.GetKeyDown(KeyCode.R) && isRestart)
        {
            ReSetState();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Debug.Log("Down");
            sr.sprite = frontFacing;
            dir = Vector2.down;
            
        }else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Debug.Log("up");

            sr.sprite = topFacing;
            dir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Debug.Log("right");
            sr.sprite = rightFacing;
            dir = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sr.sprite = leftFacing;
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
        
        if(Mathf.Round(transform.position.x) > Mathf.Round(maxX))
        {
           transform.position=new Vector3(Mathf.Round(minX), Mathf.Round(transform.position.y), 0);
        }else if (transform.position.x < minX)
        {
            transform.position = new Vector3(Mathf.Round(maxX), Mathf.Round(transform.position.y), 0);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(minY), 0);
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(maxY), 0);
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
       
         Time.timeScale = 1;
        _uiManager.gameOver(false);
        sr.sprite = frontFacing;
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
            FindObjectOfType<AudioManager>().Play("Pickup");
            _uiManager.incrementScore(score);
            _growTail();
        }
        else if(hitObject.gameObject.tag== "Obstacle")
        {
            _uiManager.gameOver(true);
            Time.timeScale = 0;
            //ReSetState();
            isRestart = true;
        }

       
    }
   

}
