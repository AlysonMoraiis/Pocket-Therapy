using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject _drawArea;

    private Bounds bounds;
    private Line activeLine;

    void Start()
    {
        // Obtenha os limites do objeto
        bounds = _drawArea.GetComponent<Renderer>().bounds;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Verifique se o mouse está dentro dos limites
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(bounds.Contains(mousePos))
            {
                GameObject newLine = Instantiate(linePrefab, _drawArea.transform);
                activeLine = newLine.GetComponent<Line>();
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        // Verifique se o mouse está dentro dos limites a cada atualização do quadro
        Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!bounds.Contains(currentMousePos))
        {
            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }
}
