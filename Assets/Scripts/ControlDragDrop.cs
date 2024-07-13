using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDragDrop : MonoBehaviour
{
    public GameObject[] DraggableItem;
    public GameObject[] itemSlot;

    public bool[] itemStatus; // menyimpan status draggable item

    public int minDistance;
    public bool gameIsPaused;
    public GameObject ReadytoPrintNotif;

    public Vector2[] itemInitPos; // menyimpan daftar posisi awal setiap draggable item

    private void Start()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemInitPos[i] = DraggableItem[i].transform.localPosition;
        }
        gameIsPaused = false;
        ReadytoPrintNotif.SetActive(false);
    }
    private void Update() 
    {
        CheckGameStatus();
    }
    public void ItemDrag(int index)
    {
        if (gameIsPaused == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                DraggableItem[index].transform.position = touch.position;
            }
            // DraggableItem[index].transform.position = Input.mousePosition;
        }
    }
    public void ItemEndDrag(int index)
    {
        float currentDistance = Vector3.Distance(DraggableItem[index].transform.localPosition, itemSlot[index].transform.localPosition);
        if (currentDistance < minDistance)
        {
            DraggableItem[index].transform.localPosition = itemSlot[index].transform.localPosition;
            itemStatus[index] = true;
        }
        else
        {
            DraggableItem[index].transform.localPosition = itemInitPos[index];
        }
    }
    private void CheckGameStatus()
    {
        bool allItemsCompleted = true;

        for (int i = 0; i < itemStatus.Length; i++)
        {
            if (!itemStatus[i])
            {
                allItemsCompleted = false;
                break;
            }
        }

        if (allItemsCompleted)
        {
            Debug.Log("Game is completed!");
            Time.timeScale = 0f;
            gameIsPaused = true;
            ReadytoPrintNotif.SetActive(true);
        }
        else
        {
            Debug.Log("Player can still drag the item.");
        }
    }
}
