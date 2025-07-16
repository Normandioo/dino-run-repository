using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] playerScript player;
    [SerializeField] TextMeshProUGUI scoreText;


    private int Score;



    public void IncreaseScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    }



}
