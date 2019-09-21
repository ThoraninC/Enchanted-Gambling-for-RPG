using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_spreader : MonoBehaviour
{
    public Button dealing_button;
    public Transform laypoint;
    public Deck dec;
    public int layorder;

    // Start is called before the first frame update
    void Start()
    {
        dealing_button.onClick.AddListener(blackjack_laying);
        laypoint = gameObject.transform;
        laypoint.position = new Vector3(0,0,1);
        layorder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void blackjack_laying()
    {
        if (dec.get_remainingcard() > 0)
        {
            GameObject a = new GameObject();
            SpriteRenderer sprd = a.AddComponent<SpriteRenderer>();
            Card_Component crd = a.AddComponent<Card_Component>();

            a.transform.position = laypoint.position;
            laypoint.position = new Vector3(laypoint.position.x + 1.0f, laypoint.position.y, laypoint.position.z);
            dec.insert_shuffle();
            crd.drawform(dec);
            layorder++;
            sprd.sortingOrder = layorder;
            a.name = "Card(" + layorder.ToString() + ")";
        }
    }

}
