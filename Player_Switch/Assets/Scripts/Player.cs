using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerData playerData;
    public bool isCurrentPlayer = false;
    public Rigidbody rb;
    private void Awake()
    {
        TryGetComponent<Rigidbody>(out rb);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerSwitchArea"))
        {
            //other.TryGetComponent<PlayerData>(out PlayerData playerData);
            //playerController.SwitchPlayer(playerData.playerType);
            var player = other.GetComponentInParent<Player>();
            playerController.SwitchPlayer(player.playerData.playerType);


        }
    }
    public void ActivateMovement()
    {
        isCurrentPlayer = true;
        rb.isKinematic = false;
    }
    public void DeactivateMovement()
    {
        isCurrentPlayer = false;
        if (!rb) Debug.Log(gameObject.name, gameObject);
        rb.isKinematic = true;
    }
}
