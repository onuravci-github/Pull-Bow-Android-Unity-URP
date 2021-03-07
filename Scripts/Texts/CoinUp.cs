using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUp : MonoBehaviour
{
    TextMeshProUGUI text;

    public static float coin;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text =  "+" + coin.ToString("F0");
    }

    public void SetAnimator(){
        this.GetComponent<Animator>().SetBool("Plus",false);
    }

}
