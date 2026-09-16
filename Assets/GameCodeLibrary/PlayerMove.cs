using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 5f; //플레이어 속도

    Vector2 wasdMove; //캐릭터 이동
    Rigidbody2D playerRigidbody;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        wasdMove = Vector2.zero;
        //wasdMove.x = 0f;
        //wasdMove.y = 0f;

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
        //transform.position = transform.position +
        //    (new Vector3(wasdMove.x, wasdMove.y, 0f) * playerSpeed * Time.deltaTime);
        //FixedUpdate가 역할을 대신 해줌
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + wasdMove * playerSpeed * Time.fixedDeltaTime);
    }
}
