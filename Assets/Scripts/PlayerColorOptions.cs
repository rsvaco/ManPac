using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerColorOptions : MonoBehaviour
{
    public Slider redSlider, greenSlider, blueSlider;
    public TextMeshProUGUI redText, greenText, blueText;
    public Image paco, fantasma;
    public Color color; public float red = 255, green = 255, blue = 255;
    public int playerColor;
    private GlobalOptions go;

    public void Start() {
        go = GameObject.Find("GlobalOptions").GetComponent<GlobalOptions>();
        color = go.playerColors[playerColor];
        redSlider.SetValueWithoutNotify(color.r); greenSlider.SetValueWithoutNotify(color.g); blueSlider.SetValueWithoutNotify(color.b);
        ColorChange();
    }

    public void ColorChange() {
        red = redSlider.value; green = greenSlider.value; blue = blueSlider.value;
        redText.text = ((int)(red*255)).ToString(); greenText.text = ((int)(green*255)).ToString(); blueText.text = ((int)(blue*255)).ToString();

        color = new Color(red, green, blue);
        paco.color = color; fantasma.color = color;
    }

    public void OnDestroy() {
        go.playerColors[playerColor] = color;
    }

}
