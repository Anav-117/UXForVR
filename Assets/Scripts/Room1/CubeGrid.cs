using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrid : MonoBehaviour
{

    public GameObject cube;
    int num_rows = 5;
    int num_cols = 5;

    GameObject[,] cubeArray;
    GameObject currentCube;
    Color ogColor;

    int MAX_HEIGHT = 5;
    int MAX_WIDTH = 5;

    float offset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
        GenerateGrid();
    }

    public void SetNumRows(int num) {
        num_rows = num;
    }
    public void SetNumCols(int num) {
        num_cols = num;
    }

    void GenerateGrid() {
        cubeArray = new GameObject[num_rows,num_cols];

        for (int i=0; i<num_rows; i++) {
            //cubeArray[i] = new GameObject[num_cols];
            for (int j=0; j<num_cols; j++) {
                cubeArray[i,j] = Instantiate(cube);
                
                // CHECK 
                cubeArray[i,j].transform.position = new Vector3(transform.position.x + (i + i*offset) / num_rows, transform.position.y + (j + j*offset) / num_cols, transform.position.z);
                
                cubeArray[i,j].transform.localScale = new Vector3(1.0f / num_cols, 1.0f / num_rows, 1.0f / num_rows);
            }
        }
    } 

    void FreeGrid() {
        for (int i=0; i<num_rows; i++) {
            //cubeArray[i] = new GameObject[num_cols];
            for (int j=0; j<num_cols; j++) {
                Destroy(cubeArray[i,j]);// = Instantiate(cube);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCube != null) {
            if (currentCube.GetComponent<CubeColor>().hit == true) {
                FreeGrid();
                num_rows++;
                num_cols++;
                GenerateGrid();

                currentCube = cubeArray[Random.Range(0, num_rows-1),Random.Range(0, num_cols-1)];
                currentCube.GetComponent<CubeColor>().Blink();
            }
        }


        if (Input.GetKeyDown("p")) {

            currentCube = cubeArray[Random.Range(0, num_rows-1),Random.Range(0, num_cols-1)];
            currentCube.GetComponent<CubeColor>().Blink();
        }

        if (Input.GetKeyDown("]")) {
            FreeGrid();
            num_rows++;
            num_cols++;
            GenerateGrid();
        }

        if (Input.GetKeyDown("[")) {
            FreeGrid();
            num_rows--;
            num_cols--;
            GenerateGrid();
        }        
    }
}
