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
        room = GetComponentInParent<Room>(); //�� ���� ������Ʈ ȣ��
        grid.columns = room.Width - 2; //���Ͱ� ���� �� �� ���� ���� �������� �ʰ� �ϱ� ���� �� ���̺��� ������ ��ҽ��� �����Ѵ�.
        grid.rows = room.Height - 2; //���̿� ���������� ���̵� ��ҽ�Ų��.
        GenerateGrid(); //���� �����Ǵ� Grid �Լ� ȣ��
    }
    public void GenerateGrid() //���Ͱ� �����Ǵ� Grid �Լ�
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
