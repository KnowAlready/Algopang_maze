using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maze : MonoBehaviour {

    public const int SIZE_X = 10;
    public const int SIZE_Y = 10;
    // Start is called before the first frame update
    void Start() {
        foreach (Renderer a in GetComponentsInChildren<Renderer>()) {
            a.enabled = false;
        }
        int[,] maze = new int[SIZE_X, SIZE_Y];
        maze[0, 0] = 1;
        int i, x = 0, y = 0, rotate;

        for (i = 0; i < 100000; i++) {

            rotate = Random.Range(1, 5); // 1위 2오른 3아래 4왼

            if (rotate == 1) {
                if (y == 0)
                    continue; //만약 위에 공간이 없다면 rotate 다시설정

                if (maze[x, y - 2] == 0) { //두칸위가 비어있다면
                    y--; maze[x, y] = 1;
                    y--; maze[x, y] = 1;
                }
                else { //두칸위가 채워져있다면
                    y -= 2;
                }
            }

            if (rotate == 2) {
                if (x == SIZE_X - 2)
                    continue;

                if (maze[x + 2, y] == 0) {
                    x++; maze[x, y] = 1;
                    x++; maze[x, y] = 1;
                }
                else {
                    x += 2;
                }
            }

            if (rotate == 3) {
                if (y == SIZE_Y - 2)
                    continue;

                if (maze[x, y + 2] == 0) {
                    y++; maze[x, y] = 1;
                    y++; maze[x, y] = 1;
                }
                else {
                    y += 2;
                }
            }

            if (rotate == 4) {
                if (x == 0)
                    continue;

                if (maze[x - 2, y] == 0) {
                    x--; maze[x, y] = 1;
                    x--; maze[x, y] = 1;
                }
                else {
                    x -= 2;
                }
            }
        }
        int n = 0, m = 0;
        foreach (Renderer a in GetComponentsInChildren<Renderer>()) {
            if(maze[n, m] == 0)
                a.enabled = true;
            m++;
            if(m == 9) {
                m = 0;
                n++;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
