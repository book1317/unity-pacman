using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public List<Food> allFood;

    public void RemoveFood(Food food)
    {
        allFood.Remove(food);
    }
}
