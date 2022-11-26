using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    enum ActiveCharacter
    {
        player,
        npc
    }

    [System.Serializable]
    struct Dialogue
    {
        public ActiveCharacter characterTalking;
        public string text;
    }

    int numberOfFirstLines;
    int numberOfRepeatedLines;
    int currentBubble;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerBubble;
    PlayerMovement pm;
    [SerializeField] GameObject characterBubble;
    [SerializeField] TextMesh playerText;
    [SerializeField] TextMesh characterText;
    [SerializeField] Dialogue[] firstDialogue;
    [SerializeField] Dialogue[] repeatedDialogue;
    bool isStart;
    bool isTalking;
    bool isFirst;
    // Start is called before the first frame update
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        isStart = false;
        isTalking = false;
        isFirst = true;
        numberOfFirstLines = firstDialogue.Length;
        numberOfRepeatedLines = repeatedDialogue.Length;
        currentBubble = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            if (isFirst)
            {
                if (firstDialogue[currentBubble].characterTalking == ActiveCharacter.npc)
                {
                    characterBubble.SetActive(true);
                    playerBubble.SetActive(false);
                    characterText.text = firstDialogue[currentBubble].text;
                }
                else if (firstDialogue[currentBubble].characterTalking == ActiveCharacter.player)
                {
                    characterBubble.SetActive(false);
                    playerBubble.SetActive(true);
                    playerText.text = firstDialogue[currentBubble].text;
                }
            }
            else
            {
                if (repeatedDialogue[currentBubble].characterTalking == ActiveCharacter.npc)
                {
                    characterBubble.SetActive(true);
                    playerBubble.SetActive(false);
                    characterText.text = repeatedDialogue[currentBubble].text;
                }
                else if (repeatedDialogue[currentBubble].characterTalking == ActiveCharacter.player)
                {
                    characterBubble.SetActive(false);
                    playerBubble.SetActive(true);
                    playerText.text = repeatedDialogue[currentBubble].text;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                currentBubble++;
                if (isFirst)
                {
                    if(currentBubble == numberOfFirstLines)
                    {
                        isStart = false;
                        currentBubble = 0;
                        characterBubble.SetActive(false);
                        playerBubble.SetActive(false);
                        isStart = false;
                        isTalking = false;
                        isFirst = false;
                        pm.setIsTalking(false);
                    }
                }
                else
                {
                    if (currentBubble == numberOfRepeatedLines)
                    {
                        isStart = false;
                        currentBubble = 0;
                        characterBubble.SetActive(false);
                        playerBubble.SetActive(false);
                        isStart = false;
                        isTalking = false;
                        isFirst = false;
                        pm.setIsTalking(false);
                    }
                }
            }
        }
    }

    private void OnMouseDown()
    {
        isTalking = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTalking)
        {
            isStart = true;
            pm.setIsTalking(true);
        }
    }
}
