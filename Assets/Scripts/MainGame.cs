using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    public GameObject[] PrefabGround;
    public GameObject Player;
    public Transform Map;
    public int Size;
    public float Distance = 1;
    int[,] map;
    Vector3Int coordPlayer;
    const float timeToMove = .1f;

    public static MainGame Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance pr�c�dente (s�curit�)
        Instance = this;
    }

    IEnumerator Start()
    {
        map = new int[Size, Size];
        //map[5, 3] = 2;

        coordPlayer = new Vector3Int(1, 0, 1);

        Player.transform.position = new Vector3((coordPlayer.x - Size / 2) * Distance, 0, (coordPlayer.z - Size / 2) * Distance);
        //mapPlayer[5,5] = 

        for (int x = 0; x < Size; x++)
        {
            for (int z = 0; z < Size; z++)
            {
                if (x == 0 || x == Size - 1 || z == 0 || z == Size - 1)
                    map[x, z] = 1;
            }
        }


        Vector3 offset = new Vector3((Size * Distance) / 2, 0, (Size * Distance) / 2);

        for (int z = 0; z < Size; z++)
        {
            for (int x = 0; x < Size; x++)
            {
                if (map[x, z] == 2)
                {
                    GameObject goGround = GameObject.Instantiate(PrefabGround[0]);
                    goGround.transform.position = new Vector3(x * Distance, -0.5f, z * Distance) - offset;

                }
                GameObject go = GameObject.Instantiate(PrefabGround[map[x, z]]);
                go.transform.parent = Map;
                go.transform.position = new Vector3(x * Distance, -0.5f, z * Distance) - offset;
                go.transform.localScale = Vector3.zero;
                go.transform.DOScale(2, .16f);
                yield return new WaitForSeconds(.01f);
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MoveTop();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveBot();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    public void MoveLeft()
    {
        if (map[coordPlayer.x - 1, coordPlayer.z] == 1)
        {
            print("mur a gauche");
        }
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x - Distance, 0, Player.transform.position.z);
            coordPlayer.x--;
        }
        //Vector3 pos = new Vector3(Player.transform.position.x - Distance, 0, Player.transform.position.z);
        //Player.transform.DOComplete();
        //Player.transform.DOMove(pos, timeToMove);
    }
    public void MoveRight()
    {
        if (map[coordPlayer.x + 1, coordPlayer.z] == 1)
        {
            print("mur a droite");
        }
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x + Distance, 0, Player.transform.position.z);
            coordPlayer.x++;
        }
        //Vector3 pos = new Vector3(Player.transform.position.x + Distance, 0, Player.transform.position.z);
        //Player.transform.DOComplete();
        //Player.transform.DOMove(pos, timeToMove);
    }
    public void MoveTop()
    {
        if (map[coordPlayer.x, coordPlayer.z + 1] == 1)
        {
            print("mur de vent");
        }
        else if (map[coordPlayer.x, coordPlayer.z + 1] == 2)
        {

        }
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z + Distance);
            coordPlayer.z++;
        }
        //Vector3 pos = new Vector3(Player.transform.position.x, 0, Player.transform.position.z + Distance);
        //Player.transform.DOKill();
        //Player.transform.DOMove(pos, timeToMove);
    }
    public void MoveBot()
    {
        if (map[coordPlayer.x, coordPlayer.z - 1] == 1)
        {
            print("mur derri�re");
        }
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z - Distance);
            coordPlayer.z--;
        }
        //Vector3 pos = new Vector3(Player.transform.position.x, 0, Player.transform.position.z - Distance);
        //Player.transform.DOKill();
        //Player.transform.DOMove(pos, timeToMove);
    }

    public void Move(int WhichSide)
    {
        if (WhichSide == 1)
            MoveTop();
        else if (WhichSide == 2)
            MoveBot();
        else if (WhichSide == 3)
            MoveLeft();
        else
            MoveRight();

    }
}
