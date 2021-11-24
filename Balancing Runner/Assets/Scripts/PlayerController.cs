using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    #region Private Components
    private Rigidbody playerRigidbody;
    private Vector3 forwardMov;
    private Vector3 leftMov;
    private Vector3 rightMov;
    private Touch touch;
    private bool isMove = true;
    //private float timer = 10f;
    private float desiredLane = 1f;
    //public float laneDistance;
    #endregion

    #region Serialized Fields
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    #endregion

    private void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        SetSwipeHorizontal();
    }

    private void FixedUpdate()
    {
        Velocity();

        //SetSwipeHorizontal();

        //Die();
    }

    #region Forward Movement code
    //forward movement 
    private void ForwardMovement()
    {
        isMove = true;
        animator.SetBool("Run", true);
        forwardMov = speed * Time.fixedDeltaTime * transform.forward;
        playerRigidbody.MovePosition(playerRigidbody.position + forwardMov);
    }
    #endregion


    #region Keyboard input movement
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
    }
    #endregion


    #region Swipe Controls
    public void SetSwipeHorizontal()
    {
        if (SwipeManager.swipeLeft)// || Input.GetKey(KeyCode.A))
        {
            desiredLane--;
            Debug.Log(desiredLane);
            if (desiredLane < 0f)
            {
                desiredLane = 0f;
            }
        }
        else if (SwipeManager.swipeRight)// || Input.GetKey(KeyCode.D))
        {
            desiredLane++;
            Debug.Log(desiredLane);
            if (desiredLane > 2f)
            {
                desiredLane = 2f;
            }
        }
        if (desiredLane == 0f)
        {
            transform.DOMoveX(-3.5f, 0.5f);
        }
        if (desiredLane == 1f)
        {
            transform.DOMoveX(0f, 0.5f);
        }
        if (desiredLane==2f)
        {
            transform.DOMoveX(3.5f, 0.5f);
        }

    }
    #endregion

    #region Forward Movement
    public void Velocity()
    {
        //Vector3 dir = new Vector3(0, 0, 0.2f)*Time.fixedDeltaTime;
        //playerRigidbody.velocity = dir;
        //playerRigidbody.AddForce(dir, ForceMode.VelocityChange);

        animator.SetBool("Run", true);
        var v3 = transform.forward * speed;
        v3.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = v3;
    }

    #endregion

    private bool Die()
    {
        if (transform.position.x < -5.5f || transform.position.x > 5.4f)
        {
            isMove = false;
            Debug.Log(isMove);
            UIManager.UIInstance.LoadDiePanel();

            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelComplete"))
        {
            gameObject.SetActive(false);
            UIManager.UIInstance.LoadLevelWinPanel();
        }
    }

    void DragInputs()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //this.transform.DOMoveX(1, 1);
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 0.01f,
                    transform.position.y, transform.position.z);
            }
        }
    }
}





