using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Lifes : MonoBehaviour
{
    [SerializeField] bool _isPlayer;
    [SerializeField] int _scoreOnDeath;
    [SerializeField] bool _isEnemy;

    [Header("Health")]
    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth;

    [Header("Events")]
    [SerializeField] UnityEvent _onPlayerDamage;
    [SerializeField] UnityEvent _onEnemyDamage;

    public bool IsPlayer { get => _isPlayer; set => _isPlayer = value; }
    public bool IsEnemy { get => _isEnemy; set => _isEnemy = value; }

    private void Reset()
    {
        _currentHealth = 30;
        _scoreOnDeath = 10;
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if(_currentHealth <= 0) {
            Destroy(gameObject);
        }
        

    }

    public void Heal(int amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

    }

    internal void TakeDamage()
    {
        throw new NotImplementedException();
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }
}