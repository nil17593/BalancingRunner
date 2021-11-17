using UnityEngine;


public class CharacterBoyController : MonoBehaviour
{
    #region Private Components
    private Rigidbody playerRigidbody;
    private Vector3 forwardMov;
    private Vector3 leftMov;
    private Vector3 rightMov;
    private Touch touch;
    private bool isMove;
    private float timer=10f;
    #endregion

    #region Serialized Fields
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    #endregion

    private void Start()
    {
        timer = 10f;
        speed = 3f;
        animator.SetBool("Walk", true);
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        #region Touch Inputs
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //drag control only on x axis
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 0.01f,
                    transform.position.y, transform.position.z);
            }
        }

        #endregion
        else
        {
            ForwardMovement();
        }
        Die();

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //speed = 10f;
            animator.SetBool("Run", true);
        }
    }

    private void FixedUpdate()
    {
        ForwardMovement();
        HorizontalMovement();
    }

    #region Forward Movement code

    //forward movement 
    private void ForwardMovement()
    {
        isMove = true;
        forwardMov = speed * Time.fixedDeltaTime * transform.forward;
        playerRigidbody.MovePosition(playerRigidbody.position + forwardMov);

        //if (Time.time>7f)//after some time player will start run
        //{
        //    speed = 10f;
        //    animator.SetBool("Run", true);
        //}

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
        //else
        //{
        //    ForwardMovement();
        //}
    }
    #endregion

    private bool Die()
    {
        if (transform.position.y < 0)
        {
            //playerRigidbody.isKinematic = true;
            isMove = false;
            Debug.Log(isMove);
            UIManager.UIInstance.LoadDiePanel();
            return true;
        }
        return false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            //speed++;
            speed += 0.3f;
            ScoreController.Instance.IncreaseScore(1);
        }

        if (other.CompareTag("LevelComplete"))
        {
            gameObject.SetActive(false);
            UIManager.UIInstance.LoadLevelWinPanel();
        }
    }


    private void TouchInputs()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved && transform.position.x>-4f)
            {
                transform.position = new Vector3(transform.position.x - touch.deltaPosition.x + .001f,
                    transform.position.y, transform.position.z);
            }
            else if(touch.phase==TouchPhase.Moved && transform.position.x < 4f)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x + .001f,
                   transform.position.y, transform.position.z);
            }
        }
    }

  
}
