using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTreeTesting : MonoBehaviour
{
    public Animator animator;
    float velocity = 0.0f;
    public float acceleration=0.1f;
    public float deceleration=0.5f;
    int velocityMesh;


    private void Start()
    {
        animator = GetComponent<Animator>();

        velocityMesh = Animator.StringToHash("Vertical");
    }
    private void Update()
    {
        bool wPressed= Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.R);

        if (wPressed && velocity<1.0f)
        {
            float horizontalinput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");


            Vector3 moveDir = new Vector3(horizontalinput, 0, verticalInput);

            //animator.SetFloat("Vertical", 1f);
            velocity += Time.deltaTime * acceleration;
            //Debug.Log(Animation.name);
        }
        if (!wPressed && velocity>0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }
        if(!wPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    animator.SetFloat("Horizontal", 1f);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    animator.SetFloat("Horizontal", -1f);
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    animator.SetFloat("Vertical", -1f);
        //}

        animator.SetFloat(velocityMesh, velocity);
    }
}
