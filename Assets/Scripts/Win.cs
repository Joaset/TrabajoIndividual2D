using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.resetVida();
        AudioManager.Instance.PlayAudio(AudioManager.Instance.menuMusic);
    }
}
