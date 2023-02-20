using System.Collections.Generic;
using System.Security.Cryptography;
using Assets.Script.Enum;
using Script.Constant;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using Random = System.Random;

namespace Assets.Script.View
{
    public class GamePanel : MonoBehaviour
    {
        public TextMesh score;
        public TextMeshPro bestScore;
        public Button btnBack;
        public Button btnAgain;
        public Button btnExit;

        public Transform gridParent; // ���Ӻ����ֵĸ�����

    
        public Dictionary<int, int> gridConfig = new Dictionary<int, int>()
        {
            {4, 85},
            {5, 75},
            {6, 65}
        }; // ��ͬģʽ��Ӧ�ĸ��ӿ��

        //public GameObject gridPrefabs; 

        private int row;
        private int col;

        public MyGrid[][] grids = null; // �������ڹ�����ӵ�����(ģʽѡ�����ӵ���������仯�����������洢)
        public List<MyGrid> canCreateNumberGrid = new List<MyGrid>(); // �������ڴ洢���Բ������ֵĸ���(�����Ѿ������ֵĸ��Ӳ����ٲ������֣������ĸ��������ǻ�䶯�ģ����ʹ��list�洢)

        public GameObject gridPrefab; // ���ӵ�Ԥ��������
        public GameObject numberPrefab; // ���ֵ�Ԥ��������

        public Vector3 mouseDownPos, mouseUpPos; // ��갴�º�̧���λ��

        //private MoveType moveType; // ��껬���ķ���


        // ������һ��
        public void OnBackClick()
        {

        }


        // ����һ��
        public void OnAgainClick()
        {

        }

        // ���ش���
        public void OnExitClick()
        {

        }

        // ��ʼ������
        public void InitGrid()
        {
            // 1. ��ȡ���������Լ����
            // 1.1 ��ȡ���ӵ�����
            int gridNum = PlayerPrefs.GetInt(Constant.GameModel, 4); // ��ȡ����ģʽ����û�л�ȡ������Ĭ��Ϊ 4 * 4
            // 1.2 ��ȡ���ӵĸ������GridLayoutGroup���
            GridLayoutGroup gridLayoutGroup = gridParent.GetComponent<GridLayoutGroup>();
            // 1.3 ���ø������constraintCountֵ����������һ�е�����
            gridLayoutGroup.constraintCount = gridNum;
            // 1.4 ���ø��ӵĿ��
            gridLayoutGroup.cellSize = new Vector2(gridConfig[gridNum], gridConfig[gridNum]);

            grids = new MyGrid[gridNum][]; // ��ʼ�����ӵ�����

            // 2. ��������
            row = gridNum;
            col = gridNum;
            for (int i = 0; i < row; i++)
            {
                if (grids[i] == null)
                {
                    grids[i] = new MyGrid[gridNum];
                }
                for (int j = 0; j < col; j++)
                {
                    grids[i][j] = CreateGrid();
                }
            }

            CreateNumber(); // ����һ������
        }

        // ����һ������
        public MyGrid CreateGrid()
        {
            GameObject gameObject  = Instantiate(gridPrefab, gridParent); // ʵ��������Ԥ����
            return gameObject.GetComponent<MyGrid>(); 
        }

        // ����һ������
        public void CreateNumber()
        {
            // �ҵ��������ڵĸ���
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Debug.Log(grids[i][j]);
                    if ( !grids[i][j].IsHasNumber()) canCreateNumberGrid.Add(grids[i][j]); // ���������û�����֣���������ӵ��ɴ������ָ��ӵ��б���
                }
            }

            if (canCreateNumberGrid.Count == 0) return; // û�п��Դ������ֵĸ��ӣ�ֱ�ӷ���
        
            // ����һ������ĸ�������
            //int gridIndex = RandomNumberGenerator.GetInt32(0, canCreateNumberGrid.Count);
            int gridIndex = Random.Range(0, canCreateNumberGrid.Count);

            Debug.Log("����������" + gridIndex);
            GameObject gameObject = Instantiate(numberPrefab, canCreateNumberGrid[gridIndex].transform); // ʵ��������Ԥ���壬���ֵĸ��ڵ�Ϊ����

            // ��ʼ��ʵ������
            gameObject.GetComponent<Number>().InitNumber(canCreateNumberGrid[gridIndex]);
        }

        // ��ȡ��갴�µ�λ��
        public void OnMouseDown()
        {
            mouseDownPos = Input.mousePosition; // ��ȡ��갴��λ��
            //Debug.Log(mouseDownPos);
        }

        // ��ȡ��껬������
        public void OnMouseUp()
        {
            mouseUpPos = Input.mousePosition; // ��ȡ���̧��λ��
            //Debug.Log(mouseUpPos);

            // ��껬�������Сʱ��������Ч
            if (Vector3.Distance(mouseDownPos, mouseUpPos) < 100) return;
            // ��ȡ��껬������
            MoveType moveType = GetMoveType();
            Debug.Log("��������" + moveType);
            MoveNumber(moveType);
        }

        public MoveType GetMoveType()
        {
            if (Mathf.Abs(mouseUpPos.x - mouseDownPos.x) >
                Mathf.Abs(mouseUpPos.y - mouseDownPos.y)) // x�����ƶ��������y�������ƶ����룬����x���򻬶�
            {
                return mouseUpPos.x - mouseDownPos.x > 0 ? MoveType.RIGHT : MoveType.LEFT;
            }
            return mouseUpPos.y - mouseDownPos.y > 0 ? MoveType.UP : MoveType.DOWN;
        }

        public void MoveNumber(MoveType moveType)
        {
            switch (moveType)
            {
                case MoveType.DOWN:

                    break;
                case MoveType.UP:
                    MoveUp();
                    break;
                case MoveType.LEFT:
                    break;
                case MoveType.RIGHT:
                    break;
                default:
                    break; ;
            }
        }

        // �ƶ�����
        public void MoveUp()
        {
            // ���б�����ÿ�дӵڶ��п�ʼ����
            for (int j = 0; j < col; j++)
            {
                for (int i = 1; i < row; i++)
                {
                    Number number = grids[i][j].GetNumber();
                    if (grids[i][j].IsHasNumber()) // ��ǰ����������
                    {
                        for (int m = i - 1; m >= 0; m--) // ����һ�и��ӱ���
                        {
                            if (!grids[m][j].IsHasNumber()) number.MovetoGrid(grids[m][j]);// ��һ�и���û�����֣���������
                            else
                            {
                                if (number.IsMerge(grids[m][j]))
                                {
                                    grids[m][j].GetNumber().NumberMerge();

                                    number.GetGrid().SetNumber(null); // �������ÿ�
                                    GameObject.Destroy(number.gameObject); // ��������
                                }

                                break;
                            } // TODO: ��һ�������֣��ж��Ƿ���Ժϲ�
                        }
                        
                    }
                
                }
            }
            CreateNumber();
        }

        private void Awake()
        {
            InitGrid();
        }
    }
}
