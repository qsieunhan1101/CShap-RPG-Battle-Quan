using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;
    public Interactable focus;

    PlayerMotor motor;
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
        void SetFocus(Interactable newFocus)
        {

            if (newFocus != focus)
            {
                if (focus != null)
                {

                    focus.OnDefocused();
                }
                focus = newFocus;
                motor.FollowTarget(newFocus);

            }
            newFocus.OnFocused(transform);
        }

        void RemoveFocus()
        {
            if (focus != null)
            {
                focus.OnDefocused();

            }
            focus = null;
            motor.StopFollowTarget();
        }
    }
}
