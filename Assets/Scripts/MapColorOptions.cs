using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

public class MapColorOptions : MonoBehaviour
{
    public enum Layer
    {
        Main, Background
    }

    public Slider redSlider, greenSlider, blueSlider;
    public TextMeshProUGUI redText, greenText, blueText;
    public Color color; public float red = 255, green = 255, blue = 255;
    public Layer layer;
    public Tilemap mainTileMap, backTileMap;
    private GlobalOptions go;

    public void Start() {
        go = GameObject.Find("GlobalOptions").GetComponent<GlobalOptions>();
        switch (layer)
        {
            case Layer.Background:
                color = go.backColor;
                break;
            case Layer.Main:
                color = go.mainColor;
                break;
        }
        redSlider.SetValueWithoutNotify(color.r); greenSlider.SetValueWithoutNotify(color.g); blueSlider.SetValueWithoutNotify(color.b);
        ColorChange();
    }

    public void ColorChange() {
        red = redSlider.value; green = greenSlider.value; blue = blueSlider.value;
        redText.text = ((int)(red*255)).ToString(); greenText.text = ((int)(green*255)).ToString(); blueText.text = ((int)(blue*255)).ToString();

        color = new Color(red, green, blue);
        switch (layer)
        {
            case Layer.Background:
                backTileMap.color = color;
                break;
            case Layer.Main:
                mainTileMap.color = color;
                break;
        }
    }

    public void OnDestroy()
    {
        switch (layer)
        {
            case Layer.Background:
                go.backColor = color;
                break;
            case Layer.Main:
                go.mainColor = color;
                break;
        }
    }

}
