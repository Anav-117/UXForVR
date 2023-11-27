using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

using Random=UnityEngine.Random;

public class CubeGrid : MonoBehaviour
{

    public GameObject cube;
    public int num_rows = 5;
    public int num_cols = 5;

    DateTime time;

    Color col;

    float ColorThreshold;

    public String ParticipantName;

    GameObject[,] cubeArray;
    GameObject currentCube;
    Color ogColor;

    public GameObject RefCube;

    public enum Type{
    Number,
    Color
    }
    public Type type;

    int MAX_HEIGHT = 5;
    int MAX_WIDTH = 5;

    float offset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
        GenerateGrid();
        StreamWriter outputFile = new StreamWriter("Data/" + ParticipantName + type + ".txt");
        //time = DateTime.Now;
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

                bool closeToRed = true;

                while(closeToRed) {
                    col = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
                    Vector3 dist = new Vector3(1.0f - col.r, -col.g, -col.b);
                    if (dist.magnitude > ColorThreshold) {
                        closeToRed = false;
                    }
                }

                cubeArray[i,j].GetComponent<Renderer>().material.color = col; 
                
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
                
                //Debug.Log(m_Dropdown.GetComponent<Dropdown>().value);

                //Debug.Log(Type);

                if (type == Type.Number) {
                    num_rows++;
                    num_cols++;
                }
                else if (type == Type.Color) {
                   if (ColorThreshold < 1.5f) {
                       ColorThreshold += 0.1f;
                   }
                }
                GenerateGrid();

                DateTime currentTime = DateTime.Now;

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = File.AppendText("Data/" + ParticipantName + type + ".txt"))
                {
                    outputFile.WriteLine((currentTime - time).Seconds * 1000 + (currentTime - time).Milliseconds);
                }

                time = currentTime;

                currentCube = cubeArray[Random.Range(0, num_rows-1),Random.Range(0, num_cols-1)];
                currentCube.GetComponent<CubeColor>().Blink();
            }
        }


        if (Input.GetKeyDown("p")) {
            RefCube.SetActive(false);
            currentCube = cubeArray[Random.Range(0, num_rows-1),Random.Range(0, num_cols-1)];
            currentCube.GetComponent<CubeColor>().Blink();
            time = DateTime.Now;
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
