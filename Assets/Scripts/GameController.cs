using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{


    public string[] yerler = {};
        
    [SerializeField] private List<string> yerListesi;


    public Text text;
    public int oyuncuSayisi;
    public int yerlerdekiPlacelerdenBiri;


    
    void Start()
    {
        oyuncuSayisi = 0;
        yerlerdekiPlacelerdenBiri = Random.Range(0, yerler.Length);
        
    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log(yerler.Length);
    }

    public void TexteYeriYaz()
    {
        text.text = yerler[yerlerdekiPlacelerdenBiri];
        
    }

    public void TexttekiYeriBosalt()
    {
        text.text = "Place";
    }
    public void OyuncuSayisiniArttir()
    {
        oyuncuSayisi++;
    }
    public int GetOyuncuSayisi()
    {
        return oyuncuSayisi;
    }
    
    public void SabitYeriListeyeEkle()
    {
        yerListesi.Add(yerler[yerlerdekiPlacelerdenBiri]);
    }

    

}
