using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// �� ���� �� ���̺긦 �����ϴ� Ŭ����
    /// </summary>
    public class WaveSpawnManager : MonoBehaviour
    {
        #region Variables
        //�� ������ ������Ʈ -����
        public GameObject enemyPrefab;

        //public Transform start; == this.transform

        //���� (5��)Ÿ�̸�
        public float spawnTimer = 5f;  //Ÿ�̸� ���� �ð�
        private float countdown = 0f;   //�ð� ���� ����

        //���̺� ī��Ʈ
        private int waveCount = 0;

        //UI - Text
        public TextMeshProUGUI countdownText;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //Enemy Spawn();
        }

        private void Update()
        {
            //���� (5��)Ÿ�̸�
            countdown += Time.deltaTime;
            if (countdown >= spawnTimer)
            {
                //Ÿ�̸� ��� ����
                StartCoroutine(SpawnWave());

                //Ÿ�̸� �ʱ�ȭ
                countdown = 0f;
            }

            //UI - ī��Ʈ�ٿ� �ؽ�Ʈ
            //countdown Ư�� ���� ����(min, max) (- ���� �� �ǵ��� ����)
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            //countdownText.text = string.Format("{0:00.00}", countdown); //�Ǽ�(�Ҽ��� ����) ���
            countdownText.text = Mathf.Round(countdown).ToString();       //�ݿø��Ͽ� ���� ���

        }
        #endregion

        #region Custom Method

        //enemy ���� ���̺�
        IEnumerator SpawnWave()
        { 
            waveCount++;
            Debug.Log($"���̺� ī��Ʈ: {waveCount}");

            //0.5�� �����Ͽ� enemy ����
            for (int i = 0; i < waveCount; i++)
            {
                EnemySpawn();
                yield return new WaitForSeconds(0.5f);   
            }
        }

        //������ ��ġ�� enemy 1�� ����
        void EnemySpawn()
        {
            Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        }
        #endregion

    }
}
