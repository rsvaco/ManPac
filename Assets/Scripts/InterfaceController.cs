using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public Color playerColor = new Color();
    public Image[] livesImages;
    public int lives;
    public int score;
    
    void LateUpdate()
    {

        scoreText.color = playerColor;
        for (int i = 0; i < livesImages.Length; i++) {
            if (i < lives) livesImages[i].color = playerColor;
            else livesImages[i].color = new Color(playerColor.r, playerColor.g, playerColor.b, 0.0f);
        }

        if (score < 10)
        {
            scoreText.text = "00" + score.ToString();

        }
        else if (score < 100)
        {
            scoreText.text = "0" + score.ToString();
        }
        else
        {
            scoreText.text = score.ToString();
        }
    }

}
