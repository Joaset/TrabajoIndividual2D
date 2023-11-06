using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float healthPoints;
    [SerializeField] private GameObject explosionEnemigo;
    public float dañoCausado;


    void Start()
    {
        healthPoints = 2f;
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
