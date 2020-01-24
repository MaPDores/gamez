using UnityEngine;
using Interfaces;

public class PlayerInteractions : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        IInteractable interactable = collider.GetComponent<IInteractable>();
        // Publish data into an event for the UI to pick it and display the name
        print("Aperte ESPAÇO para interagir com: " + interactable.Title);
    }

    void OnTriggerStay(Collider collider)
    {
        IInteractable interactable = collider.GetComponent<IInteractable>();
        if (interactable != null && Input.GetKeyDown(KeyCode.Space))
        {
            interactable.Interact(gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // Publish true on an event to disable UI
    }
}
