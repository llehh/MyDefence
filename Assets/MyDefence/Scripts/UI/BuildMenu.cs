using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Ÿ�� ���� UI�� �����ϴ� Ŭ����
    /// </summary>
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        //BuildManager(�̱���) ��ü ����
        private BuildManager buildManager;

        //Ÿ�� ����Ʈ
        public TowerBluePrint machineGun;
        public TowerBluePrint rocketTower;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //����
            buildManager = BuildManager.Instance;
        }
        #endregion

        #region Custom Method
        //�ӽŰ� ��ư ���ý� ȣ��Ǵ� �Լ�
        public void SelectMachineGun()
        {
            //Debug.Log("�ӽŰ� Ÿ���� ���� �Ͽ����ϴ�");
            buildManager.SetTurretToBuild(machineGun);
        }

        //����Ÿ�� ��ư ���ý� ȣ��Ǵ� �Լ�

        public void SelectRocketTower()
        {
            //Debug.Log("���� Ÿ���� �Ǽ��� Ÿ���� �����Ͽ����ϴ�");
            buildManager.SetTurretToBuild(rocketTower);
        }

        #endregion
    }
}
