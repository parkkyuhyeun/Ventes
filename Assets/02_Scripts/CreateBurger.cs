using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateBurger : MonoBehaviour
{
    [SerializeField] private Transform currentRecipe;
    [SerializeField] private List<GameObject> burgers = new List<GameObject>();
  
    private Dictionary<GameObject, List<RecipeEnum>> recipes = new Dictionary<GameObject, List<RecipeEnum>>();

    private void Awake()
    {
        foreach(GameObject burger in burgers)
        {
            recipes.Add(burger, new List<RecipeEnum>());
        }
        #region �⺻���� ������
        recipes[burgers[0]].Add(RecipeEnum.Bun);
        recipes[burgers[0]].Add(RecipeEnum.Meat);
        recipes[burgers[0]].Add(RecipeEnum.Cabbage);
        recipes[burgers[0]].Add(RecipeEnum.Cheese);
        recipes[burgers[0]].Add(RecipeEnum.Tomato);
        recipes[burgers[0]].Add(RecipeEnum.Bun);
        #endregion
        #region ������� ������
        recipes[burgers[1]].Add(RecipeEnum.Bun);
        recipes[burgers[1]].Add(RecipeEnum.Shrimp);
        recipes[burgers[1]].Add(RecipeEnum.Cabbage);
        recipes[burgers[1]].Add(RecipeEnum.Tomato);
        recipes[burgers[1]].Add(RecipeEnum.Bun);
        #endregion
        #region ġŲ���� ������
        recipes[burgers[2]].Add(RecipeEnum.Bun);
        recipes[burgers[2]].Add(RecipeEnum.Chicken);
        recipes[burgers[2]].Add(RecipeEnum.Cabbage);
        recipes[burgers[2]].Add(RecipeEnum.Cheese);
        recipes[burgers[2]].Add(RecipeEnum.Bun);
        #endregion
    }

    public void Create(List<RecipeEnum> recipe)
    {
        var children = currentRecipe.GetComponentsInChildren<Transform>();

        recipe.Sort();
        foreach (GameObject burger in burgers)
        {
            recipes[burger].Sort();
            if (recipes[burger].SequenceEqual(recipe))
            {
                GameObject newBurger = recipes.FirstOrDefault(x => x.Value == recipes[burger]).Key;
                Instantiate(newBurger, transform);
            }
        }
        recipe.Clear();
        foreach (var child in children)
        {
            Destroy(child.gameObject);
        }
    }
}
