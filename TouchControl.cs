using UnityEngine;
using UnityEngine.EventSystems;

// Minimal mobile touch handler.
// Attach to a UI canvas with two transparent panels:
// - LeftPanel for joystick input (Drag -> sets move vector).
// - RightPanel for look input (Drag -> sets look vector).
// Hook PlayerController.mobileMoveInput and mobileLookInput to this script.

public class TouchControls : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public enum ControlSide { Left, Right }
    public ControlSide side = ControlSide.Left;
    public PlayerController playerController;

    private Vector2 startPos;
    private int pointerId = -1;
    private bool active = false;
    private Vector2 currentDelta = Vector2.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerId = eventData.pointerId;
        startPos = eventData.position;
        active = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!active || eventData.pointerId != pointerId) return;
        currentDelta = eventData.position - startPos;
        Vector2 norm = currentDelta / 100f; // scale down sensitivity
        if (side == ControlSide.Left)
        {
            // move: x = left/right, y = forward/back
            playerController.mobileMoveInput = Vector2.ClampMagnitude(new Vector2(norm.x, norm.y), 1f);
        }
        else
        {
            // look: horizontal and vertical
            playerController.mobileLookInput = Vector2.ClampMagnitude(new Vector2(norm.x, norm.y), 1f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId != pointerId) return;
        active = false;
        pointerId = -1;
        currentDelta = Vector2.zero;
        if (side == ControlSide.Left) playerController.mobileMoveInput = Vector2.zero;
        else playerController.mobileLookInput = Vector2.zero;
    }
}
