using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level01 : MonoBehaviour
{
    //public GameManager gm;
    public TextMeshProUGUI level01Text;
    public static int wave;

    void Start()
    {
        //GameManager gm = new GameManager();
        level01Text.text = "LEVEL 01\n" + wave + "/5 WAVES";
    }

    void Update()
    {
        level01Text.text = "LEVEL 01\n" + wave + "/5 WAVES";
    }
}
