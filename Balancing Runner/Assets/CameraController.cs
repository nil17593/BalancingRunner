using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    ////[SerializeField] private Transform target;
    //[SerializeField] private Vector3 offset;
    //[SerializeField] private float smoothFactor;

    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;
    private bool MoveCamera = true;
    private Vector3 targetPos;
    private Vector3 smoothPos;


    private void Start()
    {
        //offset = transform.position + target.transform.position;
    }

    private void FollowPlater()
    {
        if (MoveCamera == true)
        {
            targetPos = new Vector3(0, target.position.y + offset.y, target.position.z + offset.z);
            smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
            transform.position = smoothPos;
        }
        if(target.position.x>5.5f|| target.position.x < -5.5f)
        {
            targetPos = new Vector3(target.position.x, target.position.y + offset.y, target.position.z + offset.z);
            smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
            transform.position = smoothPos;
        }

    }

    private void LateUpdate()
    {
        FollowPlater();
    }
}
