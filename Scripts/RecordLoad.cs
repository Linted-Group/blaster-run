using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordLoad: MonoBehaviour
{
    public Text RecordText;
    void Start()
    {
        RecordText.text=PlayerPrefs.GetInt("recordScore").ToString();
    }
}
