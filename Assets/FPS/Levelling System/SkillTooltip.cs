using TMPro;
using UnityEngine;

[System.Serializable]
public class SkillTooltip
{
    [SerializeField] 
    private GameObject tooltipPanel;

    //public TextMeshProUGUI tooltipTitle, tooltipDescription;

    /// <summary>
    /// Displays the tooltip with the skill name and cost for the specified skill node.
    /// </summary>
    /// <param name="skillNode">The skill node to display information for.</param>
    public void ShowTooltip()
    {
        tooltipPanel.SetActive(true);
    }

    /// <summary>
    /// Hides the tooltip panel.
    /// </summary>
    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}
