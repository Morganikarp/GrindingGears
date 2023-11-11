using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform P1spawnPoint;
    public Transform P2spawnPoint;
    
    
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject P1prefab = characterPrefabs[selectedCharacter];
        GameObject P1clone = Instantiate(P1prefab, P1spawnPoint.position, Quaternion.identity);
        P1clone.gameObject.tag = "P1";

        int P2selectedCharacter = PlayerPrefs.GetInt("P2selectedCharacter");
        GameObject P2prefab = characterPrefabs[P2selectedCharacter];
        GameObject P2clone = Instantiate(P2prefab, P2spawnPoint.position, Quaternion.identity);
        P2clone.gameObject.tag = "P2";
    }

}
