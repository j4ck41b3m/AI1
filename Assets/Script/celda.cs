using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class celda : MonoBehaviour
{
    public int x, y;
    public bool bomb;
    public TextMeshProUGUI nums;
    public GameObject square;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (bomb)
        {
            square.GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        else
            nums.text = Generador.gen.GetBombsAlrededor(x, y).ToString();
    }
}
