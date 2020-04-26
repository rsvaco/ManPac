using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider musicSlider, effectsSlider;
    public TextMeshProUGUI musicText, effectsText;
    public float music = 1.0f, effects = 1.0f;
    private GlobalOptions go;
    public Image musicFill, musicHandle, effectsFill, effectsHandle;

    public void Start()
    {
        go = GameObject.Find("GlobalOptions").GetComponent<GlobalOptions>();
        musicSlider.SetValueWithoutNotify(go.musicVolume); effectsSlider.SetValueWithoutNotify(go.effectsVolume);
        ColorChange();
    }

    public void ColorChange()
    {
        music = musicSlider.value; effects = effectsSlider.value;
        musicText.text = ((int)(music * 100)).ToString(); effectsText.text = ((int)(effects * 100)).ToString();

        musicFill.color = new Color(1.0f - music, music, 0.0f); musicHandle.color = new Color(1.0f - music, music, 0.0f);
        effectsFill.color = new Color(1.0f - effects, effects, 0.0f); effectsHandle.color = new Color(1.0f - effects, effects, 0.0f);
    }

    public void OnDestroy()
    {
        go.effectsVolume = effects;
        go.musicVolume = music;
    }
}
