using UnityEngine;

namespace Interfaces
{
    public interface IInteractable
    {
        string Title { get; }
        void Interact(GameObject interactor);
    }
}
