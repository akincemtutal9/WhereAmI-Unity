using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{


    public string[] yerler = { };

    [SerializeField] private List<string> yerListesi = null;


    public Text placeText;
    public Text playerCountText;
    
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
        
    }

    public void TexteYeriYaz()
    {
        placeText.text = yerler[yerlerdekiPlacelerdenBiri];   
    }

    public void TexttekiYeriBosalt()
    {
        placeText.text = "Place";
    }
    public void OyuncuSayisiniArttir()
    {
        oyuncuSayisi++;
    }
    public void GetOyuncuSayisi()
    {
        playerCountText.text = "Oyuncu sayýsý = " + oyuncuSayisi.ToString();
    }
    
    public void SabitYeriListeyeEkle()
    {
        if (yerListesi.Count!=0)
        {
            yerListesi.Add(yerler[yerlerdekiPlacelerdenBiri]);
            
        }
        else
        {
            yerListesi.Add("impostor");
        }
        }
    
}
