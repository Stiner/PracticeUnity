namespace MyPractice.VirtualCamera
{
    using System.Collections;
    using UnityEngine;
    using Unity.Cinemachine;

    public class SceneMain : MonoBehaviour
    {
        private const int DefaultPriority = 10;

        public CinemachineVirtualCameraBase[] m_arrVirtualCam;
        public float m_lerpSpeed = 10f;

        private int m_activeVirtualCamIdx = 0;

        private CinemachineMixingCamera m_mixerCamera;
        private float m_mixerWeight = 0;
        private bool m_mixingImmediatly = false;

        public float MixerWeight => m_mixerWeight;

        private void Start()
        {
            for (int i = 0; i < m_arrVirtualCam.Length; i++)
            {
                var vCam = m_arrVirtualCam[i];
                vCam.Priority = DefaultPriority;

                if (m_arrVirtualCam[i] is CinemachineMixingCamera)
                {
                    var mixerCam = m_arrVirtualCam[i] as CinemachineMixingCamera;

                    for (int j = 0; j < mixerCam.ChildCameras.Count; ++j)
                    {
                        var childMixerCam = mixerCam.ChildCameras[j];
                        childMixerCam.Priority = DefaultPriority;

                        mixerCam.SetWeight(j, j == 0 ? 1 : 0);
                    }
                }
            }

            m_arrVirtualCam[0].Priority = DefaultPriority + 1;

            StartCoroutine(CoroutineUpdateMixerWeight());
        }

        public void SetActiveVirtualCam(int idx)
        {
            m_activeVirtualCamIdx = Mathf.Clamp(idx, 0, m_arrVirtualCam.Length);

            for (int i = 0; i < m_arrVirtualCam.Length; i++)
            {
                var vCam = m_arrVirtualCam[i];
                vCam.Priority = (i == m_activeVirtualCamIdx) ? DefaultPriority + 1 : DefaultPriority;
            }

            m_mixerWeight = 0;
            m_mixingImmediatly = true;
        }

        public void SetWeightMixerWeight(float weight)
        {
            m_mixerCamera = m_arrVirtualCam[m_activeVirtualCamIdx] as CinemachineMixingCamera;
            if (m_mixerCamera == null)
                return;

            m_mixerWeight = Mathf.Clamp01(weight);
        }

        private IEnumerator CoroutineUpdateMixerWeight()
        {
            float weight = 0;

            for (; ; )
            {
                if (m_mixingImmediatly)
                {
                    m_mixingImmediatly = false;
                    weight = m_mixerWeight;
                }

                if (m_mixerCamera != null)
                {
                    if (Mathf.Approximately(weight, m_mixerWeight))
                    {
                        weight = m_mixerWeight;
                    }
                    else
                    {
                        weight = Mathf.Lerp(weight, m_mixerWeight, Time.deltaTime * m_lerpSpeed);
                    }

                    m_mixerCamera.SetWeight(0, -weight + 1f);
                    m_mixerCamera.SetWeight(1, weight);
                }

                yield return null;
            }
        }
    }
}