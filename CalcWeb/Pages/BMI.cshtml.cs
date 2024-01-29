using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace CalcWeb.Pages
{
    public class BMIModel : PageModel
    {
        public float BMI { get; set; }
        public string weightv { get; set; }
        public string feetv { get; set; }
        public string inchesv { get; set; }
        public float height;
        public float feet;
        public float inches;
        public float weight;
        public float doubleweight;
        public string errormsg;


        public void OnPost()
        {
            if (Request.Form["weight"] != StringValues.Empty)
            {
                weightv = Request.Form["weight"];
                try
                {
                    weight = float.Parse(weightv);
                }
                catch (System.FormatException)
                {
                    errormsg = "Invalid format. Values must be integer or decimal";
                    ViewData["errorm"] = errormsg;

                }
            }
            if (Request.Form["feet"] != StringValues.Empty)
            {
                feetv = Request.Form["feet"];
                try
                {
                    feet = float.Parse(feetv);
                }
                catch (System.FormatException)
                {
                    errormsg = "Invalid format. Values must be integer or decimal";
                    ViewData["errorm"] = errormsg;

                }
            }
            if (Request.Form["inches"] != StringValues.Empty)
            {
                inchesv = Request.Form["inches"];
                try
                {
                    inches = float.Parse(inchesv);
                }
                catch (System.FormatException)
                {
                    errormsg = "Invalid format. Values must be integer or decimal";
                    ViewData["errorm"] = errormsg;

                }
            }
            System.Diagnostics.Debug.Print(inches.ToString());
            height = (feet * 12) + inches;
            System.Diagnostics.Debug.Print(height.ToString());
            System.Diagnostics.Debug.Print(weight.ToString());
            height = height * height;
            System.Diagnostics.Debug.Print(height.ToString());
            doubleweight = weight * 703;
            System.Diagnostics.Debug.Print(doubleweight.ToString());
            BMI = doubleweight / height;
            ViewData["BMI"] = BMI;
            System.Diagnostics.Debug.Print(BMI.ToString());

        }
        public void OnGet()
        {
        }

    }
}


