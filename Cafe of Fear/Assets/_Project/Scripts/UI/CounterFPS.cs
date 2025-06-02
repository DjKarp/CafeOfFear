using UnityEngine;
using TMPro;

namespace CafeOfFear
{
    public class CounterFPS : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;
        private float _deltaTime = 0.0f;
        private float _miliSecond;
        private float _fps;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            SetCounterFPS();
        }

        private void SetCounterFPS()
        {
            _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
            _miliSecond = _deltaTime * 1000.0f;
            _fps = 1.0f / _deltaTime;
            _textMesh.text = string.Format("{0:0.0} ms ({1:0.} fps)", _miliSecond, _fps);
        }
    }
}
