using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    public Text _text;
   // public float BlinkFadeInTime = 0.5f;
    public float BlinkStayTime = 0.8f;
    //public float BlinkFadeOutTime = 1f;
    //private float _timeCheker = 0;
    //private Color _color;

   void Start()
    {
        StartBlink();
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            switch (_text.color.a.ToString())
            {
                case "0":
                    _text.color = new Color(_text.color.r,_text.color.g,_text.color.b, 1);
                    yield return new WaitForSeconds(BlinkStayTime);
                    break;
                case "1":
                    _text.color = new Color(_text.color.r,_text.color.g,_text.color.b, 0);
                    yield return new WaitForSeconds(BlinkStayTime);
                    break;
            }
        }
    }

    private void StartBlink()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    private void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
