using UnityEngine;
using UnityEngine.InputSystem;
using VirtualGamepad;

namespace VirtualGamepad.Input
{
    public class RemoteInputProvider : IInputProvider
    {
        private Vector2 move;
        private bool attack;

        public void ApplyNetworkData(Vector2 move, bool attack)
        {
            this.move = move;
            this.attack = attack;
        }

        public Vector2 Move() => move;
        public bool Attack() => attack;
        public bool Interact() => false; // Not implemented for remote input
        public bool Action() => false;
    }

}