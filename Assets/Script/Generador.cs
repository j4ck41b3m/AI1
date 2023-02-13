using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Generador : MonoBehaviour
{
    public GameObject celda, congrats, boom;
    public TMP_InputField Wd, Ht, Bm;
    public int   bCount, sCount;
    private int width, height, bombsnumber;
    public GameObject[][] map;
    public static Generador gen;
    // Start is called before the first frame update
    void Start()
    {
        width = byte.Parse(Wd.text);
        height = byte.Parse(Ht.text);
        bombsnumber = byte.Parse(Bm.text);
        sCount = (width * height) - bombsnumber;
        bCount = bombsnumber;
       gen = this;

        map = new GameObject[width][];

        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(celda, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<celda>().x = i;
                map[i][j].GetComponent<celda>().y = j;
              
            }
        }


        Camera.main.transform.position = new Vector3((float)width / 2 -0.5f, (float)height / 2 -0.5f, -10);

        for (int i = 0; i < bombsnumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!map[x][y].GetComponent<celda>().bomb)
            {
                map[x][y].GetComponent<celda>().bomb = true;
            }
           // map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void Update()
    {
        if (bCount <= 0)
            boom.SetActive(true);
        if (sCount <= 0)
            congrats.SetActive(true);
    }

    public void lessBombs()
    {
        bCount--;
    }

    public void lessSquares()
    {
        sCount--;
    }

    public int GetBombsAlrededor(int x, int y)
    {
        int contador = 0;
        if (x > 0 && y < (height - 1) && map[x - 1][y + 1].GetComponent<celda>().bomb)
            contador++;
        if (y < (height - 1) && map[x][y + 1].GetComponent<celda>().bomb)
            contador++;
        if (x < (width - 1) && y < (height - 1) && map[x +1][y + 1].GetComponent<celda>().bomb)
            contador++;
        if (x > 0 && map[x - 1][y].GetComponent<celda>().bomb)
            contador++;
        if (x < (width - 1) && map[x + 1][y].GetComponent<celda>().bomb)
            contador++;
        if (x < 0 && y <0 && map[x - 1][y + 1].GetComponent<celda>().bomb)
            contador++;
        if (y > 0 && map[x][y - 1].GetComponent<celda>().bomb)
            contador++;
        if (x < (width - 1) && y > 0 && map[x + 1][y - 1].GetComponent<celda>().bomb)
            contador++;
        return contador;
    }
}
