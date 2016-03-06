using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            EmployeeService.Employee employee = client.GetEmployee(Convert.ToInt32(TextBox1.Text));

            TextBox1.Text = employee.Id.ToString();
            TextBox5.Text = employee.Name.ToString();
            TextBox3.Text = employee.Gender.ToString();
            TextBox4.Text = employee.DateOfBirth.ToString("dd-MM-yyyy");

            Label1.Text = "Employee with ID = " + employee.Id.ToString() + " retrived";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            EmployeeService.Employee employee = new EmployeeService.Employee();

            employee.Id = Convert.ToInt32(TextBox1.Text);
            employee.Name = TextBox5.Text;
            employee.Gender = TextBox3.Text;
            employee.DateOfBirth = Convert.ToDateTime(TextBox4.Text);

            client.SaveEmployee(employee);
            Label1.Text = "Employee saved!";
        }
    }
}