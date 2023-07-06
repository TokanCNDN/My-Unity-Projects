using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tail_move : MonoBehaviour
{
    
    GameObject snake;
    public int tailNumber,destroy;
    bool check=false;
    void Start()
    {
      
        snake = GameObject.Find("Snake");
        tailNumber = snake.gameObject.GetComponent<Snake_Movement>().totalTail;
    }

    // Update is called once per frame
    void Update()
    {
        //destroy = snake.gameObject.GetComponent<Snake_Movement>().destroyTail;
        //if (tailNumber==destroy)
        //{
        //    Destroy(this.gameObject);
        //}
        if (check==true)
        {
            if (new Vector2(transform.position.x, transform.position.y) == new Vector2(snake.transform.position.x, snake.transform.position.y))
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            check = true;
        }
       
        transform.position = snake.gameObject.GetComponent<Snake_Movement>().SnakeTails[tailNumber];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="chicken")
        {
            Destroy(GameObject.FindGameObjectWithTag("chicken"));
        }
    }
}
