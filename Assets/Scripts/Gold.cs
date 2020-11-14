using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{    
    public Text goldAmountText;
    public int goldAmountPerClick = 1;

    public int GoldAmount
    {
        get => PlayerPrefs.GetInt("Gold",1);
        set
        {
            PlayerPrefs.SetInt("Gold", value);
            UpdateGoldAmountLabel();
        }
    }
    void UpdateGoldAmountLabel()
    {
        this.goldAmountText.text = this.GoldAmount.ToString("0 Gold");
    }
    void Start()
    {
        this.GoldAmount = this.GoldAmount;
        UpdateGoldAmountLabel();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProduceGold();
        }
    }
    public void ProduceGold()
    {
        this.GoldAmount = this.GoldAmount + this.goldAmountPerClick;
    }
}
 