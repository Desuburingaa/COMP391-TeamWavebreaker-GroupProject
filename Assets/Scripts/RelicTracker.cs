using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RelicTracker : MonoBehaviour
{
    [SerializeField] GameObject relic1UI;
    [SerializeField] GameObject relic2UI;
    [SerializeField] GameObject relic3UI;
    [SerializeField] GameObject relic4UI;
    [SerializeField] GameObject relic5UI;
    [SerializeField] TextMeshProUGUI playerHealthDisplay;

    [SerializeField] GameObject instructions;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;

    [SerializeField] GameObject player;

    Health playerH;

    bool gameStarted = false;
    bool hasRelic1 = false;
    bool hasRelic2 = false;
    bool hasRelic3 = false;
    bool hasRelic4 = false;
    bool hasRelic5 = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
        playerH = player.GetComponent<Health>();
        Invoke("StartGame", 5f);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }


    public void UpdateRelic1()
    {
        hasRelic1 = true;
        UpdateDisplay();
    }
    public void UpdateRelic2()
    {
        hasRelic2 = true;
        UpdateDisplay();
    }
    public void UpdateRelic3()
    {
        hasRelic3 = true;
        UpdateDisplay();
    }
    public void UpdateRelic4()
    {
        hasRelic4 = true;
        UpdateDisplay();
    }
    public void UpdateRelic5()
    {
        hasRelic5 = true;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (hasRelic1 == true)
        {
            relic1UI.SetActive(true);
        }
        if (hasRelic2 == true)
        {
            relic2UI.SetActive(true);
        }
        if (hasRelic3 == true)
        {
            relic3UI.SetActive(true);
        }
        if (hasRelic4 == true)
        {
            relic4UI.SetActive(true);
        }
        if (hasRelic5 == true)
        {
            relic5UI.SetActive(true);
        }
    }

    public bool EndingCheck()
    {
        bool goodEnding = false;
        if(hasRelic1 && hasRelic2 && hasRelic3 && hasRelic4 && hasRelic5 == true)
        {
            goodEnding = true;
        }
        return goodEnding;
    }


    public void PlayerWin()
    {
        winText.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayerLose()
    {
        loseText.SetActive(true);
        Time.timeScale = 0;
    }

    private void UpdateHealth()
    {
        playerHealthDisplay.text = playerH.GetHealth().ToString();

    }


    private void StartGame()
    {
        gameStarted = true;
        instructions.SetActive(false);
    }

}
