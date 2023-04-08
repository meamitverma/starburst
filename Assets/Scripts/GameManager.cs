using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMP_Text scoreField;

    [Header("Pause Properties")]
    public GameObject pauseMenu;
    public GameObject scoreGO;
    public GameObject meteorSpawner;
    public GameObject holders;

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int val) {
        score += val;
        scoreField.text = score.ToString();
    }

    public void pauseGame() {
        // slow
        Time.timeScale = 0.7f;

        disableGO();
        pauseMenu.SetActive(true);
    }

    public void reloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void disableGO() {
        FindObjectOfType<PlayerMovement>().enabled = false;
        scoreGO.SetActive(false);
        meteorSpawner.SetActive(false);
        holders.SetActive(false);
    }

    private void enableGO() {
        FindObjectOfType<PlayerMovement>().enabled = true;
        scoreGO.SetActive(true);
        meteorSpawner.SetActive(true);
        holders.SetActive(true);
    }
}
