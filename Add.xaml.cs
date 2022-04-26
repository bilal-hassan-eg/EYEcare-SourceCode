using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using WpfApp1.Add_qafla;
using WpfApp1.Edit_qafla;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
       public Add()
        {
            InitializeComponent();
        }

        public bool stat=true;
        public void setStat(bool x)
        {
            this.stat = x;
        }
        public void Edit_text_button()
        {
            btn_Text.Text = "تعديل";
            carvan_name.IsReadOnly = true;
            date.IsEnabled = false;
            center.IsReadOnly = true;
            govern.IsReadOnly = true;
            code1.IsReadOnly = true;
            reload.IsEnabled = false;
        }
        public void getData(string code)
        {
            ArrayList dt = get_data_to_edit.data(code);

            string[] date_array= dt[8].ToString().Split('/');
            string[] d_diagnosis_array = dt[12].ToString().Split('/');

            if(date_array.Length<0 && d_diagnosis_array.Length < 0)
            {

            }
            else if((date_array.Length > 0 && d_diagnosis_array.Length > 0))
            {
                try
                {
                    date.SelectedDate = new DateTime(Convert.ToInt32(date_array[2]), Convert.ToInt32(date_array[1]), Convert.ToInt32(date_array[0]));

                }
                catch { }
                try
                {
                    d_diagnosis.SelectedDate = new DateTime(Convert.ToInt32(d_diagnosis_array[2]), Convert.ToInt32(d_diagnosis_array[1]), Convert.ToInt32(d_diagnosis_array[0]));
                }
                catch { }

            }
            code1.Text = dt[0].ToString();
            name.Text = dt[1].ToString();
            number.Text = dt[2].ToString();
            national_id.Text = dt[3].ToString();
            diagnosis.Text = dt[4].ToString();
            //carvan_reply.Text = dt[5].ToString();
            age.Text = dt[6].ToString();
            carvan_name.Text = dt[7].ToString();
            center.Text = dt[9].ToString();
            govern.Text = dt[10].ToString();
            p_diagnosis.Text = dt[11].ToString();
            doctor_name.Text = dt[13].ToString();
            note.Text = dt[14].ToString();

        }
        private void Back(object sender, RoutedEventArgs e)
        {
            MainAcount account = new MainAcount();
            account.Show();
            this.Close();
        }

        private void add_edit(object sender, RoutedEventArgs e)
        {
            if (stat)
            {
                add();
            }
            if (!stat)
            {
                Edit();
            }
        }

        public void Edit()
        {
            qafla qaffla = qafla.setQafla();
            string[] date_arr = date.Text.Split('/');
            concerteBuilder build = new concerteBuilder(qaffla);
            build.Add_carva(carvan_name.Text, string.Empty , date_arr[1], date_arr[0], date_arr[2]);
            build.Add_patient(code1.Text, name.Text, number.Text, age.Text, national_id.Text, govern.Text, center.Text);
            build.Add(date.Text, diagnosis.Text, p_diagnosis.Text, d_diagnosis.Text, doctor_name.Text, note.Text);
            qafla qafla1 = build.getResult();
            WpfApp1.Edit_qafla.Edit.update_sql(qafla1);
            this.Empty_All();
        }
        public void add()
        {
            bool x = WpfApp1.Add_Edit_qafla.check_code.check(code1.Text);

            try
            {
                if (carvan_name.Text != "" && date.Text != "" && code1.Text != "" && name.Text != "" && govern.Text != "" && center.Text != "" && number.Text != "")
                {
                    if (x)
                    {

                        qafla qaffla = qafla.setQafla();
                        string[] date_arr = date.Text.Split('/');
                        concerteBuilder build = new concerteBuilder(qaffla);
                        build.Add_carva(carvan_name.Text, string.Empty, date_arr[1], date_arr[0], date_arr[2]);
                        build.Add_patient(code1.Text, name.Text, number.Text, age.Text, national_id.Text, govern.Text, center.Text);
                        build.Add(date.Text, diagnosis.Text, p_diagnosis.Text, d_diagnosis.Text, doctor_name.Text, note.Text);
                        qafla qafla1 = build.getResult();
                        sql_insert.insert_qaflaName(qafla1);


                        sql_insert.insert_qafla(qafla1);


                        sql_insert.insert_operation(qafla1);
                        this.Empty_All_code_add_1();
                    }
                    else
                    {
                        MessageBox.Show("لقد تم استخدام هذا الكود من قبل");
                    }


                    }
                    else
                    {
                        MessageBox.Show("برجاء ادخال البيانات");

                    }
                }
                catch
                {
                    MessageBox.Show("برجاء ادخال البيانات");
                }

            




        }
        private void refresh(object sender, RoutedEventArgs e)
        {
            Empty_All();
        }
        private void Empty_All()
        {
            name.Text = code1.Text = number.Text = national_id.Text = diagnosis.Text  = age.Text =
                p_diagnosis.Text = d_diagnosis.Text =
                doctor_name.Text = note.Text = null;
        }
        private void Empty_All_code_add_1()
        {
            name.Text = number.Text = national_id.Text = diagnosis.Text = age.Text =
                p_diagnosis.Text = d_diagnosis.Text =
                doctor_name.Text = note.Text = null;
            code1.Text = Convert.ToString(Convert.ToInt32(code1.Text) + 1);
        }

        /* private void set_text_date_change()
         {
             code1.TextChanged += this.text_changed;
             name.TextChanged += this.text_changed;
             number.TextChanged += this.text_changed;
             national_id.TextChanged += this.text_changed;
             diagnosis.TextChanged += this.text_changed;
             carvan_reply.TextChanged += this.text_changed;
             age.TextChanged += this.text_changed;
             carvan_name.TextChanged += this.text_changed;
             center.TextChanged += this.text_changed;
             govern.TextChanged += this.text_changed;
             p_diagnosis.TextChanged += this.text_changed;
             doctor_name.TextChanged += this.text_changed;
             note.TextChanged += this.text_changed;
             date.SelectedDateChanged += this.date_changed;
             d_diagnosis.SelectedDateChanged += this.date_changed;

         }
         private void text_changed(object sender, TextChangedEventArgs e)
         {
             Edit_data.Add(((TextBox)sender).Name.ToString(), ((TextBox)sender).Text);
         }

         private void date_changed(object sender, SelectionChangedEventArgs e)
         {
             Edit_data.Add("d_diagnosis", ((DatePicker)sender).Text);
         }
        */

    }
}
