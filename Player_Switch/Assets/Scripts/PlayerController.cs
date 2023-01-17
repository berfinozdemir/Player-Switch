using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //private PlayerType defaultPlayerType = PlayerType.Stickman;
    public PlayerType currentPlayer;
    public List<Player> players;
    public Action OnPlayerChange;
    public Transform Stickman;
    public Transform Aircraft;
    private void Start()
    {
        if (currentPlayer == PlayerType.Stickman) UIManager.Instance.PanelEnabled(false);
    }
    public void SwitchPlayer(PlayerType playerType)
    {
        currentPlayer = playerType;
        foreach (var item in players)
        {
            var player = item.GetComponent<Player>();
            if (item.playerData.playerType == currentPlayer)
            {
                player.ActivateMovement();
                
            }
            else
                player.DeactivateMovement();

            if (playerType != PlayerType.Stickman)
            {
                Stickman.gameObject.SetActive(false);
                UIManager.Instance.PanelEnabled(true);
            }
            else UIManager.Instance.PanelEnabled(false);
        }
        OnPlayerChange?.Invoke();
    }

    public void OnGetOut()
    {
        SwitchPlayer(PlayerType.Stickman);
        Stickman.gameObject.SetActive(true);
        UIManager.Instance.PanelEnabled(false);
        
    }
    
}
