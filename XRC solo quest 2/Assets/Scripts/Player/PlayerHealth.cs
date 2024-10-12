using System;
using System.Collections;

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] private PlayerConfig _playerConfig;
  [SerializeField] private int _currenthealth;

  public void Awake()
  {
    _currenthealth = _playerConfig.BaseHealth;
  }

  public void heal(int healAmmount)
  {
    if (healAmmount < 0)
    {
      return;
    }

    if (healAmmount + _currenthealth > _playerConfig.MaxHealth)
    {
      _currenthealth = _playerConfig.MaxHealth;
      return;
    }

    _currenthealth += healAmmount;
  }
}
