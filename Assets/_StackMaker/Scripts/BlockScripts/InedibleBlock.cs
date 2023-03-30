using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InedibleBlock : Block
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PLAYER))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
