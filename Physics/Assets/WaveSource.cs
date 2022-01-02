using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSource : MonoBehaviour
{
    MainUIManager um;
    public GameObject wavePrefab;
    float time = 0;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        um = FindObjectOfType<MainUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (time > (um.cycle / 2.0f))
            {
                Wave[] waves = GetComponentsInChildren<Wave>();
                for (int i = 0; i < waves.Length; i++)
                {
                    waves[i].ChangeCondition();
                }

                Wave wave = Instantiate(wavePrefab, transform.position, transform.rotation).GetComponent<Wave>();
                wave.transform.SetParent(transform);
                wave.radius = (um.wavelength / 2.0f) * (count + 1);
                count++;
                time = 0;
            }
            time += Time.deltaTime;
        }
    }
}
