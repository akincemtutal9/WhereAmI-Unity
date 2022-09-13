using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Testing : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int[] numbers = { 1, 3, 4, 9, 2 };
        var numbersList = numbers.ToList();
        numbersList.Remove(4);
    }
    
}
