namespace MyPractice.Task
{
    using System.Threading.Tasks;
    using UnityEngine;

    public class SceneMain : MonoBehaviour
    {
        public Transform _transform = null;

        private bool _run;
        private bool _doRoll;
        private float _yaw;

        private void Awake()
        {
            _run = true;
            _doRoll = false;
            _yaw = 0.0f;
        }

        private void Start()
        {
            TaskAction();
        }

        private void OnDestroy()
        {
            _run = false;
        }

        private void Update()
        {
            _transform.rotation = Quaternion.Euler(0, _yaw, 0);
        }

        private async void TaskAction()
        {
            Debug.Log("Task run");

            while (_run)
            {
                if (_doRoll)
                {
                    _yaw += 1.0f;
                }

                //_transform.rotation = Quaternion.Euler(0, _yaw, 0);

                await Task.Delay(1);
            }

            Debug.Log("Task end");
        }

        private void RunRoll()
        {
            _doRoll = true;
        }

        private void StopRoll()
        {
            _doRoll = false;
        }

        #region UGUI Event handlers

        public void OnClickStart()
        {
            RunRoll();
        }

        public void OnClickStop()
        {
            StopRoll();
        }

        #endregion UGUI Event handlers
    }
}