using UnityEngine;

namespace Sample
{
    public class ChairMove : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //transform.Translate(Vector3.forward * Time.deltaTime);
        }

        void Update()
        {
            //���ڸ� �̵��϶�
            //Debug.Log("������ �̵��ϱ�");
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

    }
}
