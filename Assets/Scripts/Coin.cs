using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    HelperScript helper;
    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the entity touching the coin has the tag "player" then the coin will be collected. Else it will
        helper.Collect(other);
    }
}
