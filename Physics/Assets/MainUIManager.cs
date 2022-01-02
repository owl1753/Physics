using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIManager : MonoBehaviour
{
    public WaveSource waveSource_1;
    public WaveSource waveSource_2;
    public TMP_InputField InputWaveSourceDistance;
    public TMP_InputField InputCycle;
    public TMP_InputField InputWaveLength;
    public float waveSourceDistance;
    public float cycle;
    public float wavelength;

    // Start is called before the first frame update

    void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStartButton()
    {
        Time.timeScale = 1;
        waveSourceDistance = float.Parse(InputWaveSourceDistance.text);
        cycle = float.Parse(InputCycle.text);
        wavelength = float.Parse(InputWaveLength.text);
        waveSource_1.gameObject.transform.position = new Vector2(-(waveSourceDistance / 2), 0);
        waveSource_2.gameObject.transform.position = new Vector2((waveSourceDistance / 2), 0);
    }

    public void ClickResetButton()
    {
        Time.timeScale = 0;
        Wave[] waves = FindObjectsOfType<Wave>();
        for (int i = 0; i < waves.Length; i++)
        {
            Destroy(waves[i].gameObject);
        }
        waveSource_1.count = 0;
        waveSource_2.count = 0;
    }

    public void ClickPauseButton()
    {
        Time.timeScale = 0;
    }

    public void ClickResumeButton()
    {
        Time.timeScale = 1;
    }
}
