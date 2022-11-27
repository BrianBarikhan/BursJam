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
        [TextArea] public string text;
    }
    [System.Serializable]
    struct Dialogues
    {
        public Dialogue[] firstDialogue;
        public Dialogue[] repeatedDialogue;
        public string[] requiredItem;
        public GameObject rewardItem;
    }

    int numberOfFirstLines;
    int numberOfRepeatedLines;
    int currentBubble;
    [SerializeField] GameObject InventorySystem;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerBubble;
    PlayerMovement pm;
    [SerializeField] GameObject characterBubble;
    [SerializeField] TextMesh playerText;
    [SerializeField] TextMesh characterText;
    [SerializeField] Dialogues[] dialogues;
    bool isStart;
    bool isTalking;
    bool isFirst;
    int dialogueNum;
    GameObject givenItem;
    BaseItemScript bis;
    // Start is called before the first frame update
    void Start()
    {
        dialogueNum = 0;
        pm = player.GetComponent<PlayerMovement>();
        isStart = false;
        isTalking = false;
        isFirst = true;
        currentBubble = 0;
    }

    // Update is called once per frame
    void Update()
    {
        numberOfFirstLines = dialogues[dialogueNum].firstDialogue.Length;
        numberOfRepeatedLines = dialogues[dialogueNum].repeatedDialogue.Length;
        if (isStart)
        {
            if (isFirst)
            {
                if (dialogues[dialogueNum].firstDialogue[currentBubble].characterTalking == ActiveCharacter.npc)
                {
                    characterBubble.SetActive(true);
                    playerBubble.SetActive(false);
                    characterText.text = dialogues[dialogueNum].firstDialogue[currentBubble].text;
                }
                else if (dialogues[dialogueNum].firstDialogue[currentBubble].characterTalking == ActiveCharacter.player)
                {
                    characterBubble.SetActive(false);
                    playerBubble.SetActive(true);
                    playerText.text = dialogues[dialogueNum].firstDialogue[currentBubble].text;
                }
            }
            else
            {
                if (dialogues[dialogueNum].repeatedDialogue[currentBubble].characterTalking == ActiveCharacter.npc)
                {
                    characterBubble.SetActive(true);
                    playerBubble.SetActive(false);
                    characterText.text = dialogues[dialogueNum].repeatedDialogue[currentBubble].text;
                }
                else if (dialogues[dialogueNum].repeatedDialogue[currentBubble].characterTalking == ActiveCharacter.player)
                {
                    characterBubble.SetActive(false);
                    playerBubble.SetActive(true);
                    playerText.text = dialogues[dialogueNum].repeatedDialogue[currentBubble].text;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                currentBubble++;
                if (isFirst)
                {
                    if(currentBubble == numberOfFirstLines)
                    {
                        if (dialogues[dialogueNum].rewardItem != null)
                        {
                            InventoryManager im = InventorySystem.GetComponent<InventoryManager>();
                            Transform parent = im.AddItem(dialogues[dialogueNum].rewardItem);
                            Instantiate(dialogues[dialogueNum].rewardItem, parent);
                        }
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
        if (isTalking && collision.transform.tag == "Player")
        {
            isStart = true;
            pm.setIsTalking(true);
        }
        else if(collision.gameObject.tag == "Item")
        {
            givenItem = collision.gameObject;
            bis = givenItem.GetComponent<BaseItemScript>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("Collided");
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Drop");
                for(int i = 0; i < dialogues[dialogueNum].requiredItem.Length; i++) {
                    if (bis.GetName() == dialogues[dialogueNum].requiredItem[i])
                    {
                        dialogueNum++;
                        isFirst = true;
                        Destroy(givenItem);
                        pm.setCanMove(true);
                        return;
                    }
                }
                givenItem = null;
                bis = null;
            }
        }
    }
}
