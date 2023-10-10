using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    HelperScript helper;
    bool left;
    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        helper.EdgeCheck(left);
        if (left)
        {

        }
        //Check using ray casting + helper script if the enemy is about to walk off a ledge, if so, then walk in the opposite direction (movement code in script "enemy")
        //If left it moves left and vise versa for right
    }
}
