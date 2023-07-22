using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManager : MonoBehaviour
{
    public GameObject cellGO;
    public Transform cellParent;

    public int rightAnswer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCells();
    }

    void SpawnCells()
    {
        for (int i = 0; i < 9; i++)
        {
            CellBtn cell = Instantiate(cellGO, cellParent).GetComponent<CellBtn>();
            cell.SetText(Random.Range(0, 100));
            cell.TextState();
        }
        
    }

    public void CheckAnswer(CellBtn pressedCell)
    {
        if(pressedCell.selectedNumber== rightAnswer)
        {
            pressedCell.RightAnswer();
        }
        else
        {
            pressedCell.WrongAnswer();
        }
    }

   
}
