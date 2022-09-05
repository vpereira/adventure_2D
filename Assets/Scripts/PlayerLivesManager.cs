using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLivesManager : MonoBehaviour
{

    [SerializeField] private Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesUI();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLivesUI()
    {
        livesText.text = GetLivesString();
    }
    public string GetLivesString()
    {
        return $"Lives: {playerLives()}";
    }

    int playerLives()
    {
        return PlayerManager.Instance.Player.GetComponent<PlayerLife>().NumOfLives;
    }


}
