using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Component : MonoBehaviour
{
    private Card card_in_component;

    private Sprite card_sprite;
    private card_sprite_link card_Sprite_Link;
    private SpriteRenderer card_renderer;
    //public Card.Suits debug_suit;
    ////{
    ////    get { return card_in_component.get_suit(); }
    ////    set { set_suit(value); }
    ////}
    //public Card.Ranks debug_rank;
    ////{
    ////    get { return card_in_component.get_rank(); }
    ////    set { set_rank(value); }
    ////}
    //public bool revelation;

    public void set_rank(Card.Ranks ran)
    {
        card_in_component.set_rank(ran);
        update_card_sprite();
    }

    public Card.Ranks get_rank()
    {
        return card_in_component.get_rank();
    }

    public void set_suit(Card.Suits sui)
    {
        card_in_component.set_suit(sui);
        update_card_sprite();
    }

    public Card.Suits get_suit()
    {
        return card_in_component.get_suit();
    }

    public void set_card_reveal(bool reveal)
    {
        card_in_component.set_card_reveal(reveal);
        update_card_sprite();
    }

    public void switch_reveal()
    {
        card_in_component.switch_reveal();
        update_card_sprite();
    }

    public bool is_card_reveal()
    {
        return card_in_component.is_card_reveal();
    }

    public void Set_card(Card.Ranks ran, Card.Suits sui, bool reveal)
    {
        card_in_component.Set_card(ran, sui, reveal);
        update_card_sprite();
    }

    public void Set_card(Card car,bool reveal)
    {
        card_in_component.Set_card(car,reveal);
        update_card_sprite();
    }

    public void update_card_sprite()
    {
        Sprite change_sprite;
        if (card_in_component.is_card_reveal())
        {
            switch (card_in_component.get_suit())
            {
                case Card.Suits.club:
                    change_sprite = card_Sprite_Link.club_card_sprites[(int)card_in_component.get_rank()];
                    break;
                case Card.Suits.diamond:
                    change_sprite = card_Sprite_Link.diamond_card_sprites[(int)card_in_component.get_rank()];
                    break;
                case Card.Suits.heart:
                    change_sprite = card_Sprite_Link.heart_card_sprites[(int)card_in_component.get_rank()];
                    break;
                case Card.Suits.spade:
                    change_sprite = card_Sprite_Link.spade_card_sprites[(int)card_in_component.get_rank()];
                    break;
                case Card.Suits.joker:
                    if ((card_in_component.get_rank() == Card.Ranks.ace))
                    {
                        change_sprite = card_Sprite_Link.blackjoker;
                    }
                    else
                    {
                        change_sprite = card_Sprite_Link.redjoker;
                    }
                    break;
                default:
                    change_sprite = card_Sprite_Link.cardback;
                    break;
            }
        }
        else
        {
            change_sprite = card_Sprite_Link.cardback;
        }

        card_renderer.sprite = change_sprite;
    }

    public void drawform(Deck deck)
    {
        StartCoroutine(waitforcardexistance_and_draw(deck));
    }

    IEnumerator waitforcardexistance_and_draw(Deck deck)
    {
        yield return new WaitWhile(() => card_in_component == null);
        this.Set_card(deck.draw(), true);

    }

    // Start is called before the first frame update
    void Start()
    {
        card_in_component = new Card();
        card_renderer = gameObject.GetComponent<SpriteRenderer>();
        card_sprite = card_renderer.sprite;
        card_Sprite_Link = GameObject.Find("Card_connect_system").GetComponent<card_sprite_link>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(card_in_component.get_rank().ToString() + " " + card_in_component.get_suit().ToString());
        //Set_card(debug_rank, debug_suit, revelation);
        //update_card_sprite();
    }
}


public class Card
{
    public enum Suits
    {
        club,diamond,heart,spade,joker
    }

    public enum Ranks
    {
        ace,two,three,four,five,six,seven,eight,nine,ten,jack,queen,king
    }

    private Suits suit;
    private Ranks rank;
    private bool card_reveal;



    public void set_rank(Ranks ran)
    {
        rank = ran;
    }

    public Ranks get_rank()
    {
        return rank;
    }

    public void set_suit(Suits sui)
    {
        suit = sui;
    }

    public Suits get_suit()
    {
        return suit;
    }

    public void set_card_reveal(bool reveal)
    {
        card_reveal = reveal;
    }

    public void switch_reveal()
    {
        card_reveal = !card_reveal;
    }

    public bool is_card_reveal()
    {
        return card_reveal;
    }

    public Card()
    {
        card_reveal = false;
        suit = Suits.joker;
        rank = Ranks.ace;
    }

    public Card(Ranks ran,Suits sui)
    {
        suit = sui;
        rank = ran;
        card_reveal = true;
    }

    public Card(Ranks ran, Suits sui,bool reveal)
    {
        suit = sui;
        rank = ran;
        card_reveal = reveal;
        
    }

    public void Set_card(Ranks ran,Suits sui,bool reveal)
    {
        suit = sui;
        rank = ran;
        card_reveal = reveal;

    }

    public void Set_card(Card card,bool reveal)
    {
        suit = card.get_suit();
        rank = card.get_rank();

        card_reveal = reveal;
    }

    public void drawform(Deck deck)
    {
        this.Set_card(deck.draw(),true);
    }



    
}

