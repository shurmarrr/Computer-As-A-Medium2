using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip coinSound;

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    //Setting the variable of the lower screen border at -3.1 on the y axis
    private float lowerPlayerLimit = -3.1f;
    
    //Setting the variable of the mid screen border at 1.25 on the y axis
    private float midPlayerLimit = 1.25f;

    public GameObject bulletPrefab;

    //Updates text in UI when score is added
    public class CoinScore : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;

        private int score = 0;

        public void CollectCoin()
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }
    //Updates Score in UI when player collides with coin
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Coin"))
        {
            ScoreManager.Instance.AddScore(1);
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
            
        }
    }

    void Start()
    {
        playerSpeed = 9f;
        //This function is called at the start of the game
        
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //Player is stopped at the bottom of the screen
        if(transform.position.y < lowerPlayerLimit)
        {
            transform.position = new Vector3(transform.position.x, -3, 0);
        }
        //If the player passes 1.25 on the y axis, there are set back to 1. Preventing them from moving higher than halfwya on the screen
        if(transform.position.y > midPlayerLimit)
        {
            transform.position = new Vector3(transform.position.x, 1, 0);
        }
    }

}
