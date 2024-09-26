using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    [SerializeField] Transform player;

    bool hasInteractable = false;

    public Transform interactionTransform;
    
    public virtual void Interact()
    {

    }
    private void Update()
    {
        if (isFocus && !hasInteractable)
        {
            float distance  = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteractable = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteractable = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteractable = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
