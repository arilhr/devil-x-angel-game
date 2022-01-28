using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Reference")]
    public PlayerMovement playerMove;

    [Header("Properties")]
    public float speed;

    private float horizontalInput;
    private bool isCrouch;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        isCrouch = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
    }

    private void FixedUpdate()
    {
        playerMove.Move(speed * horizontalInput * Time.fixedDeltaTime, isCrouch, isJumping);
        isJumping = false;
    }

    private void InputPlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
        }
    }
}
