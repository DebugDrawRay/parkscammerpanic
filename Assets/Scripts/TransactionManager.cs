﻿using System.Linq;
using UnityEngine;

public class TransactionManager : MonoBehaviour
{
    public static TransactionManager Instance;

    private Transaction _currentTransaction;

    private void Awake()
    {
        Instance = this;
    }

    public float GetTransactionValue()
    {
        if(_currentTransaction != null)
        {
            return _currentTransaction.TransactionValue;
        }
        else
        {
            return 0;
        }
    }
    public void StartTransaction(GameObject customer)
    {
        Debug.Log("Starting Transaction");
        if (_currentTransaction != null)
        {
            CompleteCurrentTransaction();
        }

        _currentTransaction = new Transaction(customer);
    }

    public bool CompleteCurrentTransaction()
    {
        Debug.Log("Ending Transaction");
        float value = 0;
        if (_currentTransaction != null)
        {
            GameManager.Instance.AddToScore(_currentTransaction.TransactionValue);
            value = _currentTransaction.TransactionValue;
            _currentTransaction = null;
        }

        UIManager.Instance.HideOptions();

        return value > 0;
    }

    public void ChooseOption(int option)
    {
        if (_currentTransaction != null)
        {
            _currentTransaction.ChooseOption(option);
        }
    }
}

public class Transaction
{
    public GameObject Customer;

    private float _transactionValue = 0;
    public float TransactionValue
    {
        get
        {
            return _transactionValue;
        }
    }

    private int[] _currentWords;

    public Transaction(GameObject customer)
    {
        Customer = customer;

        UpdateWords();
    }

    public void ChooseOption(int option)
    {
        float value = WordDatabase.GetWordValue(_currentWords[option]);
        _transactionValue += value;
        UIManager.Instance.UpdateTransactionScore(_transactionValue, value);

        UpdateWords();
    }

    private void UpdateWords()
    {
        _currentWords = WordDatabase.GetRandomWordIdSet().Shuffle().ToArray();
        UIManager.Instance.UpdateOptions(_currentWords);
    }
}
