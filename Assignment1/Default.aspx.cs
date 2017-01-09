using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string[] tipPercent = { "10%", "15%", "20%", "Other" };
            TipPercentsRadioButtonList.DataSource = tipPercent;
            TipPercentsRadioButtonList.DataBind();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        GetInfo();
    }

    protected void GetInfo()
    {
        Tip tip = new Tip();
        tip.MealAmount = double.Parse(MealTextbox.Text);
        if(OtherTextBox.Text == "")
        { tip.TipPercent = 0;
            foreach(ListItem item in TipPercentsRadioButtonList.Items)
            {
               
                if (item.Selected)
                {
                    if (item.Text.Equals("10%"))
                    {
                        tip.TipPercent = .1;
                    }
                    else if (item.Text.Equals("15%"))
                    {
                        tip.TipPercent = .15;
                    }
                    else if (item.Text.Equals("20%"))
                    {
                        tip.TipPercent = .2;
                    }   
                }
            }
        }
        else
        {
            tip.TipPercent = double.Parse(OtherTextBox.Text);       
        }

        ResultLabel.Text = "Amount: " + tip.MealAmount.ToString() + "<br/>" +
            "Tip: " + tip.CalculateTip().ToString("$#,##0.00") + "<br/>" +
            "Tax: " + tip.CalculateTax().ToString("$#,##0.00") + "<br/>" +
            "Tax: " + tip.CalculateTotal().ToString("$#,##0.00");
    }
}