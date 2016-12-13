using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


    public Transform groundCheck;
    public LayerMask ground;

    public float rdius;

    private bool _onGround;
    private bool _doubleJumped;

    [SerializeField]private float _jumpHeight = 10;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_onGround)
        {
            _doubleJumped = false;
        }

        _onGround = Physics2D.OverlapCircle(groundCheck.transform.position, rdius, ground);

        if (Input.GetMouseButtonDown(0) && _onGround)
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0) && !_doubleJumped && !_onGround)
        {
            Jump();
            _doubleJumped = true;
        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, _jumpHeight);
    }
}
