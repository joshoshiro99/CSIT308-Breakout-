using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   //<<--This must be added..... And then see belo
using TMPro;

public class GM : MonoBehaviour
{
    public AudioSource hitsound;

    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public TextMeshProUGUI livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;

    private GameObject clonePaddle;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        hitsound = GetComponent<AudioSource>();
        Setup();
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay); 
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);

        }
    }

    public void Setup()
    {
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    private void Reset()
    {
        Time.timeScale = 1f;
        //Replaces old line in code. SampleScene is generic name for otherwise named scenes.      <<-THIS IS THE CORRECTION
        //If you have two scenes and you want the GM to load scene, GM will have to be altered
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void LoseLife()
    {
        Destroy(clonePaddle);
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }
    public void DestroyBrick()      
    {
        hitsound.Play();
        bricks--;
        CheckGameOver();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
