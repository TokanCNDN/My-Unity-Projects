using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Movement : MonoBehaviour
{
    public GameObject chicken,Tail,posion; // Prefabs generate objects
    string direction;
    public float timer2;
    private float timer1,snakesize;
    public Vector2[] SnakeTails = new Vector2[18 * 18]; //tail array
    public int totalTail,destroyTail;
    bool TailSpawn=false;

   
    void Start()
    {
       gameObject.transform.position = new Vector2(0, 0);//start location
       snakesize = gameObject.GetComponent<SpriteRenderer>().size.x;
    }

    void Update()
    {
       
        if (transform.position.x>5)
        {
            transform.position = new Vector2(-5, transform.position.y);
        }
        if(transform.position.x<-5)
        {
            transform.position = new Vector2(5, transform.position.y);

        }
        if(transform.position.y>5)
        {
            transform.position = new Vector3(transform.position.x, -5);
        }
        if (transform.position.y<-5)
        {
            transform.position = new Vector2(transform.position.x, 5);
        }

        if (GameObject.FindGameObjectWithTag("chicken") == null)// if doesn't have a chicken in the hierarchy window,
        {//Generate chicken at a random location in game
            Instantiate(chicken, new Vector2(Random.Range(-9, 10) * snakesize, Random.Range(-9, 10) * snakesize), Quaternion.identity);
        }

        //if (GameObject.FindGameObjectWithTag("posion") == null)// if doesn't have a chicken in the hierarchy window,
        //{//Generate chicken at a random location in game
        //    Instantiate(posion, new Vector2(Random.Range(-9, 10) * snakesize, Random.Range(-9, 10) * snakesize), Quaternion.identity);
        //}


        if (Input.GetKey("w"))
        {
            if(direction!="down")
            {
                direction = "up";
            }
        }
        if(Input.GetKey("s"))
        {
            if(direction!="up")
            {
                direction = "down";
            }
        }
        if (Input.GetKey("d"))
        {
            if (direction!="left")
            {
                direction = "right";
            }
        }
        if (Input.GetKey("a"))
        {
            if (direction!="right")
            {
                direction = "left";
            }
        }

        
        if(transform.position.x>5)
        {
            transform.position = new Vector2(-5, transform.position.y);
        }
        if (transform.position.x <-5)
        {
            transform.position = new Vector2(5, transform.position.y);
        }
        if (transform.position.y>5)
        {
            transform.position = new Vector2(transform.position.x,-5);
        }
        if (transform.position.y < -5)
        {
            transform.position = new Vector2(transform.position.x, 5);
        }

       
        repeat(); //for the Snake go to step by step
    }
    
    void repeat() //for the Snake go to step by step
    {
        if (timer1 < Time.time)
        {
            SnakeTails[0] = transform.position;
            for (int i = 0; i < totalTail; i++)
            {
                SnakeTails[totalTail - i] = SnakeTails[totalTail - i - 1]; //Adding vector2 to tails
                Debug.Log(totalTail);
            }

            if (direction == "right")
            {
                gameObject.transform.position = new Vector2(transform.position.x + snakesize, transform.position.y);
            }
            if (direction == "left")
            {
                gameObject.transform.position = new Vector2(transform.position.x - snakesize, transform.position.y);
            }
            if (direction == "up")
            {
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + snakesize);
            }
            if (direction == "down")
            {
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - snakesize);
            }
            if(TailSpawn==true)
            {
                Debug.Log("çalıştı");
                Instantiate(Tail, transform.position, Quaternion.identity);
                TailSpawn = false;
            }
           

            timer1 = Time.time + timer2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chicken")
        {
            TailSpawn = true;
            totalTail++;
            repeat();
            Destroy(GameObject.FindGameObjectWithTag("chicken"));
        }

        //if (collision.gameObject.tag == "posion")
        //{
        //    destroyTail = totalTail;
        //    totalTail--;
        //    repeat();
        //    Destroy(GameObject.FindGameObjectWithTag("posion"));
        //}
    }
}
