using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    Vector3 offset;
    static Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find(Constants.PLAYER);
        }
        offset = player.transform.position - transform.position;
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.Find(Constants.PLAYER);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (player != null)
            transform.position = player.transform.position - offset;
    }

}
