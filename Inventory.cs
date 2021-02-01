using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int curInvIndex = 0; //quantidade de Itens no inventario / Inventory quantity items
    public int maxCurInvIndex = 1; //maxima quantidade de Intens no inventario/ Max quantity items
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Usar o botoes para escolher/navegar entre as armas / using buttons to select between weapons 
        if (Input.GetKeyUp("up") && Input.GetMouseButton(1))
        {
            curInvIndex--;

            if (curInvIndex < 0)
            {
                curInvIndex = maxCurInvIndex;
            }
            
            applyInventory();

        }
        else if (Input.GetKeyUp("down") && Input.GetMouseButton(1))
        {
            curInvIndex++;
            if (curInvIndex > maxCurInvIndex)
            {
                curInvIndex = 0;
            }
            applyInventory();

        }
        
    }

    void applyInventory()
    {
        Transform inv = GameObject.Find("Canvas").transform;
        int count = 0;
        foreach (Transform child in inv)
        {
            GameObject curInv = child.gameObject;
            if (count == curInvIndex)
            {
                //curInv.tag = "ativo";
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.gray;
                colorBlock.pressedColor = Color.gray;
                colorBlock.highlightedColor = Color.gray;
                colorBlock.disabledColor = Color.gray;
                colorBlock.colorMultiplier = 1f;
                curInv.GetComponent<Button>().colors = colorBlock;
                GameObject.Find("Player").GetComponent<PlayerMovement>().curWeapon.active = false;
                GameObject.Find("Player").GetComponent<PlayerMovement>().curWeapon = GameObject.Find("Player").transform.Find(curInv.name).gameObject;
                GameObject.Find("Player").GetComponent<PlayerMovement>().curWeapon.active = true;
            }
            else
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.white;
                colorBlock.pressedColor = Color.white;
                colorBlock.highlightedColor = Color.white;
                colorBlock.disabledColor = Color.white;
                colorBlock.colorMultiplier = 1f;
                //curInv.tag = "inativo";
                curInv.GetComponent<Button>().colors = colorBlock;
            }
            count++;
        }
    }
}
