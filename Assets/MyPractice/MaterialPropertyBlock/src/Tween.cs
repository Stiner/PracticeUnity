namespace MyPractice.MaterialPropertyBlock
{
    using UnityEngine;

    public class Tween : MonoBehaviour
    {
        private Transform _transform;

        // Start is called before the first frame update
        private void Start()
        {
            _transform = transform;
        }

        // Update is called once per frame
        private void Update()
        {
            Vector3 pos = _transform.localPosition;
            pos.y = Mathf.Sin(Time.time);
            _transform.localPosition = pos;
        }
    }
}