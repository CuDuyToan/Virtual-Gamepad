using UnityEngine;
using VirtualGamepad.Input;

namespace VirtualGamepad.SampleController
{
	public class Player: MonoBehaviour
	{
        public static Player Instance;
        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        //Input provider
        #region Input provider
        private IInputProvider inputProvider;
        public IInputProvider InputProvider => inputProvider;

        public void Init(IInputProvider provider)
        {
            inputProvider = provider;
        }
        #endregion Input provider

        private void Awake()
        {
            setSingleton();

            if (inputProvider == null)
            {
                //inputProvider = new LocalInputProvider();
                Init(new LocalInputProvider());
            }
        }

        private void Update()
        {
            Vector2 pos = inputProvider.Move();
            Debug.Log(pos);
        }
    }
}