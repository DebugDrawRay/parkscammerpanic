using System.Linq;
using UnityEngine;

public class TransactionManager : MonoBehaviour
{
    public static TransactionManager Instance;

    public Transaction _currentTransaction
    {
        get;
        private set;
    }

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

    public float CompleteCurrentTransaction()
    {
        Debug.Log("Ending Transaction");
        float value = 0;
        if (_currentTransaction != null)
        {
            GameManager.Instance.AddToScore(Mathf.Max(0, _currentTransaction.TransactionValue));
            value = Mathf.Max(0, _currentTransaction.TransactionValue);
            _currentTransaction = null;
        }

        UIManager.Instance.HideOptions();
        return value;
    }

    public int ChooseOption(int option)
    {
        int word = -1;
        if (_currentTransaction != null)
        {
            word = _currentTransaction.ChooseOption(option);
        }
        return word;
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

    public int ChooseOption(int option)
    {
        float value = WordDatabase.GetWordValue(_currentWords[option]);
        int id = _currentWords[option];
        _transactionValue += value;    
        UIManager.Instance.UpdateTransactionScore(_transactionValue, value);

        UpdateWords();
        return id;

    }

    private void UpdateWords()
    {
        _currentWords = WordDatabase.GetRandomWordIdSet().Shuffle().ToArray();
        UIManager.Instance.UpdateOptions(_currentWords);
    }
}
