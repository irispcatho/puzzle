using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    public GameObject[] DetectionObjs, DetectionFence;
    public GameObject Player, AssetPlayer;
    public Transform Map, MapGlobal, SpawnPlayer;
    public int Size;
    public float Distance = 1;
    Vector3Int coordPlayer;
    public int rotate = 0;
    int rotaY;
    private bool hasMoved;
    private bool canMove = true;
    public float SpeedMovement = 0.5f;
    const float timeToRotaPlayer = 0.4f;



    public static MainGame Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité)
        Instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(.01f);
        Player.transform.position = SpawnPlayer.position;
        #region
        /*for (int x = 0; x < Size; x++)
        {
            for (int z = 0; z < Size; z++)
            {
                if (x == 0 || x == Size - 1 || z == 0 || z == Size - 1)
                {
                    map[x, z] = 0;
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
        }*/
        #endregion
    }

    private void Update()
    {
        //print(coordPlayer.z);
        if (Input.GetKeyDown(KeyCode.Z))
            MoveTop();
        if (Input.GetKeyDown(KeyCode.S))
            MoveBot();
        if (Input.GetKeyDown(KeyCode.Q))
            MoveLeft();
        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();

        if (Input.GetKeyDown(KeyCode.L)) // PRINT LES COORDS
        {
            print(coordPlayer.z + " z");
            print(coordPlayer.x + " x");
        }

        if (Input.GetKeyDown(KeyCode.R)) // ROTATION
           RotateMap();

        if (Player.GetComponent<PlayerMovement>().isOnBumperCar == true)
        {
            if (DetectionObjs[3].GetComponent<DetectionGround>().isTouchingGround == true)
            {
                hasMoved = false;
                Player.GetComponent<PlayerMovement>().isOnBumperCar = false;
                StartCoroutine(BumperRight());
            }
            else
            {
                Player.GetComponent<PlayerMovement>().isOnBumperCar = false;
            }
        }
    }

    public void RotateMap()
    {
        StartCoroutine(waitToRotateMap());
    }

    IEnumerator waitToRotateMap()
    {
        yield return new WaitForSeconds(.5f);
        rotate++;
        if (rotate >= 4)
            rotate = 0;
        rotaY += 90;
        MapGlobal.transform.DORotate(new Vector3(0, rotaY, 0), 1f);
        DetectionObjs[4].transform.Rotate(0, -90, 0, Space.Self);
        DetectionFence[4].transform.Rotate(0, -90, 0, Space.Self);
    }

    public void MoveLeft()
    {
        if (DetectionObjs[2].GetComponent<DetectionGround>().isTouchingGround == false || DetectionFence[2].GetComponent<DetectionFence>().isTouchingFence == true)
            print("mur a gauche");
        else
        {
            if(canMove)
            {
                AssetPlayer.transform.DORotate(new Vector3(0, 90, 0), timeToRotaPlayer);
                canMove = false;
                //Player.transform.position = new Vector3(Player.transform.position.x - Distance, 0, Player.transform.position.z);
                Player.transform.DOMove(new Vector3(Player.transform.position.x - Distance, 0, Player.transform.position.z), SpeedMovement, false).OnComplete(CanMove);
                coordPlayer.x--;
            }
        }
        if (DetectionObjs[2].GetComponent<DetectionGround>().isTouchingFerrisWheel == true)
            RotateMap();
    }
    public void MoveRight()
    {
        if (DetectionObjs[3].GetComponent<DetectionGround>().isTouchingGround == false || DetectionFence[3].GetComponent<DetectionFence>().isTouchingFence == true)
            print("mur a droite");
        else
        {
            if (canMove)
            {
                AssetPlayer.transform.DORotate(new Vector3(0, -90, 0), timeToRotaPlayer);
                canMove = false;
                //Player.transform.position = new Vector3(Player.transform.position.x + Distance, 0, Player.transform.position.z);
                Player.transform.DOMove(new Vector3(Player.transform.position.x + Distance, 0, Player.transform.position.z), SpeedMovement, false).OnComplete(CanMove);
                coordPlayer.x++;
            }
        }

        if (DetectionObjs[3].GetComponent<DetectionGround>().isTouchingFerrisWheel == true)
            RotateMap();
    }
    public void MoveTop()
    {
        if (DetectionObjs[0].GetComponent<DetectionGround>().isTouchingGround == false || DetectionFence[0].GetComponent<DetectionFence>().isTouchingFence == true)
            print("mur de vent");
        else
        {
            if (canMove)
            {
                AssetPlayer.transform.DORotate(new Vector3(0, 180, 0), timeToRotaPlayer);
                canMove = false;
                //Player.transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z + Distance);
                Player.transform.DOMove(new Vector3(Player.transform.position.x, 0, Player.transform.position.z + Distance), SpeedMovement, false).OnComplete(CanMove);
                coordPlayer.z++;
            }
        }
        if (DetectionObjs[0].GetComponent<DetectionGround>().isTouchingFerrisWheel == true)
            RotateMap();
    }
    public void MoveBot()
    {
        if (DetectionObjs[1].GetComponent<DetectionGround>().isTouchingGround == false || DetectionFence[1].GetComponent<DetectionFence>().isTouchingFence == true)
            print("mur derrière");
        else
        {
            if (canMove)
            {
                AssetPlayer.transform.DORotate(new Vector3(0, 0, 0), timeToRotaPlayer);
                canMove = false;
                //Player.transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z - Distance);
                Player.transform.DOMove(new Vector3(Player.transform.position.x, 0, Player.transform.position.z - Distance), SpeedMovement, false).OnComplete(CanMove);
                coordPlayer.z--;
            }
        }
        if (DetectionObjs[1].GetComponent<DetectionGround>().isTouchingFerrisWheel == true)
            RotateMap();        
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

    IEnumerator BumperRight()
    {
        yield return new WaitForSeconds(0.5f);
        if(!hasMoved)
        {
            if (rotate == 0)
                MoveRight();
            else if (rotate == 1)
                MoveBot();
            else if (rotate == 2)
                MoveLeft();
            else if (rotate == 3)
                MoveTop();

            hasMoved = true;
        }
    }

    private void CanMove()
    {
        canMove = true;
    }
}
