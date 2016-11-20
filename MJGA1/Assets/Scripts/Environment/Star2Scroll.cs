using UnityEngine;

namespace Assets.Scripts.Environment
{
    class Star2Scroll : MonoBehaviour
    {
        public float speed = 0.5f;

        // Update is called once per frame
        void Update()
        {
            Vector2 offset = new Vector2(0, Time.time * speed);

            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
    }
}
