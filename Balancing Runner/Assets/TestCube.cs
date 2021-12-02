using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    public delegate void MultiDelegate();
    public delegate void OnValChange(SpellSO spell);
    MultiDelegate myMultiDelegate;



    private void Start()
    {
        myMultiDelegate += Print;
        myMultiDelegate += ChangeColour;

        if (myMultiDelegate != null)
        {
            myMultiDelegate();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 5f));
            Debug.Log(transform.rotation.z);
            //Debug.Log(transform.localEulerAngles.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -5f));
            //Debug.Log(transform.localEulerAngles.z);
            Debug.Log(transform.rotation.z);

        }
    }

    void Print()
    {
        Debug.Log("this is print delegate");
    }

    void ChangeColour()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    void OnUIChanged()
    {

    }
}
