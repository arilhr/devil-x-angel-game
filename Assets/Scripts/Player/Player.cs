using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Reference")]
    public PlayerMovement playerMove;
    public Animator characterAnim;

    [Header("Properties")]
    public float speed;
    public Transform respawnPos;

    private float horizontalInput;
    private bool isCrouch;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnPlayerDie.AddListener(() => Respawn());

        isCrouch = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        OnLand();
    }

    private void FixedUpdate()
    {
        playerMove.Move(speed * horizontalInput * Time.fixedDeltaTime, isCrouch, isJumping);
        isJumping = false;
    }

    private void InputPlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        characterAnim.SetBool("Walk", horizontalInput != 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            characterAnim.SetBool("Jump", isJumping);
        }

        if (Input.GetKey(KeyCode.S))
        {
            isCrouch = true;
        }
        else
        {
            isCrouch = false;
        }
    }

    public void OnLand()
    {
        characterAnim.SetBool("Jump", !playerMove.GetGrounded());
    }

    public void OnCrouch(bool isCrouching)
    {
        characterAnim.SetBool("Crouch", isCrouching);
    }

    public void Respawn()
    {
        transform.position = respawnPos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance == null) return;

        if (collision.tag == "Obstacle")
        {
            GameManager.instance.PlayerDie();
        }
    }
}
