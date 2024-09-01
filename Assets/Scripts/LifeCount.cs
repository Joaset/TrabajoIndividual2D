using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    private float vida;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = vida.ToString() + "/100";
    }

    public void TotalVida(float vidaActual)
    {
        vida = vidaActual;
    }
}
