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
    public GameObject GetOutPanel;
    public void PanelEnabled(bool isActive)
    {
        GetOutPanel.SetActive(isActive);
    }
}
