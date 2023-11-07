using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] private GameObject explosionEnemigo;
    [SerializeField] public float dañoCausado;


    void Start()
    {
        dañoCausado = 1f;
    }

   
    void Update()
    {
        
    }

    public void TomarDaño(float daño)
    {
        healthPoints -= daño;

        if (healthPoints<= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Instantiate(explosionEnemigo, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
