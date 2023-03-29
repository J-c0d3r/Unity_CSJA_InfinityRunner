using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed = false;

    [SerializeField] private bool jumpBtn;
    [SerializeField] private bool shootBtn;

    [SerializeField] private GameController gc;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    private void FixedUpdate()
    {
        if (isPressed)
        {
            if(jumpBtn)
            {
                gc.playerJump();
            }

            if(shootBtn)
            {
                gc.playerShoot();
            }

        }
    }
}