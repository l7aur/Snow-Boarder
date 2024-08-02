using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayUntilSceneReload = 2f;
    [SerializeField] ParticleSystem[] particleEffects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            for(int i = 0; i < particleEffects.Length; i++)
                particleEffects.ElementAt(i).Play();
            Invoke(nameof(ReloadScene), delayUntilSceneReload);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
