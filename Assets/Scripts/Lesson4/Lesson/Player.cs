using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class Player : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private GameObject playerCharacter;

    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        if (!isServer)
        {
            return;
        }
        playerCharacter = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(playerCharacter,
        connectionToClient);
    }
}