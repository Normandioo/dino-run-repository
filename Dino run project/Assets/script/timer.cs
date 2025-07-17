using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TMP_Text timerText;
    public int score = 0;
    public bool isRunning;
    private float timerToIncreaseScore = 0f;
    


    void Update()
    {
        if (isRunning)
        {
            // Adiciona o tempo desde o último frame ao nosso contador
            timerToIncreaseScore += Time.deltaTime;

            // Verifica se o tempo necessário (0.1 segundos) já passou
            if (timerToIncreaseScore >= 0.1f)
            {
                score += 1; //sums 1 to score
               
                timerText.text = score.ToString(); // Atualiza o texto na UI

                // resets the counter
                timerToIncreaseScore = 0f;
            }
        }
    }

    public void OnEnable()
    {
        
        isRunning = true;
    }

    void OnDisable()
    {
        isRunning = false;
    }


    public void StopScore()
    {
        isRunning = false;
        score = 0;
        timerToIncreaseScore = 0f;
        timerText.text = score.ToString();
    }


    }



