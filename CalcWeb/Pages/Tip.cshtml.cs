using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace CalcWeb.Pages
{
    public class TipModel : PageModel
    {
        public string Tip;
        public string percentv { get; set; }
        public string peoplev { get; set; }
        public string totalv { get; set; }
        public float percent;
        public float people;
        public float total;
        public float dpercent;
        public float dtotal;
        public float dpeople;
        public string dfull;
        public string dtip;
        public string ftip;
        public string errormsg;
        public int t;


        public void OnPost()
        {
            t = 1;
            if (Request.Form["total"] != StringValues.Empty)
            {
                totalv = Request.Form["total"];
                try
                {
                    total = float.Parse(totalv);
                }
                catch (System.FormatException)
                {
                    errormsg = "Invalid format. Values must be integer or decimal";
                    ViewData["errorm"] = errormsg;
                    t = 0;

                }
            }
            if (Request.Form["people"] != StringValues.Empty)
            {
                peoplev = Request.Form["people"];
                try
                {
                    people = float.Parse(peoplev);
                }
                catch (System.FormatException)
                {
                    errormsg = "Invalid format. Values must be integer or decimal";
                    ViewData["errorm"] = errormsg;
                    t = 0;

                }
            }
            if (Request.Form["percent"] != StringValues.Empty)
            {
                percentv = Request.Form["percent"];
                try
                {
                    percent = float.Parse(percentv);
                }
                catch (System.FormatException)
                {
                    errormsg = "Invalid format. Values must be integer or decimal";
                    ViewData["errorm"] = errormsg;
                    t = 0;

                }
            }
            dpercent = percent / 100;
            dtotal = total * dpercent;
            System.Diagnostics.Debug.Print(people.ToString());
            dfull = (dtotal / people).ToString();
            dtip = "";
            if (t != 0)
            {
                int y = dfull.IndexOf(".");
                if (y != -1)
                {
                    if ((dfull.Length - (y + 1)) < 3)
                    {
                        ftip = dfull;
                    }
                    if ((dfull.Length - (y + 1)) == 3)
                    {
                        int j = dfull.ElementAt(y + 3) - 48;
                        int k = dfull.ElementAt(y + 2) - 48;
                        System.Diagnostics.Debug.Print(j.ToString());
                        if (j >= 5)
                        {
                            k = k + 1;
                            dtip = dfull.Remove(y + 2);
                            ftip = dtip + k.ToString();
                        }
                        else
                        {
                            ftip = dfull.Remove(y + 3);

                        }
                    }
                    if ((dfull.Length - (y + 1)) > 3)
                    {
                        string m = dfull.Remove(y + 4);
                        System.Diagnostics.Debug.Print(m);
                        int j = m.ElementAt(y + 3) - 48;
                        int k = m.ElementAt(y + 2) - 48;
                        System.Diagnostics.Debug.Print(j.ToString());
                        if (j >= 5)
                        {
                            k = k + 1;
                            dtip = m.Remove(y + 2);
                            ftip = dtip + k.ToString();
                        }
                        else
                        {
                            ftip = m.Remove(y + 3);

                        }
                    }
                }
                else
                {
                    ftip = dfull;
                }

                Tip = ('$' + ftip);
                ViewData["Tip"] = Tip;
            }
            else
            {
                t = 1;
            }
        }


        public void OnGet()
        {
        }
    }
}




