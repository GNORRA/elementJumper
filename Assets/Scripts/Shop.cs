using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    [System.Serializable] class ShopItem
    {
        public Sprite Images;
        public int Price;
        public bool IsPurchased = false;
         
    }

    [SerializeField] List<ShopItem> ShopItemList;
    [SerializeField] Animator NoCoinsAnim;
    [SerializeField] Text coinsText;


    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;

    string Coins_value = "coinsvalue";
    // Start is called before the first frame update
    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = ShopItemList.Count;

        for(int i = 0; i<len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemList[i].Images;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !ShopItemList[i].IsPurchased;
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);

          
        }

        Destroy(ItemTemplate);

        SetCoinsUI();
    }

    void OnShopItemBtnClicked(int itemIndex)
    {

        if (GameCoinManager.Instance.HasEnoughCoins(ShopItemList[itemIndex].Price)) 
        {

            GameCoinManager.Instance.UseCoins(ShopItemList[itemIndex].Price);

            ShopItemList[itemIndex].IsPurchased = true;

            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();

            buyBtn.interactable = false;

            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";

            SetCoinsUI();

        }
        else
        {
            NoCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("You don't have enough coins");
        }
        // Debug.Log(itemIndex);

    }

    void SetCoinsUI()
    {
        coinsText.text = ""+ PlayerPrefs.GetInt(Coins_value);
    }
}

