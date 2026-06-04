using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchScript : MonoBehaviour
{
    #region Declaring variables
    [SerializeField]
    private int delayMax = 2;

    [SerializeField]
    private float delay;

    [SerializeField]
    private Button searchButton;

    [SerializeField]
    private GameObject Particles;

    public TextMeshProUGUI lootText;

    [Header("Threshhold")]
    public int trash = 8;
    public int treasure = 18;

    private int loot;

    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button searchButton = GetComponent<Button>();

        Particles = GameObject.Find("ParticleHolder");

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
            VictoryEnd();
        }
        else if (loot < trash)
        {
            lootText.color = Color.gray;
            lootText.text = "You Found Unusable Trash...";
            VictoryEnd();
        }
        else
        {
            Victory();
        }
    }

    void Victory()
    {
        lootText.color = Color.yellow;
        lootText.text = "You Found Treasure!";
        Particles.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Particles.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    void VictoryEnd()
    {
        Particles.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Particles.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
