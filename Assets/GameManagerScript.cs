using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);

        Vector3 position = Vector3.zero;
        Instantiate(block, position, Quaternion.identity);

        int[,] map =
        {
           {1,0,0,0,0,0,0,0,0,1 },
           {1,0,0,0,0,0,2,0,0,1 },
           {1,0,0,0,0,0,0,0,0,1 },
           {1,0,0,0,0,0,0,0,1,1 },
           {1,0,0,0,0,0,0,0,0,1 },
           {1,0,0,0,0,1,1,0,0,1 },
           {1,0,0,1,0,0,0,0,0,1 },
           {1,0,0,0,0,0,0,0,0,1 },
           {1,0,0,0,0,0,0,0,0,1 },
           {1,1,1,1,1,1,1,1,1,1 },
        };

        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);

        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {

                position.x = x;
                position.y = -y + 5;

                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }

                if (map[y,x] == 2)
                {
                    goal.transform.position = position;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
