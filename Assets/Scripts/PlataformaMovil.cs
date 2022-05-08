using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform destino;
    private float speed = 1.5f;
    private Vector3 start, end;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = destino.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino.position, speed * Time.deltaTime);
        if (transform.position == destino.position)
        {
            if (destino.position == end)
            {
                destino.position = start;
            }
            else
            {
                destino.position = end;
            }
        }
    }
}
