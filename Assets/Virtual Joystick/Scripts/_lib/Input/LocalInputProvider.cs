using UnityEngine;

namespace VirtualGamepad.Input
{
    public class LocalInputProvider : IInputProvider
    {
        private ControllerInput controls;
        private Vector2 move;
        private bool action;
        private bool interact;

        public LocalInputProvider()
        {
            this.controls = new ControllerInput();
            controls.Enable();

            controls.Default.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Default.Movement.canceled += ctx => move = Vector2.zero;

            controls.Default.Action.performed += ctx => action = true;
            controls.Default.Action.canceled += ctx => action = false;

            //controls.De

            controls.Default.Interact.performed += ctx => interact = true;
            controls.Default.Interact.canceled += ctx => interact = false;
        }

        public Vector2 Move() => move;
        public bool Action() => action;
        public bool Interact() => interact;
    }
}