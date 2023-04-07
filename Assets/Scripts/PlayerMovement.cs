using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMultipler = 1f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        player.position += Vector3.right * speedMultipler * Time.deltaTime * xPos;
    }
}
