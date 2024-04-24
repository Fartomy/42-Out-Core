using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jmpSpeed;

    private Rigidbody2D _rgbBody;
    private bool _isOnTheGround = true;
    private Animator _animator;

    void Awake()
    {
        _rgbBody = GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (_rgbBody != null)
        {
            float horizontalVal = Input.GetAxis("Horizontal");
            if (horizontalVal < 0 || horizontalVal > 0)
            {
                _animator.SetFloat("Walking", Mathf.Abs(horizontalVal));
                if (horizontalVal > 0)
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                else if (horizontalVal < 0)
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            _rgbBody.velocity = new Vector3(horizontalVal * _moveSpeed, _rgbBody.velocity.y);
            if (Input.GetButtonDown("Jump") && _isOnTheGround)
            {
                _rgbBody.velocity = Vector3.up * _jmpSpeed;
                _isOnTheGround = false;
                _animator.SetBool("isJumping", true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tag_ground"))
        {
            _isOnTheGround = true;
            _animator.SetBool("isJumping", false);
        }
    }
}
