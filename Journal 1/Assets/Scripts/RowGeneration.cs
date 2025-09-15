using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    int drawNumber, inputNumber;
    float sqSize;
    public Button generate;
    public TMP_InputField input;
    bool isClicked;
    void Start()
    {
        drawNumber = 5;
        sqSize = 0.5f;
        isClicked = false;
        isClicked = false;
        input.text = "5";
        generate.onClick.AddListener(GenerateSquares);
    }

    void Update()
    {
        if (isClicked == true)
        {
            Vector2 sqStart = new Vector2((0 - (drawNumber * sqSize) / 2), 0);
            Vector2 sqEnd = new Vector2((0 + (drawNumber * sqSize) / 2), 0);
            Debug.DrawLine(sqStart, sqEnd);
            sqStart.y -= sqSize;
            sqEnd.y -= sqSize;
            Debug.DrawLine(sqStart, sqEnd);
            for (int i = 0; i <= drawNumber; i++)
            {
                Vector2 sqTop = new Vector2((0 - (drawNumber * sqSize) / 2) + (sqSize * i), 0);
                Vector2 sqBottom = new Vector2(sqTop.x, 0 - sqSize);
                Debug.DrawLine(sqTop, sqBottom);
            }
        }
    }

    void GenerateSquares()
    {
        isClicked = true;
        string temp = input.text;
        bool isValid = int.TryParse(temp, out inputNumber);
        if ((isValid == false) || (inputNumber < 0))
        {
            input.text = "Invalid Number!";
        }
        else
        {
            drawNumber = inputNumber;
        }
    }
}
