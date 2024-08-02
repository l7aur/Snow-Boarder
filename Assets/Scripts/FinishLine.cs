using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayUntilSceneReload = 2f;
    [SerializeField] ParticleSystem[] finishEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < finishEffect.Length; i++)
                finishEffect.ElementAt(i).Play();
            Invoke(nameof(ReloadScene), delayUntilSceneReload);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}