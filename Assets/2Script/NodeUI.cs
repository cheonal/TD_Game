using UnityEngine;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text UpgradeCost;
    public Button UpgradeButton;
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBulidPosition();

        if (!target.isUpgrade)
        {
            UpgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            UpgradeButton.interactable = true;
        }

        else
        {
            UpgradeCost.text = "DONE";
            UpgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BulidManager.instance.DeselectNode();
    }
}
