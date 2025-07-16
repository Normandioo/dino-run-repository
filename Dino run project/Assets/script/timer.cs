using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TMP_Text timerText;
    private int score = 0;
    public bool isRunning = true;

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


    public void StopScore()
    {
        isRunning = false;
    }

    public void StartScore()
    {
        isRunning = true;
    }

    public void ResetScore()
    {
        score = 0;
        timerToIncreaseScore = 0f;
        timerText.text = score.ToString();
    }

}