using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class interact : MonoBehaviour
{
    public TMP_Text interactText;

    private void Start()
    {
        Color color = interactText.color;
        color.a = 0; // Make text invisible
        interactText.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger: " + other.name);

            Color color = interactText.color;
            color.a = 1; // Make text visible
            interactText.color = color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger: " + other.name);

            Color color = interactText.color;
            color.a = 0; // Hide text
            interactText.color = color;
        }
    }



    public void QuizScene()
    {
        SceneManager.LoadScene(1);
    }
}
