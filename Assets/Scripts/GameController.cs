using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public string[] yerler = { };// ilk basta oyuna yuklenen yerler

    [SerializeField] private List<string> yerListesi = null;// Yerleri listeye ekle

    [SerializeField] private string[] dataYerleri;// Listeyi Arraye çevir

    public Text placeText;
    public Text playerCountText;
    
    public int oyuncuSayisi;
    
    public int yerlerdekiPlacelerdenBiri;// ilk array
    public int yerListesindekiPlacelerdenbiri;// ikinci array




    
    void Start()
    {
        oyuncuSayisi = 0;
        yerlerdekiPlacelerdenBiri = Random.Range(0, yerler.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        dataYerleri = yerListesi.ToArray();
    }

    public void TexteYeriYaz()
    {
        placeText.text = dataYerleri[0];

        yerListesi.RemoveAt(0);

       
    }

    public void TexttekiYeriBosalt()
    {
        placeText.text = "Place";
    }
    public void OyuncuSayisiniArttir()
    {
        oyuncuSayisi++;
        Shuffle(yerListesi);
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
    
    public void Shuffle(List<string> a)
    {
        // Loop array
        for (int i = a.Count - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = UnityEngine.Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overwrite when we swap the values
            string temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }


    }    
}
