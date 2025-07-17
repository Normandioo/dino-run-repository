using System.Threading;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    [SerializeField] playerScript player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject GameOver;

    void Awake()
    {

        
        Application.targetFrameRate = 60;
        GameOver.SetActive(false);
        Pause();
    }

    public void Play()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        playButton.SetActive(false);
        GameOver.SetActive(false);

        FindFirstObjectByType<playerScript>().ResetsPlayerPosition();

        scoreText.enabled = true;
        FindFirstObjectByType<timer>().OnEnable();

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
        FindFirstObjectByType<timer>().StopScore();
    }

    public void gameOver()
    {
        GameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }



}
