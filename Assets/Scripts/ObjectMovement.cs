using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB, pointC, pointD;
    [SerializeField] private float speedObject;
    private bool debeMover;
    private bool debeEsperar;
    private bool mueveA;
    private bool mueveB;
    private bool mueveC;
    private bool mueveD;
    private float tiempoEspera;
    private bool seMueve;

    void Start()
    {
        mueveA = true;
        mueveB = true;
        mueveC = true;
        mueveD = true;
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
        float disttanciaC = Vector2.Distance(transform.position, pointC.position);
        float disttanciaD = Vector2.Distance(transform.position, pointD.position);

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
                    mueveC = false;
                    mueveD = false;
                }

                else
                {
                    mueveA = false;
                    mueveB = true;
                    mueveC = false;
                    mueveD = false;
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
                    mueveA = false;
                    mueveB = false;
                    mueveC = true;
                    mueveD = false;
                }

                else
                {
                    mueveA = false;
                    mueveB = false;
                    mueveC = true;
                    mueveD = false;
                }
            }
        }

        if (disttanciaC > 0.1f && mueveC)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointC.position, speedObject * Time.deltaTime);
            if (disttanciaC < 0.3f && seMueve)
            {
                if (debeEsperar)
                {
                    StartCoroutine(Espera());
                    mueveA = false;
                    mueveB = false;
                    mueveC = false;
                    mueveD = true;
                }

                else
                {
                    mueveA = false;
                    mueveB = false;
                    mueveC = false;
                    mueveD = true;
                }
            }
        }

        if (disttanciaD > 0.1f && mueveD)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointD.position, speedObject * Time.deltaTime);
            if (disttanciaD < 0.3f && seMueve)
            {
                if (debeEsperar)
                {
                    StartCoroutine(Espera());
                    mueveA = true;
                    mueveB = false;
                    mueveC = false;
                    mueveD = false;
                }

                else
                {
                    mueveA = true;
                    mueveB = false;
                    mueveC = false;
                    mueveD = false;
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
