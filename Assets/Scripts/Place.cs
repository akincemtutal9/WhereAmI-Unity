using UnityEngine;

[CreateAssetMenu(menuName = "Game/" + nameof(Place))]
public class Place : ScriptableObject
{
    [SerializeField] private string[] places;

    public string[] Places => places;


    public string GetRandomPlace => places[Random.Range(0, places.Length)];
}