using UnityEngine;
using System;

// Позволяет создавать файлы диалогов как ассеты через меню Unity
[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    [Serializable]
    public class DialogueLine
    {
        [Tooltip("Имя персонажа (оставьте пустым, если говорит игрок)")]
        public string speakerName;
        [TextArea(3, 10)] // Делает поле для текста побольше
        public string text;
        // Спрайт персонажа, который будет показан во время реплики
        public Sprite speakerSprite;
        // Можно добавить звук голоса или событие
        public AudioClip voiceClip;
    }

    public DialogueLine[] dialogueLines;
}
