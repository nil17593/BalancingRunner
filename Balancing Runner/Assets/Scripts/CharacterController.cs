using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Vector3 forwardMov;
    private Vector3 leftMov;
    private Vector3 rightMov;
    private Touch touch;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ForwardMovement();
        HorizontalMovement();
        TouchInputs();
    }

    private void ForwardMovement()
    {
        forwardMov = speed * Time.fixedDeltaTime * transform.forward;
        playerRigidbody.MovePosition(playerRigidbody.position + forwardMov);
        //animator.SetBool("Walk", true);
        animator.SetBool("Run", true);
    }
    private void HorizontalMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            leftMov = speed * Time.fixedDeltaTime * transform.right;
            playerRigidbody.MovePosition(playerRigidbody.position + leftMov);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rightMov = speed * Time.fixedDeltaTime * -transform.right;
            playerRigidbody.MovePosition(playerRigidbody.position + rightMov);
        }
        else
        {
            ForwardMovement();
        }
    }


    private void TouchInputs()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                    transform.position.y, transform.position.z);
            }
        }
    }
}
