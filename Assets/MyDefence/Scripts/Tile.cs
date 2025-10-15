using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    /// <summary>
    /// �� Ÿ���� �����ϴ� Ŭ����
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables
        //BuildManager(�̱���) ��ü ����
        private BuildManager buildManager;

        //Ÿ�Ͽ� ��ġ�� Ÿ�� ������Ʈ �ν��Ͻ�
        private GameObject tower;

        //Ÿ�Ͽ� ��ġ�� Ÿ�� ������Ʈ blueprint ��ü(������ ����, ��ġ������ġ...)
        private TowerBluePrint blueprint;

        //������ ������Ʈ �ν��Ͻ� ���� ����
        private Renderer renderer;

        //���콺�� ���� �ٲ�� �÷�
        public Color hoverColor;
        //Ÿ���� ���� ����
        private Color startColor;

        //���콺�� ���� �ٲ�� ���͸���
        public Material hoverMaterial;
        //Ÿ���� ���� ���͸���
        private Material startMaterial;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //����
            renderer = this.transform.GetComponent<Renderer>();
            buildManager = BuildManager.Instance;

            //�ʱ�ȭ
            startColor = renderer.material.color;
            startMaterial = renderer.material;
        }

        
        private void OnMouseDown()
        {
            //UI�� ������ ������ ��ġ ���Ѵ�
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //���� Ÿ���� �������� �ʾ����� ��ġ���� ���Ѵ�
            if (buildManager.CannotBuild == null)
            {
                Debug.Log("��ġ�� Ÿ���� �����ϴ�.");
                return;
            }

            //���� Ÿ�Ͽ� Ÿ��������Ʈ�� ������ ��ġ���� ���Ѵ�
            if (tower != null)
            {
                Debug.Log("Ÿ���� ��ġ���� ���մϴ�");
                return;
            }
          
            blueprint = buildManager.GetTurretToBuild();

            //Debug.Log("���콺 ��Ŭ���Ͽ� Ÿ�� ���� - ���⿡ Ÿ�� �Ǽ�");
            BuildTower();
        }

        private void OnMouseEnter()
        {
            //���� Ÿ���� �������� �ʾ����� ������� �ʴ´�
            if (buildManager.CannotBuild)
            {            
                return;
            }

            //renderer.material.color = hoverColor;
            renderer.material = hoverMaterial;
        }

        private void OnMouseExit()
        {
            //UI�� ������ ������ ��ġ ���Ѵ�
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //renderer.material.color = startColor;
            renderer.material = startMaterial;
        }
        #endregion

        #region Custom Method
        //Ÿ�� �Ǽ� 
        private void BuildTower()
        {
            //�Ǽ���� üũ
            if (buildManager.HasBuildCost == false)
            {
                Debug.Log("�Ǽ� ����� �����մϴ�");
                return;
            }

            //�Ǽ� ��� ����
            PlayerStats.UseMoney(blueprint.cost);

            tower = Instantiate(blueprint.prefab, this.transform.position + blueprint.offsetPos, Quaternion.identity);
            
            //towerToBuild = null; �Ǽ� �� �ٽ� �Ǽ����� ���ϰ� �Ѵ�
            buildManager.SetTurretToBuild(null);

            Debug.Log($"�Ǽ��ϰ� ���� ������: {PlayerStats.Money}");
        }
        #endregion
    }
}
