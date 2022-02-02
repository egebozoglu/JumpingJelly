using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText, scoreActual;
    public GameObject canvas, joystickCanvas;
    public int coinCollision = 0;
    public GameObject gameOverCanvas;
    float endGameRate = 0f;
    float endGameTime = 2f;
    public bool endGame = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetScore();
        scoreActual.text = coinCollision.ToString();

        if (endGame)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        canvas.SetActive(false);
        joystickCanvas.SetActive(true);
        CharacterControl.instance.gameObject.SetActive(true);
        CharacterControl.instance.transform.GetComponent<Rigidbody2D>().gravityScale = 1f;
        GameControl.instance.gameActive = true;
    }

    public void EndGame()
    {
        joystickCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        CharacterControl.instance.transform.GetComponent<Rigidbody2D>().gravityScale = 0f;

        endGameRate += Time.deltaTime;

        if (endGameRate > endGameTime)
        {
            gameOverCanvas.SetActive(false);
            canvas.SetActive(true);
            endGameRate = 0f;
            endGame = false;
            CameraController.instance.transform.position = new Vector3(0f, 2f, -1f);
        }
    }

    public void SetScore()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetInt("Score").ToString()))
        {
            scoreText.text = "High Score: " + PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            scoreText.text = "High Score: 0";
        }
    }
}
