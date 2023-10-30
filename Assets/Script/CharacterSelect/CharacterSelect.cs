using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public GameObject P1Position;
    public GameObject P2Position;

    public GameObject LuffyPrefab;
    public GameObject AcePrefab;
    public GameObject ZoroPrefab;

    public Button LuffyButton;
    public Button AceButton;
    public Button ZoroButton;

    public int selectionIndex = 0;
    public void SelectAce()
    {
        if (selectionIndex > 1) return;
        GameObject ace = AcePrefab;
        HandleDirection(ace.transform);
        if (selectionIndex == 0)
        {
            ace.transform.position = P1Position.transform.position;
            Instantiate(ace);
        }
        else if (selectionIndex == 1)
        {
            ace.transform.position = P2Position.transform.position;
            Instantiate(ace);
        }
        AceButton.interactable = false;
        selectionIndex++;
    }

    public void SelectLuffy()
    {
        if (selectionIndex > 1) return;
        GameObject luffy = LuffyPrefab;
        HandleDirection(luffy.transform);
        if (selectionIndex == 0)
        {
            luffy.transform.position = P1Position.transform.position;
            Instantiate(luffy);
        }
        else if (selectionIndex == 1)
        {
            luffy.transform.position = P2Position.transform.position;
            Instantiate(luffy);
        }

        LuffyButton.interactable = false;
        selectionIndex++;
    }

    public void SelectZoro()
    {
        if (selectionIndex > 1) return;
        GameObject zoro = ZoroPrefab;
        HandleDirection(zoro.transform);
        if (selectionIndex == 0)
        {
            zoro.transform.position = P1Position.transform.position;
            Instantiate(zoro);
        }
        else if (selectionIndex == 1)
        {
            zoro.transform.position = P2Position.transform.position;
            Instantiate(zoro);
        }
        ZoroButton.interactable = false;
        selectionIndex++;
    }

    public void HandleDirection(Transform hologram)
    {
        if (selectionIndex == 0)
        {
            hologram.GetComponent<Hologram>().FaceRight();
        }
        else if (selectionIndex == 1)
        {
            hologram.GetComponent<Hologram>().FaceLeft();
        }
    }
}