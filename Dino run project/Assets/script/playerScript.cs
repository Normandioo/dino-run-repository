using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerScript : MonoBehaviour
{


    private Rigidbody2D _rb;
    private Animator _animator;

    private BoxCollider2D _boxCollider;

    //variable that holds a boolean value for the jump
    private bool _grounded = true;

    private bool _jump = false;
    private bool _isCrouching = false;

    //variable that holds a float value for the jump force
    [SerializeField] float _jumpForce = 10f;



    //on Script awake
    void Awake()
    {

        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _jump = true;
        }



    }
    //called each 0.02 seconds
    private void FixedUpdate()
    {

        _isCrouching = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Mouse1);
        _animator.SetBool("isCrouching", _isCrouching);

        // Animações de pulo e corrida
        if (!_grounded)
            _animator.Play("playerJump");
        else if (!_isCrouching)
            _animator.Play("playerRun");

        // Pulo
        if (_jump && _grounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _grounded = false;
            _jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the gameObject tag is "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //if the gameObject tag is "ground"
        if (other.gameObject.CompareTag("obstacle"))
        {
            //sets _grounded to false
            _grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("scoring"))
        {
            FindFirstObjectByType<GameManager>().IncreaseScore();
        }
        else if (other.gameObject.CompareTag("obstacle"))
        {
           
        }
    }
    
}





