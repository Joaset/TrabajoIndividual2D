using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float vida;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void restarVida(float vidaRestar)
    {
        vida -= vidaRestar;
    }

    public void sumarVida(float vidaSumar)
    {
        vida += vidaSumar;
    }

    public void resetVida()
    {
        vida = 100f;
    }
}
