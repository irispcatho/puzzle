using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    public GameObject[] PrefabGround;
    public GameObject Player;
    public int Size = 10;
    public float Distance = 1;
    int[,] map;
    Vector2Int coordPlayer;

    IEnumerator Start()
    {
        map = new int[Size, Size];
        map[5, 3] = 2;

        coordPlayer = new Vector2Int(1, 1);

        Player.transform.position = new Vector2((coordPlayer.x - Size / 2) * Distance, (coordPlayer.y - Size / 2) * Distance);
        //mapPlayer[5,5] = 

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                if (x == 0 || x == Size - 1 || y == 0 || y == Size - 1)
                    map[x, y] = 1;
            }
        }


        Vector3 offset = new Vector3((Size * Distance) / 2, (Size * Distance) / 2);

        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                if (map[x, y] == 2)
                {
                    GameObject goGround = GameObject.Instantiate(PrefabGround[0]);
                    goGround.transform.position = new Vector3(x * Distance, y * Distance) - offset;

                }
                GameObject go = GameObject.Instantiate(PrefabGround[map[x, y]]);
                go.transform.position = new Vector3(x * Distance, y * Distance) - offset;
                go.transform.localScale = Vector3.zero;
                go.transform.DOScale(1, .16f);
                yield return new WaitForSeconds(.01f);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (map[coordPlayer.x, coordPlayer.y + 1] == 1)
            {
                print("mur de vent");
            }
            else if (map[coordPlayer.x, coordPlayer.y + 1] == 2)
            {

            }
            else
            {
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + Distance);
                coordPlayer.y++;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (map[coordPlayer.x, coordPlayer.y - 1] == 1)
            {
                print("mur derrière");
            }
            else
            {
                Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - Distance);
                coordPlayer.y--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (map[coordPlayer.x - 1, coordPlayer.y] == 1)
            {
                print("mur a gauche");
            }
            else
            {
                Player.transform.position = new Vector2(Player.transform.position.x - Distance, Player.transform.position.y);
                coordPlayer.x--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (map[coordPlayer.x + 1, coordPlayer.y] == 1)
            {
                print("mur a droite");
            }
            else
            {
                Player.transform.position = new Vector2(Player.transform.position.x + Distance, Player.transform.position.y);
                coordPlayer.x++;
            }
        }
    }
}
