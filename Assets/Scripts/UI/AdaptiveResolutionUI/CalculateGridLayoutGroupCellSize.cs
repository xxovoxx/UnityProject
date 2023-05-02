using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateGridLayoutGroupCellSize : MonoBehaviour
{
    RectTransform rectTransform;
    GridLayoutGroup gridLayoutGroup;

    //水平Cell数量
    public int horizontalCellsNumber;
    //垂直Cell数量
    public int verticalCellsNumber;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        gridLayoutGroup = gameObject.GetComponent<GridLayoutGroup>();
    }

    void Update()
    {
        gridLayoutGroup.cellSize = new Vector2(rectTransform.rect.width/horizontalCellsNumber, rectTransform.rect.height/verticalCellsNumber);
    }
}
