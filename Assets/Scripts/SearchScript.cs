using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchScript : MonoBehaviour
{
    [SerializeField]
    private int delayMax = 2;

    [SerializeField]
    private float delay;

    [SerializeField]
    private Button searchButton;

    public TextMeshProUGUI lootText;

    [Header("Threshhold")]
    public int trash = 8;
    public int treasure = 18;

    private int loot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button searchButton = GetComponent<Button>();

        // unity documentation has this in start
        searchButton.onClick.AddListener(SearchFunction);
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
    }

    void SearchFunction()
    {
        if (delay > 0)
        {
            return;
        }
        else
        {
            loot = Random.Range(1, 21);
            LootFound();
            Debug.Log("you found a " + loot);
            delay = delayMax;
        }
    }

    void LootFound()
    {
        if (loot > trash && loot <= treasure)
        {
            lootText.color = Color.white;
            lootText.text = "You Found a Useful Item";
        }
        else if (loot < trash)
        {
            lootText.color = Color.gray;
            lootText.text = "You Found Unusable Trash...";
        }
        else
        {
            lootText.color = Color.yellow;
            lootText.text = "You Found Treasure!";
        }
    }
}
