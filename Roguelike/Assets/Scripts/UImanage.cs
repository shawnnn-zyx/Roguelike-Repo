using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UImanage : MonoBehaviour
{
    public SubmitName SubmitName;

    public TextMeshProUGUI titleText;
    public TMP_InputField inputField;
    public Button Button_A;
    public Button Button_B;
    public Button Button_C;
    public Button Button_D;
    public Button submitButton;
    public Button Button_FinishAttribute;

    private int currentQuestionIndex = 0;
    private List<string> answers = new List<string>();

    private int STR = 6;
    private int DEX = 6;
    private int INT = 6;
    private int CHR = 6;
    private int LCK = 6;

    private string[] questions = {
        "Welcome <player>, there's a festival in town. Which activity interests you the most?",
        "Just outside the village, you're suddenly surrounded by enemies. What's your first reaction?",
        "At the festival banquet, you don't know anyone. What do you do?",
        "The lord calls for brave adventurers to explore a dungeon. What type of adventure would you choose?",
        "Before heading to the dungeon, how would you ask the lord for support?",
        "Before setting out on your dungeon adventure, what would be your personal state?",
        "In the dungeon ruins, you find a mysterious book. What do you do?",
        "Facing the dungeon boss, it proposes to decide the outcome with a coin toss. You:",
        "When you reach the end of the dungeon, there's a tightly closed door. What do you do?",
        "After opening the door, you find crystals that grant special abilities. Which ability would you choose?"
    };

    private string[,] options = {
        { "A. Weightlifting or wrestling", "B. Parkour or gymnastics", "C. Chess or math competition", "D. Public speaking or debate" },
        { "A. Carefully observe the enemy's movements, waiting for the best counter-attack opportunity.", "B. Why are you standing there? Run!", "C. Cast a spell to resolve the situation.", "D. Burst into tears, explaining you have elderly parents to care for, begging to be spared." },
        { "A. Actively engage in conversations, building connections.", "B. Quietly observe, waiting for the right moment to act.", "C. Find a corner to drink or eat, not really interested in socializing.", "D. Challenge someone to an arm-wrestling match at the dinner table." },
        { "A. A trial of reflexes and agility, dodging enemy attacks and seeking battle opportunities!", "B. Carefully plan each step, using tactics and strategy to conquer the dungeon with minimal losses!", "C. Challenge strong foes, crush all obstacles with brute force, demonstrating unparalleled strength!", "D. Use your silver tongue to persuade monsters, possibly even turning them into your allies!" },
        { "A. Use sweet talk to make the lord feel you're reliable.", "B. Logically explain the feasibility of your plan.", "C. Demonstrate your combat skills to show you can solve problems.", "D. By chance, the lord is in a good mood and provides small support to all adventurers." },
        { "A. Randomly challenge unknown territories, let fate decide everything!", "B. Be fully prepared before embarking on the adventure.", "C. Find reliable companions to face challenges together.", "D. Train your body to ensure you can overcome all difficulties." },
        { "A. Try to understand the contents of the book.", "B. Curiously flip through the pages to see what happens.", "C. The book is thick, might as well use it as a weapon against monsters.", "D. Gently touch the surface of the book, testing if it triggers any traps or curses." },
        { "A. Confidently accept the challenge, because you always guess correctly! Luck is on your side.", "B. Keep your eyes fixed on the coin's trajectory, predicting the landing spot with your dynamic vision!", "C. Calmly analyze the tossing angle and rotation speed, trying to increase your chances of winning.", "D. Draw your sword without hesitation: \"I won't play such games with you, let's settle this with real strength!" },
        { "A. Force it open with brute strength.", "B. Luckily find a key stuck in the door crack.", "C. Climb over the wall or find another entrance.", "D. Knock and politely request entry." },
        { "A. Exceptional luck, greatly increasing your chances of windfall.", "B. Lightning-fast reactions, easily dodging attacks.", "C. Powerful magic, able to control elements or mental powers.", "D. Charm power, making anyone like you." }
    };

    private List<string[]> attributeMapping = new List<string[]>
    {
        new string[] { "STR", "DEX", "INT", "CHR" },
        new string[] { "LCK", "DEX", "INT", "CHR" },
        new string[] { "CHR", "INT", "LCK", "STR" },
        new string[] { "DEX", "INT", "STR", "CHR" },
        new string[] { "CHR", "INT", "STR", "LCK" },
        new string[] { "LCK", "INT", "CHR", "STR" },
        new string[] { "INT", "LCK", "STR", "DEX" },
        new string[] { "LCK", "DEX", "INT", "STR" },
        new string[] { "STR", "LCK", "DEX", "CHR" },
        new string[] { "LCK", "DEX", "INT", "CHR" }
    };

    public void Start()
    {
        Button_A.gameObject.SetActive(false);
        Button_B.gameObject.SetActive(false);
        Button_C.gameObject.SetActive(false);
        Button_D.gameObject.SetActive(false);
        Button_FinishAttribute.gameObject.SetActive(false);

        Button_A.onClick.AddListener(() => SelectAnswer(0));
        Button_B.onClick.AddListener(() => SelectAnswer(1));
        Button_C.onClick.AddListener(() => SelectAnswer(2));
        Button_D.onClick.AddListener(() => SelectAnswer(3));
    }

    public void Question()
    {
        string welcomeText = questions[currentQuestionIndex].Replace("<player>", SubmitName.playerName);
        titleText.text = welcomeText;

        Button_A.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 0];
        Button_B.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 1];
        Button_C.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 2];
        Button_D.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 3];

        Button_A.gameObject.SetActive(true);
        Button_B.gameObject.SetActive(true);
        Button_C.gameObject.SetActive(true);
        Button_D.gameObject.SetActive(true);
        inputField.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
    }

    private void SelectAnswer(int choiceIndex)
    {
        // to save player answerrr
        //answers.Add(options[currentQuestionIndex, choiceIndex]);

        // to the next question
        currentQuestionIndex++;
        // reset current button
        EventSystem.current.SetSelectedGameObject(null);

        if (currentQuestionIndex < questions.Length)
        {
            // 更新問題和選項
            titleText.text = questions[currentQuestionIndex];
            Button_A.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 0];
            Button_B.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 1];
            Button_C.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 2];
            Button_D.GetComponentInChildren<TextMeshProUGUI>().text = options[currentQuestionIndex, 3];
        }
        else
        {
            // 顯示總結
            ShowSummary();
        }

        if (currentQuestionIndex < attributeMapping.Count)
        {
            string selectedAttribute = attributeMapping[currentQuestionIndex][choiceIndex];

            switch (selectedAttribute)
            {
                case "STR": STR += 1; break;
                case "DEX": DEX += 1; break;
                case "INT": INT += 1; break;
                case "CHR": CHR += 1; break;
                case "LCK": LCK += 1; break;
            }
        }
    }

    private void ShowSummary()
    {
        titleText.text =
        $"\n"
        + $"{SubmitName.playerName} the Adventurer, you will embark on your journey with the following attributes:\n"
        + $"\n"
        + $"STR: {STR}\n"
        + $"DEX: {DEX}\n"
        + $"INT: {INT}\n"
        + $"CHR: {CHR}\n"
        + $"LCK: {LCK}\n";

        Button_FinishAttribute.gameObject.SetActive(true);
        Button_A.gameObject.SetActive(false);
        Button_B.gameObject.SetActive(false);
        Button_C.gameObject.SetActive(false);
        Button_D.gameObject.SetActive(false);
    }
}
