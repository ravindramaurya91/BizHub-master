using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Base;
using Model;
using CommonUtil;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using BizHub.Service;

namespace Test {
    public class TestRecipes {


        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }

        #endregion Setup / Tear down

        [Test]
        public void Test01_AddNewRecipe() {
            Recipe oRecipe = new Recipe();
            oRecipe.Name = "Snickerdoodles";
            oRecipe.Description = "Best cookies ever with no nutritional value";
            oRecipe.Source = "Geneva Grover";
            oRecipe.Save();
           
            Debug.WriteLine(oRecipe.Oid);

            Ingredient oIngredient = new Ingredient();
            oIngredient.Name = "Flour";
            oIngredient.Amount = "1 Cup";
            oIngredient.RecipeOid = oRecipe.Oid;
            oIngredient.Save();

            oIngredient = new Ingredient();
            oIngredient.Name = "Sugar";
            oIngredient.Amount = "1/2 Cup";
            oIngredient.RecipeOid = oRecipe.Oid;
            oIngredient.Save();

            oIngredient = new Ingredient();
            oIngredient.Name = "Egg";
            oIngredient.Amount = "2";
            oIngredient.RecipeOid = oRecipe.Oid;
            oIngredient.Save();
        }
        [Test]
        public void Test02_RetrieveRecipe() {
            Int64 iOid = 1;
            Recipe oRecipe = Recipe.FirstOrDefault("WHERE Oid = @0", iOid);
            Debug.WriteLine(oRecipe.Ingredients.Count);
            oRecipe.Ingredients = Ingredient.Fetch("WHERE RecipeOid = @0", oRecipe.Oid);
            Debug.WriteLine(oRecipe.Ingredients.Count);

            foreach (Ingredient oIngredient in oRecipe.Ingredients) {
                Debug.WriteLine(oIngredient.Amount + "  " + oIngredient.Name);

            }
        }
        [Test]
        public void Test03_Dictionary() {
            try {
                Dictionary<string, List<int>> oDict1 = new Dictionary<string, List<int>>();
                oDict1.Add("1", new List<int>() { 1, 2, 3 });

                Dictionary<string, List<int>> oDict2 = new Dictionary<string, List<int>>();
                oDict2.Add("1", new List<int>() { 1, 2, 4 });
                oDict2.Add("2", new List<int>() { 1, 2, 4 });

                oDict1 = MergeDict(oDict1, oDict2);

                Debug.WriteLine("Here");
            } catch(Exception ex) {
                Debug.WriteLine("Error");
                throw ex;
            }

        }

        private static Dictionary<string, List<int>> MergeDict(Dictionary<string, List<int>>toSource, Dictionary<string, List<int>> toTwo) {

            foreach(string sKey in toTwo.Keys) {
                if (toSource.ContainsKey(sKey)) {
                    var oCollection = toSource[sKey];
                    foreach (int i in toTwo[sKey]) {
                        if (!oCollection.Contains(i)) {
                            oCollection.Add(i);
                        }
                    }
                } else {
                    toSource.Add(sKey, toTwo[sKey]);
                }
            }
            return toSource;
        }

    }
}
