using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private Stack<Card> deck = new Stack<Card>();
    private int card_remaining;
    public int card_amount;
    // Start is called before the first frame update

    Deck()
    {
        //empty deck initialize
        card_remaining = deck.Count;
        card_amount = card_remaining;
    }

    Deck(int deck_amout)
    {
        for(int a = deck_amout; a > 0; a--)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Push(new Card((Card.Ranks)i, (Card.Suits)j));
                }
            }
        }

        card_remaining = deck.Count;
        card_amount = card_remaining;

    }

    public Card draw()
    {
        Card drawing_card = deck.Pop();
        card_remaining = deck.Count;
        card_amount = card_remaining;

        return drawing_card;
    }

    public void insert_shuffle()
    {
        Stack<Card> buffer_deck = new Stack<Card>();
        buffer_deck = new Stack<Card>(new Stack<Card>(deck));
        List<Card> new_card_list = new List<Card>();

        while(buffer_deck.Count > 0)
        {
            //Debug.Log(buffer_deck.Peek().get_rank().ToString()+" "+ buffer_deck.Peek().get_suit().ToString());
            int randomint = Random.Range(0, new_card_list.Count+1);
            new_card_list.Insert(randomint, buffer_deck.Pop());
        }

        deck = new Stack<Card>(new_card_list);
    }

    public void select_shuffle()
    {
        
        Card[] buffer_deck = deck.ToArray();
        Stack<Card> new_deck_stack = new Stack<Card>();
        int bufferlength = buffer_deck.Length;

        while (bufferlength > 0)
        {
            int randomint = Random.Range(0, bufferlength);
            new_deck_stack.Push(buffer_deck[randomint]);

            //Debug.Log("--------------------------"+ bufferlength.ToString() +"------------------------------");
            foreach(Card a in buffer_deck)
            {
                //Debug.Log(a.get_rank().ToString()+" of "+a.get_suit().ToString());
            }

            for (int i=randomint;i+1<buffer_deck.Length;i++)
            {
                buffer_deck[i] = buffer_deck[i + 1];
            }

            bufferlength--;
        }

        deck = new_deck_stack;
    }

    public void riffle_shuffle()
    {
        Card[] buffer_deck = deck.ToArray();
        Stack<Card> new_deck_stack = new Stack<Card>();
        int deck1pointer, deck2pointer;
        deck1pointer = deck2pointer = 0;

        int halfdeck = buffer_deck.Length / 2;

        for (int i=0; i<buffer_deck.Length;i++)
        {
            if (i%2==0)
            {
                new_deck_stack.Push(buffer_deck[deck1pointer]);
                deck1pointer++;
            }
            else
            {
                new_deck_stack.Push(buffer_deck[halfdeck + deck2pointer]);
                deck2pointer++;
                
            }
        }

        deck = new_deck_stack;
    }

    public void deck_reset(int deck_amout)
    {
        deck.Clear();
        for (int a = deck_amout; a > 0; a--)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Push(new Card((Card.Ranks)j, (Card.Suits)i));
                }
            }
        }

        card_remaining = deck.Count;
        card_amount = card_remaining;

    }

    public int get_remainingcard()
    {
        return card_remaining;
    }

    void Start()
    {
        deck_reset(1);
    }

    // Update is called once per frame
    void Update()
    {
        card_amount = deck.Count;
    }
}
