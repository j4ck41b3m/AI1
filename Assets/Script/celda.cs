using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class celda : MonoBehaviour
{
    public int x, y;
    public bool bomb, bandera;
    public TextMeshProUGUI nums;
    public GameObject gen, square, flag;
    public BoxCollider2D box;
   

    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
        bandera = false;
        gen = GameObject.Find("Generador");
    }

    // Update is called once per frame
    void Update()
    {
        bandera = gen.GetComponent<Generador>().flagged;
    }

    private void OnMouseDown()
    {
        if (bandera)
        {
            flag.SetActive(true);
        }
        else
        {
            if (bomb)
            {
                square.GetComponent<SpriteRenderer>().material.color = Color.red;
                Generador.gen.lessBombs();

            }
            else
            {
                nums.text = Generador.gen.GetBombsAlrededor(x, y).ToString();
                Generador.gen.lessSquares();
            }
            box.enabled = false;
        }
        

    }
}
