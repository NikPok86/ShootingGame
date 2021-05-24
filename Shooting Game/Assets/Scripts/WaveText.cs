using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class WaveText : MonoBehaviour
{   
    public int wave = 1;
    public TextMeshProUGUI waveText;

    void Start()
    {
        waveText.text = "WAVE " + wave + "/5";
    }

    void Update()
    {
        
    }

    public void UpdateWaveText(int wave)
    {
        waveText.text = "WAVE " + wave + "/5";
    }
}
