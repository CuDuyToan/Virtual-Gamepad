using UnityEngine;

namespace VirtualGamepad
{
    public interface IInputProvider
    {
        Vector2 Move();
        bool Action();
        bool Interact();
    }
}
