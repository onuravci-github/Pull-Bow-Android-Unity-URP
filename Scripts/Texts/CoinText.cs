﻿using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PlayerSetting.getCoin().ToString("F0");
    }
}
