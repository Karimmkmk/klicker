using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; // Если TextMeshPro не используется, замените на using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // --- Синглтон для доступа из любого места ---
    public static DialogueManager Instance { get; private set; }

    [Header("UI Элементы")]
    [SerializeField] private GameObject dialoguePanel; // Панель (фон) всего диалога
    [SerializeField] private Image speakerImage;       // Изображение говорящего
    [SerializeField] private TextMeshProUGUI speakerNameText; // Имя (или Text)
    [SerializeField] private TextMeshProUGUI dialogueText;    // Текст реплики (или Text)
    [SerializeField] private Button nextButton;         // Кнопка "Далее"

    [Header("Настройки")]
    [SerializeField] private float textSpeed = 0.05f;   // Скорость печати символов

    // Текущий диалог и строка
    private DialogueData currentDialogue;
    private int currentLineIndex;
    private bool isDialogueActive;
    private Coroutine typingCoroutine; // Чтобы остановить печать

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Скрываем панель при старте
        dialoguePanel.SetActive(false);
        nextButton.onClick.AddListener(NextLine);
    }

    /// <summary>
    /// Запускает диалог. Вызывайте извне, например: DialogueManager.Instance.StartDialogue(myDialogue);
    /// </summary>
    public void StartDialogue(DialogueData dialogue)
    {
        if (dialogue == null || dialogue.dialogueLines.Length == 0)
        {
            Debug.LogWarning("Диалог пуст или не назначен!");
            return;
        }

        currentDialogue = dialogue;
        currentLineIndex = 0;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);

        // Можно заблокировать управление игроком
        // PlayerController.Instance.CanMove = false;

        ShowLine();
    }

    /// <summary>
    /// Показывает текущую реплику, печатая текст.
    /// </summary>
    private void ShowLine()
    {
        if (!isDialogueActive) return;

        DialogueData.DialogueLine line = currentDialogue.dialogueLines[currentLineIndex];

        // Устанавливаем данные
        speakerNameText.text = line.speakerName;

        if (line.speakerSprite != null)
        {
            speakerImage.sprite = line.speakerSprite;
            speakerImage.enabled = true;
        }
        else
        {
            speakerImage.enabled = false; // Прячем, если спрайта нет
        }

        // Останавливаем предыдущую печать, если была
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeText(line.text));
    }

    /// <summary>
    /// Корутина для эффекта печатающей машинки.
    /// </summary>
    private IEnumerator TypeText(string fullText)
    {
        dialogueText.text = ""; // Очищаем поле
        foreach (char c in fullText)
        {
            dialogueText.text += c;
            // Звук печати можно вставить здесь
            yield return new WaitForSeconds(textSpeed);
        }
        typingCoroutine = null;
    }

    /// <summary>
    /// Переход к следующей реплике или завершение диалога.
    /// </summary>
    public void NextLine()
    {
        if (!isDialogueActive) return;

        // Если текст ещё печатается, показываем всю строку сразу при нажатии
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = currentDialogue.dialogueLines[currentLineIndex].text;
            typingCoroutine = null;
            return;
        }

        currentLineIndex++;

        if (currentLineIndex < currentDialogue.dialogueLines.Length)
        {
            ShowLine(); // Показываем следующую реплику
        }
        else
        {
            EndDialogue(); // Диалог закончен
        }
    }

    /// <summary>/// Завершает диалог и скрывает панель.
    /// </summary>
    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        currentDialogue = null;

        // Разблокировать управление игроком
        // PlayerController.Instance.CanMove = true;
        Debug.Log("Диалог завершён.");
    }

    /// <summary>
    /// Удобный метод для проверки, активен ли диалог (например, чтобы блокировать прыжки).
    /// </summary>
    public bool IsActive()
    {
        return isDialogueActive;
    }
}
