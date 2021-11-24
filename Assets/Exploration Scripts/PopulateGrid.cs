using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab; // This is the thing that will be exposed on the scrollview
    private int numberToCreate; // Number of objects to create. Exposed in inspector

    void Start()
    {
        numberToCreate = 50;
        Populate();    
    }

    void Populate(){
        GameObject newOjb;
        for (int i = 0; i < numberToCreate; i++)
        {
            newOjb = (GameObject)Instantiate(prefab, transform);
            newOjb.GetComponent<Image>().color = Random.ColorHSV();
            //newOjb.GetComponent<Item>().artwork = Random.ColorHSV();
        }
    }
}
