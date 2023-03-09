using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : Block
{
    private Stack<GameObject> standingBlock = new Stack<GameObject>();

    [SerializeField]
    GameObject stackBlockPrefab;

    [SerializeField]
    Transform playerBlock;

    [SerializeField]
    GameObject playerModel;

    private void Start()
    {
        standingBlock.Push(playerModel);
    }

    private void Update()
    {
        playerModel.transform.position = ModelPos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.EDIBLE))
        {
            GameObject go;
            go = Instantiate(stackBlockPrefab, StackPos(), Quaternion.identity, playerBlock);
            standingBlock.Push(go);
        }
        else if (other.CompareTag(Constants.INEDIBLE))
        {
            Destroy(standingBlock.Pop());
        }
        else if (other.CompareTag(Constants.WIN))
        {
            int length = standingBlock.Count - 1;
            for (int i = 0; i < length; i++)
            {
                Destroy(standingBlock.Pop());
                Invoke(nameof(WinGame), Constants.DELAY_SHOWING_UI);
            }
        }
    }

    void WinGame()
    {
        //UIController.Instance.WinUI();
    }

    Vector3 ModelPos()
    {
        Vector3 v3 = transform.position + new Vector3(0, standingBlock.Count * Constants.STACKING_BLOCK_THICKNESS - Constants.MODEL_HEIGHT_OFFSET, 0);
        return v3;
    }
    Vector3 StackPos()
    {
        Vector3 v3 = transform.position + new Vector3(0, standingBlock.Count * Constants.STACKING_BLOCK_THICKNESS, 0);
        return v3;
    }
}
