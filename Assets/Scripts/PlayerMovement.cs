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

    [Header("Health")]
    public GameObject healthUI;

    [Header("Explosion Animation")]
    public GameObject explosion;

    // private
    float time = 0f;
    float padding = 0.5f;
    float minX;
    float maxX;

    private int health = 3;

    // audio
    AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        findBoundaries();
        shootSound = GetComponent<AudioSource>();
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
        // play a shooting sound

        GameObject _bullet = Instantiate(bullet, bulletSpawnPos.position, bullet.transform.rotation, bulletHolder);
        shootSound.Play();
    }

    void findBoundaries () {
        Camera camera = Camera.main;
        minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    public void takeDamage() {
        health -= 1;
        healthUI.transform.GetChild(2 - health).gameObject.SetActive(false);

        if (health <= 0) {

            FindObjectOfType<GameManager>().pauseGame();
            // play explosion animation
            GameObject expO = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(expO,0.6f);

            Destroy(gameObject);
        }

    } 
}
