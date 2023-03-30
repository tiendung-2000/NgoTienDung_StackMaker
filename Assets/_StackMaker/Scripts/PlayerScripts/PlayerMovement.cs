using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 10;
    Vector3 nextPos;
    Dir curDir;
    bool isMoving;


    void Update()
    {
        curDir = InputHandler.GetCurDir();
        if (!isMoving)
        {
            CheckMove(curDir);
        }
        else
        {
            if ((transform.position - nextPos).magnitude < Constants.ARRIVED_OFFSET)
                isMoving = false;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    void CheckMove(Dir dir)
    {
        if (Physics.Raycast(transform.position, GetMoveDir(dir) , out RaycastHit hit, Mathf.Infinity, Constants.WALL_LAYER_MASK))
        {
            if (Vector3.Distance(hit.point, transform.position) <= Constants.MOVABLE_OFFSET)
                return;
            else
            {
                nextPos = hit.point - GetMoveDir(dir) * Constants.TRUE_POSITION_OFFSET;
                isMoving = true;
            }
        }
    }

    Vector3 GetMoveDir(Dir dir)
    {
        switch (dir)
        {
            case Dir.Up: return Vector3.forward;
            case Dir.Down: return Vector3.back;
            case Dir.Right: return Vector3.right;
            case Dir.Left: return Vector3.left;
            default: return Vector3.zero;
        }
    }
}
