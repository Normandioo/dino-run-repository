using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerScript : MonoBehaviour
{


    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _grounded = true;

    private bool _jump = false;
    private bool _isCrouching = false;
    [SerializeField] float _jumpForce = 10f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {
        keyboardInputs();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the gameObject tag is "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            _grounded = true;
            Debug.Log(_grounded);
        }

        else if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("colidiu com obstaculo");
            FindFirstObjectByType<GameManager>().gameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("ground"))
        {

            _grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            FindFirstObjectByType<GameManager>().gameOver();
            _animator.Play("playerDeath");
        }
    }


    public void ResetsPlayerPosition()
    {
        _rb.transform.position = new Vector2(transform.position.x, -2.19f);
    }

    private void keyboardInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.UpArrow) && _grounded)
        {
            _grounded = false;
            _jump = false;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

         _isCrouching = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Mouse1);
        _animator.SetBool("isCrouching", _isCrouching);


        if (!_grounded)
            _animator.Play("playerJump");
        else if (!_isCrouching)
            _animator.Play("playerRun");


    }
}





