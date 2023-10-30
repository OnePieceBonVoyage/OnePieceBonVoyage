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
        if (selectionIndex == 0)
        {
            ace.transform.position = P1Position.transform.position;
            var _a = Instantiate(ace);
            _a.GetComponent<Hologram>().FaceRight();
        }
        else if (selectionIndex == 1)
        {
            ace.transform.position = P2Position.transform.position;
            var _a = Instantiate(ace);
            _a.GetComponent<Hologram>().FaceLeft();
        }
        AceButton.interactable = false;
        selectionIndex++;
    }

    public void SelectLuffy()
    {
        if (selectionIndex > 1) return;
        GameObject luffy = LuffyPrefab;
        if (selectionIndex == 0)
        {
            luffy.transform.position = P1Position.transform.position;
            var _l = Instantiate(luffy);
            _l.GetComponent<Hologram>().FaceRight();
        }
        else if (selectionIndex == 1)
        {
            luffy.transform.position = P2Position.transform.position;
            var _l = Instantiate(luffy);
            _l.GetComponent<Hologram>().FaceLeft();
        }

        LuffyButton.interactable = false;
        selectionIndex++;
    }

    public void SelectZoro()
    {
        if (selectionIndex > 1) return;
        GameObject zoro = ZoroPrefab;
        if (selectionIndex == 0)
        {
            zoro.transform.position = P1Position.transform.position;
            var _z = Instantiate(zoro);
            _z.GetComponent<Hologram>().FaceRight();
        }
        else if (selectionIndex == 1)
        {
            zoro.transform.position = P2Position.transform.position;
            var _z = Instantiate(zoro);
            _z.GetComponent<Hologram>().FaceLeft();
        }
        ZoroButton.interactable = false;
        selectionIndex++;
    }
}