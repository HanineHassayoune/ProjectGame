using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class MyManager : MonoBehaviour
{
    public GameObject cellGO;
    public Transform cellParent;
    public int rightAnswer;
    public RtlText equationTxt;
    List<CellBtn> cells=new List<CellBtn>();   //list of cells
    public List<int> rightAnswers = new List<int>(); //list of rightAnswer
    public List<int> As = new List<int>(); //list of a
    public List<int> Bs = new List<int>(); //list of b
    int indexRightAnswer = 0;//the default index of right answer
    public Game_Over_2_GameInteraction gameOverInteraction;
    public int CellCount;//level 0 --> 9

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++) {
            GenerateEquation();
        }
        
        SpawnCells();
        Equation(As[indexRightAnswer], Bs[indexRightAnswer]); //to affiche the equation 
    }

    void GenerateEquation()
    {
        int a , b ;
        a = Random.Range(0, 10);
        b = Random.Range(0, 10);
        As.Add(a);
        Bs.Add(b);
        rightAnswers.Add(a+b);
       // rightAnswer = a + b;  for one answer
        //Equation(a, b);
    }

    void SpawnCells()
    {
        for (int i = 0; i < CellCount; i++)
        {
            CellBtn cell = Instantiate(cellGO, cellParent).GetComponent<CellBtn>();
            if (i < rightAnswers.Count)
                cell.SetText(rightAnswers[i]);
            else
                cell.SetText(Random.Range(0, 20));

            cell.TextState();
            cell.man = this;
            cells.Add(cell);//to add cell to the list

        }

        for (int j = 0;j < cells.Count; j++)
        {
            //to put the result in random place 
            cells[j].transform.SetSiblingIndex(Random.Range(0,cells.Count));
        }
        
    }

    public void CheckAnswer(CellBtn pressedCell)
    {
        if(pressedCell.selectedNumber== rightAnswers[indexRightAnswer])
        {
            pressedCell.RightAnswer();
            indexRightAnswer++;
            if(indexRightAnswer==5)
               gameOverInteraction.Game_Over(true,3);
            else
               Equation(As[indexRightAnswer], Bs[indexRightAnswer]);
        }
        else
        {
            pressedCell.WrongAnswer();
            gameOverInteraction.Game_Over(false);
        }
    }

    void Equation(int a ,int b)
    {
        equationTxt.text= a.ToString()+ " + " + b.ToString() + " = ?";
    }
   

   
}
