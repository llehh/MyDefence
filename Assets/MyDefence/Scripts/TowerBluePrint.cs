using UnityEngine;
using System;

namespace MyDefence
{
    /// <summary>
    /// Ÿ�� �����͸� �����ϴ� (����ȭ ��) Ŭ����
    /// </summary>
    [Serializable]
    public class TowerBluePrint
    {
        public GameObject prefab;   //Ÿ�� �Ǽ��� �ʿ��� ������ ������Ʈ
        public int cost;            //Ÿ�� �Ǽ� ���
        public Vector3 offsetPos;   //Ÿ�� �Ǽ��� ��ġ ���� �� 

    }
}
