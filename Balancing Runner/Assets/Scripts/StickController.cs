using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    private static StickController stickInstance;
    public static StickController StickInstance { get { return stickInstance; } }

    private void Awake()
    {
        stickInstance = this;
    }

    public void RotateLeft()
    {
        transform.Rotate(new Vector3(0f, 0f, 5f));
    }

    public void RotateRight()
    {
        transform.Rotate(new Vector3(0f, 0f, -5f));
    }

}
