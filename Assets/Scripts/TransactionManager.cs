using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionManager : MonoBehaviour
{
    public static TransactionManager Instance;

    private Transaction _currentTransaction;

    private void Awake()
    {
        Instance = this;
    }

    public void StartTransaction(GameObject customer)
    {
        if (_currentTransaction != null)
        {
            CompleteCurrentTransaction();
        }

        _currentTransaction = new Transaction(customer);
    }

    public void CompleteCurrentTransaction()
    {
        if (_currentTransaction != null)
        {
            //Send value to Game Manager;
            _currentTransaction = null;
        }
    }

    public void ChooseOption(int optionNumber)
    {

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

    private Word[] _currentWordSet; 

    public Transaction(GameObject customer)
    {
        Customer = customer;
        UpdateWords();
    }

    public void SubmitWord(int wordIndex)
    {
        if (wordIndex < _currentWordSet.Length)
        {
            _transactionValue += _currentWordSet[wordIndex].Value;
        }
        UpdateWords();
    }

    private void UpdateWords()
    {
        _currentWordSet = WordDatabase.GetRandomWordSet();
        UIManager.Instance.UpdateOptions(_currentWordSet);
    }
}
