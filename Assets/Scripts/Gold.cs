using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int goldAmount;
    public Text goldAmountText;
    public int goldAmountIncreasePerClick = 1;

    void Start()
    {
        this.goldAmount = PlayerPrefs.GetInt("Gold", 0);
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("Gold", this.goldAmount);
    }



    private void Update()
    {
        this.goldAmountText.text = this.goldAmount.ToString("0");
    }


    public void ProduceGold()
    {
        this.goldAmount = this.goldAmount + goldAmountIncreasePerClick;
    }
}
 