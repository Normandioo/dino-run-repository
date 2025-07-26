using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }



    [SerializeField] playerScript player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject GameOver;
    [SerializeField] TextMeshProUGUI score;

    void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }

        Application.targetFrameRate = 60;
        GameOver.SetActive(false);
        Pause();
    }
    
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void Play()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        playButton.SetActive(false);
        GameOver.SetActive(false);

        FindFirstObjectByType<playerScript>().ResetsPlayerPosition();

        scoreText.enabled = true;


        obstacleScript[] instantiatedObstacles = FindObjectsByType<obstacleScript>(FindObjectsSortMode.None);
        for (int i = 0; i < instantiatedObstacles.Length; i++)
        {
            Destroy(instantiatedObstacles[i].gameObject);
        }

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        scoreText.enabled = false;
       
    }

    public void gameOver()
    {
        GameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }



}
