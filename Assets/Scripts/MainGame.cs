using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    public GameObject[] PrefabGround, DetectionObjs;
    public GameObject Player;
    public Transform Map;
    public Transform MapGlobal;
    public int Size;
    public float Distance = 1;
    int[,] map;
    Vector3Int coordPlayer, initCoordPlayer;
    const float timeToMove = .1f;
    public int rotate = 0;
    private bool hadTurnOnce;



    public static MainGame Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité)
        Instance = this;
    }

    IEnumerator Start()
    {
        PrefabGround[0].GetComponent<IndexGround>().indexZ = 0;
        map = new int[Size, Size];
        map[5, 3] = 3;

        coordPlayer = new Vector3Int(1, 0, 1);

        Player.transform.position = new Vector3((coordPlayer.x - Size / 2) * Distance, 0, (coordPlayer.z - Size / 2) * Distance);
        //mapPlayer[5,5] = 

        for (int x = 0; x < Size; x++)
        {
            for (int z = 0; z < Size; z++)
            {
                if (x == 0 || x == Size - 1 || z == 0 || z == Size - 1)
                {
                    map[x, z] = 1;
                }
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
                //PrefabGround[0].GetComponent<IndexGround>().indexZ++;
                //ground.Add(go);
            }
        }
    }


    private void Update()
    {
        //print(coordPlayer.z);
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

        if (Input.GetKeyDown(KeyCode.L)) // ROTATION
        {
            print(coordPlayer.z + " z");
            print(coordPlayer.x + " x");
        }

        if (Input.GetKeyDown(KeyCode.R)) // ROTATION
        {
            rotate++;
            if (rotate == 4)
                rotate = 0;
            MapGlobal.Rotate(0, 90, 0, Space.Self);
            DetectionObjs[4].transform.Rotate(0, -90, 0, Space.Self);

            if (rotate == 0 && !hadTurnOnce)
            {
                coordPlayer.z = initCoordPlayer.z;
                coordPlayer.x = initCoordPlayer.x;
                print(coordPlayer.z);
                print(coordPlayer.x);
            }

            if (rotate == 0 && hadTurnOnce)
            {
                NewCoordRotation();
            }

            if (rotate > 0)
            {
                hadTurnOnce = true;
                if (hadTurnOnce)
                {
                    NewCoordRotation();
                }
            }
        }
    }

    void NewCoordRotation()
    {
        initCoordPlayer.z = coordPlayer.z;
        initCoordPlayer.x = coordPlayer.x;
        coordPlayer.z = Size - coordPlayer.x - 1;
        coordPlayer.x = Size - (Size - initCoordPlayer.z);

        //print(coordPlayer.z + " z");
        //print(coordPlayer.x + " x");
    }
    public void MoveLeft()
    {
        //if (map[coordPlayer.x - 1, coordPlayer.z] != 0)
        if (DetectionObjs[2].GetComponent<DetectionGround>().isTouchingGround == false)
            print("mur a gauche");
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x - Distance, 0, Player.transform.position.z);
            coordPlayer.x--;
        }
    }
    public void MoveRight()
    {
        //if (map[coordPlayer.x + 1, coordPlayer.z] != 0)
        if (DetectionObjs[3].GetComponent<DetectionGround>().isTouchingGround == false)
            print("mur a droite");
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x + Distance, 0, Player.transform.position.z);
            coordPlayer.x++;
        }
    }
    public void MoveTop()
    {
        //if (map[coordPlayer.x, coordPlayer.z + 1] != 0)
        if (DetectionObjs[0].GetComponent<DetectionGround>().isTouchingGround == false)
            print("mur de vent");
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z + Distance);
            coordPlayer.z++;
        }

    }
    public void MoveBot()
    {
        //if (map[coordPlayer.x, coordPlayer.z - 1] != 0)
        if (DetectionObjs[1].GetComponent<DetectionGround>().isTouchingGround == false)
            print("mur derrière");
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z - Distance);
            coordPlayer.z--;
        }
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
