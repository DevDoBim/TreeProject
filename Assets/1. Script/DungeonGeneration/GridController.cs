using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public Room room;
    [System.Serializable]
    public struct Grid
    {
        public int columns, rows;
        public float verticalOffset, horizontalOffset;
    }
    public Grid grid;
    public GameObject gridTile;
    public List<Vector2> availablePoints = new List<Vector2>();

    void Awake()
    {
        room = GetComponentInParent<Room>(); //방 생성 컴포넌트 호출
        grid.columns = room.Width - 2; //몬스터가 생성 될 때 벽에 겹쳐 생성되지 않게 하기 위해 방 넓이보다 공간을 축소시켜 생성한다.
        grid.rows = room.Height - 2; //넓이와 마찬가지로 높이도 축소시킨다.
        GenerateGrid(); //몬스터 생성되는 Grid 함수 호출
    }
    public void GenerateGrid() //몬스터가 생성되는 Grid 함수
    {
        grid.verticalOffset += room.transform.localPosition.y;
        grid.horizontalOffset += room.transform.localPosition.x;

        for(int y = 0; y < grid.rows; y++)
        {
            for(int x = 0; x < grid.columns; x++)
            {
                GameObject go = Instantiate(gridTile, transform);
                go.GetComponent<Transform>().position = new Vector2(x - (grid.columns - grid.horizontalOffset),
                    y - (grid.rows - grid.verticalOffset));
                go.name = "X: " + x + ", Y: " + y;
                availablePoints.Add(go.transform.position);
            }
        }

    }
}
