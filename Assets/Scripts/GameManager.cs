using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject notePrefab; // Префаб записки
    [SerializeField] private int numberOfNotes = 8;
    [SerializeField] private GameObject[] pickups = new GameObject[2];
    [SerializeField] private PlayerController player;
    public TextMeshProUGUI noteText, livesText;
    public int lives, noteNum;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        if (player == null)
        {
            Debug.LogError("PlayerController не найден!");
            return;
        }

        PlaceNotesOnTrees();
        InvokeRepeating("SpawnPickup", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckLives();
    }

    public void GameOver()
    {
        CancelInvoke();
        noteNum = 0;
        lives = 1;
        SceneManager.LoadScene("Lose");
    }

    public void GameWon()
    {
        CancelInvoke();
        noteNum = 0;
        lives = 1;
        SceneManager.LoadScene("Win");
    }

    public void CheckLives()
    {
        livesText.SetText("Lives: " + lives);
        noteText.SetText("Collected notes: " + noteNum);
        if (lives <= 0)
        {
            GameOver();
        }
        else if (noteNum >= numberOfNotes)
        {
            GameWon();
        }
    }

    private void SpawnPickup()
    {
        GameObject randomPickup = pickups[Random.Range(0, 2)];
        Vector3 randomPos;

        randomPos = new Vector3(player.transform.position.x - Random.Range(10f, 20f), 2f, player.transform.position.z + Random.Range(0f, 20f));

        if (Random.Range(0f, 5f) >= 4f)
        {
            Instantiate(randomPickup, randomPos,
                Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }


    void PlaceNotesOnTrees()
    {
        Terrain terrain = Terrain.activeTerrain;
        TreeInstance[] trees = terrain.terrainData.treeInstances;

        for (int i = 0; i < numberOfNotes; i++)
        {
            // Выберите случайное дерево
            int randomTreeIndex = Random.Range(0, trees.Length);
            TreeInstance randomTree = trees[randomTreeIndex];

            // Преобразуйте относительные координаты в абсолютные мировые координаты
            Vector3 notePosition = new Vector3(
                randomTree.position.x * terrain.terrainData.size.x + terrain.transform.position.x + 1,
                0.5f,
                randomTree.position.z * terrain.terrainData.size.z + terrain.transform.position.z
            );

            Instantiate(notePrefab, notePosition, Quaternion.identity);
        }
    }
}
