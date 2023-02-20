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

        public Transform gridParent; // 格子和数字的父物体

    
        public Dictionary<int, int> gridConfig = new Dictionary<int, int>()
        {
            {4, 85},
            {5, 75},
            {6, 65}
        }; // 不同模式对应的格子宽度

        //public GameObject gridPrefabs; 

        private int row;
        private int col;

        public MyGrid[][] grids = null; // 声明用于管理格子的数组(模式选择后格子的数量不会变化，因此用数组存储)
        public List<MyGrid> canCreateNumberGrid = new List<MyGrid>(); // 声明用于存储可以产生数字的格子(由于已经有数字的格子不能再产生数字，这样的格子数量是会变动的，因此使用list存储)

        public GameObject gridPrefab; // 格子的预制体声明
        public GameObject numberPrefab; // 数字的预制体声明

        public Vector3 mouseDownPos, mouseUpPos; // 鼠标按下和抬起的位置

        //private MoveType moveType; // 鼠标滑动的方向


        // 返回上一步
        public void OnBackClick()
        {

        }


        // 再来一次
        public void OnAgainClick()
        {

        }

        // 返回大厅
        public void OnExitClick()
        {

        }

        // 初始化格子
        public void InitGrid()
        {
            // 1. 获取格子数量以及宽度
            // 1.1 获取格子的数量
            int gridNum = PlayerPrefs.GetInt(Constant.GameModel, 4); // 获取格子模式，若没有获取到，则默认为 4 * 4
            // 1.2 获取格子的父物体的GridLayoutGroup组件
            GridLayoutGroup gridLayoutGroup = gridParent.GetComponent<GridLayoutGroup>();
            // 1.3 设置该组件的constraintCount值，用于设置一行的数量
            gridLayoutGroup.constraintCount = gridNum;
            // 1.4 设置格子的宽度
            gridLayoutGroup.cellSize = new Vector2(gridConfig[gridNum], gridConfig[gridNum]);

            grids = new MyGrid[gridNum][]; // 初始化格子的行数

            // 2. 创建格子
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

            CreateNumber(); // 创建一个数字
        }

        // 创建一个格子
        public MyGrid CreateGrid()
        {
            GameObject gameObject  = Instantiate(gridPrefab, gridParent); // 实例化格子预制体
            return gameObject.GetComponent<MyGrid>(); 
        }

        // 创建一个数字
        public void CreateNumber()
        {
            // 找到数字所在的格子
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Debug.Log(grids[i][j]);
                    if ( !grids[i][j].IsHasNumber()) canCreateNumberGrid.Add(grids[i][j]); // 若这个格子没有数字，将格子添加到可创建数字格子的列表中
                }
            }

            if (canCreateNumberGrid.Count == 0) return; // 没有可以创建数字的格子，直接返回
        
            // 产生一个随机的格子索引
            //int gridIndex = RandomNumberGenerator.GetInt32(0, canCreateNumberGrid.Count);
            int gridIndex = Random.Range(0, canCreateNumberGrid.Count);

            Debug.Log("格子索引：" + gridIndex);
            GameObject gameObject = Instantiate(numberPrefab, canCreateNumberGrid[gridIndex].transform); // 实例化数字预制体，数字的父节点为格子

            // 初始化实例数字
            gameObject.GetComponent<Number>().InitNumber(canCreateNumberGrid[gridIndex]);
        }

        // 获取鼠标按下的位置
        public void OnMouseDown()
        {
            mouseDownPos = Input.mousePosition; // 获取鼠标按下位置
            //Debug.Log(mouseDownPos);
        }

        // 获取鼠标滑动方向
        public void OnMouseUp()
        {
            mouseUpPos = Input.mousePosition; // 获取鼠标抬起位置
            //Debug.Log(mouseUpPos);

            // 鼠标滑动距离过小时，滑动无效
            if (Vector3.Distance(mouseDownPos, mouseUpPos) < 100) return;
            // 获取鼠标滑动方向
            MoveType moveType = GetMoveType();
            Debug.Log("滑动方向：" + moveType);
            MoveNumber(moveType);
        }

        public MoveType GetMoveType()
        {
            if (Mathf.Abs(mouseUpPos.x - mouseDownPos.x) >
                Mathf.Abs(mouseUpPos.y - mouseDownPos.y)) // x方向移动距离大于y方向上移动距离，则在x方向滑动
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

        // 移动数字
        public void MoveUp()
        {
            // 按列遍历，每列从第二行开始遍历
            for (int j = 0; j < col; j++)
            {
                for (int i = 1; i < row; i++)
                {
                    Number number = grids[i][j].GetNumber();
                    if (grids[i][j].IsHasNumber()) // 当前格子有数字
                    {
                        for (int m = i - 1; m >= 0; m--) // 从上一行格子遍历
                        {
                            if (!grids[m][j].IsHasNumber()) number.MovetoGrid(grids[m][j]);// 上一行格子没有数字，则往上移
                            else
                            {
                                if (number.IsMerge(grids[m][j]))
                                {
                                    grids[m][j].GetNumber().NumberMerge();

                                    number.GetGrid().SetNumber(null); // 将格子置空
                                    GameObject.Destroy(number.gameObject); // 销毁数字
                                }

                                break;
                            } // TODO: 上一行有数字，判断是否可以合并
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
