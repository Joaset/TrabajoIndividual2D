using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private string enemyName;
    private float healthPoints;
    [SerializeField] private float enemySpeed;
    [SerializeField] private GameObject explosionEnemigo;

    void Start()
    {
        enemyName = "Skull";
        healthPoints = 2f;
    }

   
    void Update()
    {
        
    }

    public void TomarDaño(float daño)
    {
        healthPoints -= daño;
        if (healthPoints<= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Muerte()
    {
        Instantiate(explosionEnemigo, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
