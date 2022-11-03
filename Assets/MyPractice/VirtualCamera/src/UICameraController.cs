namespace MyPractice.VirtualCamera
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class UICameraController : MonoBehaviour
    {
        public SceneMain _cameraController;

        public float m_scrollSpeed = 0.1f;

        public void OnScroll(BaseEventData eventData)
        {
            var pointerData = eventData as PointerEventData;

            var delta = pointerData.scrollDelta.y;
            var v = _cameraController.MixerWeight + delta * m_scrollSpeed;

            _cameraController.SetWeightMixerWeight(v);
        }
    }
}