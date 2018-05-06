using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private bool gameStarted = false;
    private float timer;

    [SerializeField]
    private float gameLengthInSeconds = 30f;

    public static int score;

    [SerializeField]
    public Text scoreText;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private Text gameStateText;

    [SerializeField]
    private AudioSource gameStateSound;

    [SerializeField]
    private AudioClip gameStartSound;

    [SerializeField]
    private AudioClip gameEndSound;



	// Use this for initialization
	void Start () {

        gameStateText.text = "Hit SPACE to play";
        timer = gameLengthInSeconds;

        UpdateScoreBoard();

	}
	
	// Update is called once per frame
	void Update () {

        //if game has not started and the player pressed spacebar
        if (!gameStarted && Input.GetKeyUp(KeyCode.Space))
        {
            //.. then start the game
            StartGame();

        }

        if (gameStarted)
        {
            //decrement the timer and update the scoreboard
            timer -= Time.deltaTime;
            UpdateScoreBoard();

        }

        if (gameStarted && timer <= 0)
        {
            EndGame();

        }

    }

    private void StartGame(){
        score = 0;
        gameStarted = true;
        gameStateText.text = "Go! Go! Go!";

        gameStateSound.PlayOneShot(gameStartSound);

    }


    private void EndGame(){

        gameStarted = false;
        timer = gameLengthInSeconds;
        gameStateText.text = "Game Over!\nHit SPACE to play again!";

        gameStateSound.PlayOneShot(gameEndSound);

    }

    private void UpdateScoreBoard(){

        scoreText.text = "SCORE\n" + score;
        timerText.text = "TIME\n" + Mathf.RoundToInt(timer);
    }
}
