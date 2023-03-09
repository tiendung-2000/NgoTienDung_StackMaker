using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBlock : Block
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PLAYER))
        {
            gameObject.SetActive(false);
        }
    }
}
