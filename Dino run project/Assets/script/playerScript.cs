using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    //variable that holds the rigidBody component
    private Rigidbody2D _rb;
    private Animator _animator;

    private BoxCollider2D _boxCollider;

    //variable that holds a boolean value for the jump
    private bool _jump = false;

    //variable that holds a boolean value to check if the chracter is grounded
    private bool _grounded = true;

    //variable that holds a float value for the jump force
    [SerializeField] float _jumpForce = 10f;



    //on Script awake
    void Awake()
    {
        //the rb variable gets the rigidBody2D component
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }


    //is called eachframe
    private void Update()
    {

        //checks if the key space, or the leftMouseButton or the key up arrow were pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //sets the _jump variable to true
            _jump = true;
        }
    }
    //called each 0.02 seconds
    private void FixedUpdate()
    {

        if (_grounded == false)
        {
            _animator.Play("playerJump");
        }
        else
        {
            _animator.Play("playerRun");
        }
        //if the _jump variable is true and the _grounded variable is also true
        if (_jump == true && _grounded == true)
        {
            //aplly the jumpforce to the rigidBody
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            //sets _grounded to false
            _grounded = false;
            //sets _jump to false
            _jump = false;
        }
    }

    //called when the rigidBody detects another body when collided
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the gameObject tag is "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("grounde");
            //sets _grounded to true
            _grounded = true;
    
        }
    } 
    //called when the rigidBody leaves another body collider
    private void OnCollisionExit2D(Collision2D other)
    {
        //if the gameObject tag is "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            //sets _grounded to false
            _grounded = false;   
        }
    }
}