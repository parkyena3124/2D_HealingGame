using UnityEngine;
using UnityEngine.InputSystem;

public class RangeCheck : MonoBehaviour
{
    GameObject interactionObject;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && interactionObject != null) 
        {
            Debug.Log("상호작용 실행");
        }
    }

    void OnTriggerEnter2D(Collider2D inRangeObject)
    {
        if (inRangeObject.CompareTag("Interactable"))
        {
            interactionObject = inRangeObject.gameObject;
            Debug.Log("범위 안에 들어옴");
        }
    }

    void OnTriggerExit2D(Collider2D outRangeObject)
    {
        if (outRangeObject.CompareTag("Interactable"))
        {
            interactionObject = null;
            Debug.Log("범위 밖에 나감");
        }
    }

}
