using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IItems
{
    public void Collect()
    {
        Destroy(gameObject);
    }

}
