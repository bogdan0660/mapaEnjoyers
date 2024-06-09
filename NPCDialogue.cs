using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBox;

    private void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialogueBox != null && collision.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dialogueBox != null && collision.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(false);
        }
    }
}
