using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text pointsText;

    //Pause the game and inform the player what score he got
    public void Setup(int score)
    {
        Time.timeScale = 0;
        GetComponent<Canvas>().enabled = true;
        pointsText.text = score.ToString();
    }
}
