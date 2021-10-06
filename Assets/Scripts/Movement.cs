using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rigidbody;
    [SerializeField] float speed = 4;
    [SerializeField] float Force = 4;

    bool _rightPressed;
    bool _leftPressed;
    bool _jump;

    private void Awake()
    {
        
        _rightPressed = false;
        _leftPressed = false;
        _jump = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _leftPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rightPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _leftPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _rightPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
        }

    }

    private void FixedUpdate()
    {
        //d = v*t;
        if(_rightPressed)
            transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        if(_leftPressed)
            transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);

        if (_jump )//&& check if on the ground
        {
            _jump = false;
            Rigidbody.AddForce(new Vector2(0, Force));
        }

    }

}
