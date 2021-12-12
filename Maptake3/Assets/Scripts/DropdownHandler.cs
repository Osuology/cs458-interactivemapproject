using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

    void Start()
    {
       var dropdown = transform.GetComponent<Dropdown>();

            dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Library");
        items.Add("Gist Hall");
        items.Add("Siemens Hall");
        items.Add("Founder's Hall");
        items.Add("Library");

        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });

    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
    }


}
