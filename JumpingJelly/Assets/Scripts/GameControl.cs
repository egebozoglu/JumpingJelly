using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject BackgroundPrefab;
    public List<GameObject> platformPrefabs = new List<GameObject>();
    int charValueY = -25;
    int backgroundValueY = -52;
    List<GameObject> instantiatedBackgrounds = new List<GameObject>();
    List<GameObject> instantiatedPlatforms = new List<GameObject>();
    public bool gameActive = false;

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
        InstantiateBackground();
        DestroyObjects();
    }

    public void InstantiateBackground()
    {
        if (gameActive)
        {
            GameObject background, platform;
            if (CharacterControl.instance.transform.position.y <= charValueY)
            {
                background = Instantiate(BackgroundPrefab, new Vector3(BackgroundPrefab.transform.position.x, backgroundValueY, 0f), Quaternion.identity);
                backgroundValueY -= 52;
                charValueY -= 52;
                instantiatedBackgrounds.Add(background);

                System.Random random = new System.Random();
                float yVar = 10f;

                for (int i = 0; i < 10; i++)
                {
                    float randX = random.Next(-2, 2);
                    platform = Instantiate(platformPrefabs[random.Next(0, 4)], new Vector3(randX, background.transform.position.y + yVar, 0f), Quaternion.identity);
                    instantiatedPlatforms.Add(platform);
                    yVar -= 5f;
                }
                
            }
        }
    }

    public void DestroyObjects()
    {
        if (instantiatedBackgrounds.Count == 5)
        {
            if (instantiatedBackgrounds.Count!=0)
            {
                Destroy(instantiatedBackgrounds[0], 0f);
                instantiatedBackgrounds.Remove(instantiatedBackgrounds[0]);
            }
            if (instantiatedPlatforms.Count!=0)
            {
                for (int i = 0; i < 15; i++)
                {
                    Destroy(instantiatedPlatforms[i], 0f);
                    instantiatedPlatforms.Remove(instantiatedPlatforms[i]);
                }
            }
        }
    }

    public void EndGame()
    {
        CharacterControl.instance.gameObject.SetActive(false);
        for (int i = 0; i < instantiatedBackgrounds.Count; i++)
        {
            Destroy(instantiatedBackgrounds[i], 0f);
        }
        for (int i = 0; i < instantiatedPlatforms.Count; i++)
        {
            Destroy(instantiatedPlatforms[i], 0f);
        }

        instantiatedPlatforms.Clear();
        instantiatedBackgrounds.Clear();

        if (string.IsNullOrEmpty(PlayerPrefs.GetInt("Score").ToString()))
        {
            PlayerPrefs.SetInt("High Score", UIManager.instance.coinCollision);
        }
        else if (UIManager.instance.coinCollision> PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("High Score", UIManager.instance.coinCollision);
        }
        CharacterControl.instance.transform.position = new Vector3(0f, 7f, 0f);
        gameActive = false;
        UIManager.instance.endGame = true;
        charValueY = -25;
        backgroundValueY = -52;
    }
}
