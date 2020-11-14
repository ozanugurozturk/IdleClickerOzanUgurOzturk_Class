using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int goldAmount;
    public Text goldAmountText;

    private void Update()
    {
        this.goldAmountText.text = this.goldAmount.ToString("0");
    }


    public void ProduceGold()
    {
        this.goldAmount = this.goldAmount + 5;
    }
}
 