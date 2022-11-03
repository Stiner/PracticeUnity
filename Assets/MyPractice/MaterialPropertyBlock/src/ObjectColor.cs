namespace MyPractice.MaterialPropertyBlock
{
    using UnityEngine;

    public class ObjectColor : MonoBehaviour
    {
        public Color _color = new Color(1, 1, 1, 1);
        public bool _flag = false;

        private Renderer _renderer = null;
        private UnityEngine.MaterialPropertyBlock _matPropBlock = null;

        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();

            _matPropBlock = new UnityEngine.MaterialPropertyBlock();
        }

        private void Update()
        {
            if (_flag)
            {
                _renderer.SetPropertyBlock(null);
            }
            else
            {
                _matPropBlock.SetColor("_Color", _color);
                _renderer.SetPropertyBlock(_matPropBlock);
            }
        }
    }
}