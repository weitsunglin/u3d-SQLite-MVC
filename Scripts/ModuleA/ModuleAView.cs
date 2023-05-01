using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ModuleAView : MonoBehaviour
{
    public Image Bg = null ;

    void Start()
    {
        LoadBackGround();
    }

    void Update()
    {
        
    }

    void LoadBackGround()
    {
        Bg.GetComponent<Image>().sprite = GolbalFunc.LoadSpriteTexture( "/img1.jpg" );
    }

}