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
    float padding = 0.5f;
    float minX;
    float maxX;

    private int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        findBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        float deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speedMultipler;
        float newXpos = Mathf.Clamp(transform.position.x + deltaX,minX, maxX);

        player.position = new Vector2(newXpos, player.position.y);
        
        if (Input.GetMouseButtonDown(0) && time <= 0) {
            shoot();
            time = delay;
        }
    }

    void shoot() {
        GameObject _bullet = Instantiate(bullet, bulletSpawnPos.position, bullet.transform.rotation, bulletHolder);
    }

    void findBoundaries () {
        Camera camera = Camera.main;
        minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    
}
