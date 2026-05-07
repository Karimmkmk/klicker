using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Диалог")]
    [SerializeField] private DialogueData dialogueData;

    [Header("Дополнительно")]
    [SerializeField] private bool triggerOnce = false; // Исчезнуть после активации?
    [SerializeField] private GameObject visualHint;    // Подсказка "Нажмите E"

    private bool playerInRange;
    private bool alreadyTriggered;

    private void Awake()
    {
        if (visualHint != null)
            visualHint.SetActive(false);
    }

    private void Update()
    {
        if (!playerInRange || alreadyTriggered) return;

        // Ввод: можно заменить на Input.GetKeyDown(KeyCode.E) или использовать Input System
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
        }
    }

    private void TriggerDialogue()
    {
        // Проверяем, не запущен ли уже какой-то диалог
        if (DialogueManager.Instance != null && !DialogueManager.Instance.IsActive())
        {
            DialogueManager.Instance.StartDialogue(dialogueData);

            if (triggerOnce)
            {
                alreadyTriggered = true;
                if (visualHint != null) visualHint.SetActive(false);
                // Можно уничтожить объект или отключить коллайдер
                // Destroy(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            if (visualHint != null)
                visualHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            if (visualHint != null)
                visualHint.SetActive(false);
        }
    }
}