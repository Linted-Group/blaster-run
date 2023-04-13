using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksScript : MonoBehaviour
{
    public GameObject vk;
    public GameObject tg;

    public void tgClick(){
        Application.OpenURL("http://t.me/linted1/");
    }
    public void vkClick(){
        Application.OpenURL("http://vk.com/linted1");
    }
}
