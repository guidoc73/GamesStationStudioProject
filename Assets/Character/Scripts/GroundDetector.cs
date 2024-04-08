using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private ScreenButtonsCharacterController _characterController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            _characterController.SetOnGround(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _characterController.SetOnGround(false);
        }
    }
}
