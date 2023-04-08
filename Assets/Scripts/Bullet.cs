using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speedMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speedMultiplier * Time.deltaTime;
    }

    // private void OnCollisionEnter2D(Collision2D col) {
    //     print(col.collider.name);
    // }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<Meteor>().health -= 1;
        Destroy(gameObject);
    }
}
