using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayUntilSceneReload = 2f;
    [SerializeField] ParticleSystem[] finishEffect;
    private bool playedSFX = false;

    public void Disable()
    {
        playedSFX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playedSFX)
        {
            for (int i = 0; i < finishEffect.Length; i++)
                finishEffect.ElementAt(i).Play();
            GetComponent<AudioSource>().Play();
            FindObjectOfType<PlayerController>().DisableControl();
            playedSFX = true;
            Invoke(nameof(ReloadScene), delayUntilSceneReload);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}