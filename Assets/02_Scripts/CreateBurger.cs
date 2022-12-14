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
        #region 기본버거 레시피
        recipes[burgers[0]].Add(RecipeEnum.Bun);
        recipes[burgers[0]].Add(RecipeEnum.Meat);
        recipes[burgers[0]].Add(RecipeEnum.Cabbage);
        recipes[burgers[0]].Add(RecipeEnum.Cheese);
        recipes[burgers[0]].Add(RecipeEnum.Tomato);
        #endregion
        #region 새우버거 레시피
        recipes[burgers[1]].Add(RecipeEnum.Bun);
        recipes[burgers[1]].Add(RecipeEnum.Shrimp);
        recipes[burgers[1]].Add(RecipeEnum.Cabbage);
        recipes[burgers[1]].Add(RecipeEnum.Tomato);
        recipes[burgers[1]].Add(RecipeEnum.Onion);
        #endregion
        #region 치킨버거 레시피
        recipes[burgers[2]].Add(RecipeEnum.Bun);
        recipes[burgers[2]].Add(RecipeEnum.Chicken);
        recipes[burgers[2]].Add(RecipeEnum.Cabbage);
        recipes[burgers[2]].Add(RecipeEnum.Cheese);
        recipes[burgers[2]].Add(RecipeEnum.Cucumber);
        #endregion
        #region GGM버거 레시피
        recipes[burgers[3]].Add(RecipeEnum.Bun);
        recipes[burgers[3]].Add(RecipeEnum.Cabbage);
        recipes[burgers[3]].Add(RecipeEnum.Chicken);
        recipes[burgers[3]].Add(RecipeEnum.Meat);
        recipes[burgers[3]].Add(RecipeEnum.Cheese);
        #endregion
        #region KH버거 레시피
        recipes[burgers[4]].Add(RecipeEnum.Bun);
        recipes[burgers[4]].Add(RecipeEnum.Cucumber);
        recipes[burgers[4]].Add(RecipeEnum.Onion);
        recipes[burgers[4]].Add(RecipeEnum.Cheese);
        recipes[burgers[4]].Add(RecipeEnum.Chicken);
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
            if (child == currentRecipe) continue;
            Destroy(child.gameObject);
        }
    }
}
