using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorazonesGree : MonoBehaviour
{
    public Sprite[] corazones;

    // Start is called before the first frame update
    void Start()
    {
        int vidas = PlayerControllerGree.vida;
        CambioVida(vidas);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambioVida(int pos)
    {
        this.GetComponent<Image>().sprite = corazones[pos];
    }
}