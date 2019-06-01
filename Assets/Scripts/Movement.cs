using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravity = 20.0f;
    public float jumpSpeed = 5.0f;

    //public float distance = 5.0f;
    CharacterController _cController;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

        }

        moveDirection.y -= gravity*Time.deltaTime;

        _cController.Move(moveDirection * Time.deltaTime);
    }
}
