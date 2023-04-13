using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public GameObject[] Skins;

    public Transform ModelsList;
    public int coins;
    public int chosenSkin;

    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        
        chosenSkin=PlayerPrefs.GetInt("chosenSkin");

       
        //Destroy(ModelsList.GetChild(index-1).gameObject);
        Instantiate(Skins[chosenSkin], new Vector3(0, 0, 0), Quaternion.identity).transform.parent = ModelsList.transform;
            
            //DestroyImmediate(info[index-1].model,true);
            //cre.transform.parent = ModelsList.transform;
        


    }
}