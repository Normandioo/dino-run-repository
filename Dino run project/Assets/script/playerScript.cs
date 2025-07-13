using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _jump = false;
    private bool _grounded = true;
    [SerializeField] float _jumpForce = 5f;



    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _jump = true;
        }


    }
    private void FixedUpdate()
    {
        if (_jump == true && _grounded == true)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _grounded = false;
            _jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("landed");
            _grounded = true;
        }
    } 
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("ground"))
        {
            _grounded = false;
        }
    }
}