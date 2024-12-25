using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using WCG;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] public Customer[] Customers;

    [SerializeField] public TMP_Text Description;

    public static Customer CurrentCustomer;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCustomer()
    {
        CurrentCustomer = Customers[Random.Range(0, Customers.Length)];
        Description.text = CurrentCustomer.Description;
    }
}
