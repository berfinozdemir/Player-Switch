using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region  Singleton
    public static UIManager Instance;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    #endregion
    public GameObject CarPanel; 
    public GameObject AircraftPanel;
    public GameObject YachtPanel;
    public void PanelEnabled(PlayerType playerType, bool isActive)
    {
        if (playerType == PlayerType.Car)
            CarPanel.SetActive(isActive);
        else if (playerType == PlayerType.Aircraft)
            AircraftPanel.SetActive(isActive);
        else if (playerType == PlayerType.Yacht)
            YachtPanel.SetActive(isActive);
    }
    public void PanelEnabled(bool isActive)
    {
        CarPanel.SetActive(isActive);
        AircraftPanel.SetActive(isActive);
        YachtPanel.SetActive(isActive);
    }
}
