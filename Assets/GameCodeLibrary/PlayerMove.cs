using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 5f; //플레이어 속도

    Vector2 wasdMove; //캐릭터 이동
    Rigidbody2D playerRigidbody;
    Animator playerAnimator;
    SpriteRenderer spriteX;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteX = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        wasdMove = Vector2.zero;

        if (Keyboard.current.dKey.isPressed)
        {
            wasdMove.x = 1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            wasdMove.x = -1f;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            wasdMove.y = 1f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            wasdMove.y = -1f;
        }
        wasdMove = wasdMove.normalized;
        if (wasdMove != Vector2.zero)
        {
            playerAnimator.SetBool("playerMoving", true);
        }
        else
        {
            playerAnimator.SetBool("playerMoving", false);
        }
        if (wasdMove.x < 0f)
        {
            spriteX.flipX = true;
        }
        else if (wasdMove.x > 0f)
        {
            spriteX.flipX = false;
        }
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + wasdMove * playerSpeed * Time.fixedDeltaTime);
    }
}
