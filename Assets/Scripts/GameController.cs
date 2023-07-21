using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Place Arrays

    public string[] places = { }; // ilk basta oyuna yuklenen yerler

    [SerializeField] private List<string> placesList = null; // Yerleri listeye ekle

    [SerializeField] private string[] dataPlaces; // Listeyi Arraye �evir

    #endregion

    #region TEXT

    public Text placeText;
    public Text playerCountText;

    #endregion

    #region Players

    public int playerCount;

    #endregion

    #region Arrays Indexes

    public int randomPlaceIndex; // places array
    public int randomPlacesListIndex; // placesList array

    #endregion

    #region Array Length

    private int placesListLength;

    #endregion

    void Start()
    {
        playerCount = 0;
        randomPlaceIndex = Random.Range(0, places.Length);
    }

    // Update is called once per frame
    void Update()
    {
        dataPlaces = placesList.ToArray();

        placesListLength = placesList.Count;

        GetOyuncuSayisi();
    }

    public void TexteYeriYaz() // ROLL BUTTON
    {
        if (placesListLength != 0)
        {
            placeText.text = dataPlaces[0];
            placesList.RemoveAt(0);
        }
        else
        {
            placeText.text = "Just Play DUDE";
        }
    }

    public void TexttekiYeriBosalt() // UNLOAD BUTTON
    {
        placeText.text = "Place";
    }

    public void OyuncuSayisiniArttir()
    {
        playerCount++;
        Shuffle(placesList);
    }

    public void GetOyuncuSayisi()
    {
        playerCountText.text = "Player Count = " + playerCount.ToString();
    }

    public void SabitYeriListeyeEkle()
    {
        if (placesList.Count != 0)
        {
            placesList.Add(places[randomPlaceIndex]);
        }
        else
        {
            placesList.Add("impostor");
        }
    }

    public void Shuffle(List<string> a)
    {
        // Loop array
        for (int i = a.Count - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overwrite when we swap the values
            string temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }
    }
}