using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    public float speedMultiplier = 1f;
    public int health = 0;

    private int scoreMultiplier;
    private GameManager manager;    
    // Start is called before the first frame update
    void Start()
    {
        if (transform.CompareTag("small_meteor")) {
            health = 1;
            scoreMultiplier = 2;
        }
        else if (transform.CompareTag("medium_meteor")) {
            health = 1;
            scoreMultiplier = 4;
        }
        else if (transform.CompareTag("large_meteor")) {
            health = 2;
            scoreMultiplier = 8;
        }

        manager = FindObjectOfType<GameManager>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            manager.addScore(scoreMultiplier);
            // some boom
            Destroy(gameObject);
        }

        transform.position += Vector3.down * speedMultiplier * Time.deltaTime;    
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
       
    // }

    private void OnCollisionEnter2D(Collision2D col) {
        // pause
        // retry menu


        if (col.transform.CompareTag("spaceship")) {
            // pause
            // Time.timeScale = 0.05f;

            // reload
            FindObjectOfType<PlayerMovement>().takeDamage();
            Destroy(gameObject);
            
        }
    }
}
