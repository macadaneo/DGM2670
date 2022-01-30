using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityMenuPanelController : MonoBehaviour
{
    private const string ShowKey = "Show";
    private const string HideKey = "Hide";
    private const string EntryPoolKey = "AbilityMenuPanel.Entry";
    private const int MenuCount = 4;

    [SerializeField] private GameObject entryPrefab;
    [SerializeField] private Text titleLabel;
    [SerializeField] private Panel panel;
    [SerializeField] private GameObject canval;
    private List<AbilityMenuEntry> menuEntries = new List<AbilityMenuEntry>(MenuCount);
    public int selection { get; private set; }

}
