using UnityEngine;

public class StickController : MonoBehaviour
{
    //private static StickController stickInstance;
    //public static StickController StickInstance { get { return stickInstance; } }

    //private void Awake()
    //{
    //    stickInstance = this;
    //}

    private float currentRotation;


    void Start()
    {
        currentRotation = 0;
    }

    public void RotateLeft()
    {
        //if (this.transform.rotation.z < 15f)
        //{
        //    Debug.Log(transform.gameObject.name);
        //    transform.Rotate(new Vector3(0f, 0f, 2f));

        //    //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Clamp(transform.rotation.z, -10, 10));
        //}
        //transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.x),transform.rotation.y,transform.rotation.z -10, 10));
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Clamp(transform.rotation.z, -10, 10));
        if (currentRotation < 9)
        {
            currentRotation = currentRotation + 2f;
            transform.localEulerAngles = new Vector3(0f, 0f, currentRotation);
        }
    }

    public void RotateRight()
    {
        //if (this.transform.localEulerAngles.z > -5f)
        //{
        if (currentRotation > -9) 
        {
            //Debug.Log(this.transform.localEulerAngles.z);

            //Debug.Log(transform.gameObject.name);
            //transform.Rotate(new Vector3(0f, 0f, -5f));
            currentRotation = currentRotation - 2f;
            transform.localEulerAngles = new Vector3(0f, 0f, currentRotation);
        }

        Debug.Log(this.transform.localEulerAngles.z);

        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Clamp(transform.rotation.z, -10, 10));
    }
}