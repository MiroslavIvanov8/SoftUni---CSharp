using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private double calories;
        private double bakingMulti = 1;
        private double flourMulti = 1;

        public double CalcCalories()
        {
            calories = grams * 2;
            calories *= bakingMulti * flourMulti;    
            return calories;
        }
        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType= flourType;
            BakingTechnique= bakingTechnique;
            Grams= grams;
        }
        public double Calories
        {
            get { return calories; }
            set { calories = grams * 2; }
        }

        public double Grams
        {
            get { return grams; }
            set
            {
                if (value < 1 && value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                grams = value;
            }
        }


        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                bakingTechnique = value.ToLower();

                if (bakingTechnique != "crispy" && bakingTechnique != "chewy" && bakingTechnique != "homemade")
                    throw new ArgumentException("Invalid type of dough.");
               
                if (bakingTechnique == "crispy")
                { 
                    
                   bakingMulti = 0.9;
                }
                else if (bakingTechnique == "chewy")
                {
                   bakingMulti = 1.1;
                }
                else
                {
                    bakingMulti = 1.0;
                }
            }
        }


        public string FlourType
        {
            get { return flourType; }
            set
            {
                flourType = value.ToLower();

                if(flourType!= "white" && flourType != "wholegrain")
                    throw new ArgumentException("Invalid type of dough.");
                if (flourType == "white")
                    flourMulti= 1.5;
                else
                    flourMulti = 1.0;
            }
        }
    }
}
