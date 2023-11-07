using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement2points : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB;
    [SerializeField] private float speedObject;
    private bool debeMover;
    private bool debeEsperar;
    private bool mueveA;
    private bool mueveB;
    private float tiempoEspera;
    private bool seMueve;

    void Start()
    {
        mueveA = true;
        mueveB = true;
        debeMover = true;
        speedObject = 2f;
        seMueve = true;
        tiempoEspera = 2f;
        debeEsperar = true;
    }


    void Update()
    {
        if (debeMover)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        float disttanciaA = Vector2.Distance(transform.position, pointA.position);
        float disttanciaB = Vector2.Distance(transform.position, pointB.position);

        if (disttanciaA > 0.1f && mueveA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speedObject * Time.deltaTime);
            if (disttanciaA < 0.3f && seMueve)
            {
                if (debeEsperar)
                {
                    StartCoroutine(Espera());
                    mueveA = false;
                    mueveB = true;
                }

                else
                {
                    mueveA = false;
                    mueveB = true;
                }
            }
        }

        if (disttanciaB > 0.1f && mueveB)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speedObject * Time.deltaTime);
            if (disttanciaB < 0.3f && seMueve)
            {
                if (debeEsperar)
                {
                    StartCoroutine(Espera());
                    mueveA = true;
                    mueveB = false;
                }

                else
                {
                    mueveA = true;
                    mueveB = false;
                }
            }
        }
    }

    IEnumerator Espera()
    {
        debeMover = false;
        seMueve = false;
        yield return new WaitForSeconds(tiempoEspera);
        debeMover = true; 
        seMueve = true;
    }
}
