using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public float speedMultipler = 1f;
    public Transform player;

    // bullet
    [Header("Bullet Properties")]
    public Transform bulletSpawnPos;
    public Transform bulletHolder;
    public GameObject bullet;

    [Header("Shooting Properties")]
    float delay = 0.3f;


    // private
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        float xPos = Input.GetAxisRaw("Horizontal");
        player.position += Vector3.right * speedMultipler * Time.deltaTime * xPos;
        
        if (Input.GetMouseButtonDown(0) && time <= 0) {
            shoot();
            time = delay;
        }
    }

    void shoot() {
        GameObject _bullet = Instantiate(bullet, bulletSpawnPos.position, bullet.transform.rotation, bulletHolder);
    }
}
