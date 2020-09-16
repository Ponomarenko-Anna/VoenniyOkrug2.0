using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace VoenniyOkrug
{
    public partial class Queries : Form
    {
        private int podrazdelenie_page_limit = 10;
        private int sluzhaschie_page_limit = 10;
        private int starshiy_page_limit = 10;
        private int sooruzhenie_page_limit = 7;
        private int boevaya_tehnika_page_limit = 7;
        private int transportnaya_tehnika_page_limit = 7;
        private int sostav_obiedineniya_page_limit = 7;

        private Control.QureriesControl.QueriesControl control = new Control.QureriesControl.QueriesControl();

        public Queries()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData() {


            var context = new Context.voenniy_okrugEntities();
            LoadSluzhaschie();
            LoadChasti(context);
            LoadStarshiySluzhaschiy(context);
            LoadSooruzhenie();
            LoadBoevayaTehnika(context);
            LoadTransportnayaTehnika(context);
            LoadObiedinenie(context);
            LoadSostavObiedineniy(context);

        }

        private void LoadSluzhaschie()
        {
            string[] columnNames = control.GetDgvFormatSluzhashie();
            dgvSl.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvSl.Columns.Add(column);
            }

            List<string> zvaniya = control.GetZvanieSluzhaschie();
            foreach (var zv in zvaniya) {
                cbSlZvanie.Items.Add(zv);
            }
            lblSlPage.Text = "1";

        }

        private void LoadChasti(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatChasti();
            dgvCh.Columns.Clear();
           
            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvCh.Columns.Add(column);
            }

            lblChPage.Text = "1";
            var obiedineniya = context.Obiedinenie.ToList();
        }

        
        private void LoadStarshiySluzhaschiy(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatStarshiySluzhaschiy();
            dgvSs.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvSs.Columns.Add(column);
            }

            lblSsPage.Text = "1";        
        }

        private void LoadObiedinenie(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatObiedinenie();
            //dgvOb.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
               // dgvOb.Columns.Add(column);
            }

            lblSsPage.Text = "1";        
        }

        private void LoadSostavObiedineniy(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatSostavObiedineniy();
            dgvSob.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvSob.Columns.Add(column);
            }

            var obiedineniya = context.Obiedinenie.ToList();
            foreach (var tp in obiedineniya) { cbSobObiedinenie.Items.Add(tp.nazvanie); }

            lblSobPage.Text = "1";        
        }

        private void LoadSooruzhenie()
        {
            string[] columnNames = control.GetDgvFormatSooruzhenie();
            dgvSo.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvSo.Columns.Add(column);
            }

            lblSoPage.Text = "1";

        }

        private void LoadBoevayaTehnika(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatBoevayaTehnika();
            dgvBt.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvBt.Columns.Add(column);
            }

            lblBtPage.Text = "1";

            var tipiBoevoyTehniki = context.Tip_boevoy_tehniki.ToList();
            foreach (var tbt in tipiBoevoyTehniki) { cbBtType.Items.Add(tbt.nazvanie); }


        }


        private void LoadTransportnayaTehnika(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatTransportnayaTehnika();
            dgvTt.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvTt.Columns.Add(column);
            }

            lblTtPage.Text = "1";
            var tipiTransportnoyTehnoki = context.Tip_transportnoy_tehniki.ToList();
            foreach (var ttt in tipiTransportnoyTehnoki) { cbTtType.Items.Add(ttt.nazvanie); }

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}

        private void groupBox1_Enter(object sender, EventArgs e){}

       
       
        private void radioMS_CheckedChanged(object sender, EventArgs e)
        {

            dgvSl.Rows.Clear();

            //comboBox1_SelectedIndexChanged(this, null);
            /*
            List<String[]> data = getListOfSl("MS","");

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }*/
        } 

        private void radioSS_CheckedChanged(object sender, EventArgs e)
        {

            dgvSl.Rows.Clear();

           // comboBox1_SelectedIndexChanged(this, null);
            /*
            List<String[]> data = getListOfSl("SS","");

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }*/
}


        
        private void btnSsList_Click(object sender, EventArgs e)
        {
            lblSsPage.Text = "1";
            StarshiyList();
        }

        private void StarshiyList() {
            dgvSs.Rows.Clear();
            int page = int.Parse(lblSsPage.Text) -1;
            List<String[]> data = control.GetListStarshiySluzhaschiy(tbSsId.Text,page*starshiy_page_limit, starshiy_page_limit);

            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                if (lblSsPage.Text != "1")
                {

                    lblSsPage.Text = (int.Parse(lblSsPage.Text) - 1).ToString();
                    ChastList();
                }
                return;
            }

            foreach (string[] s in data)
            {
                dgvSs.Rows.Add(s);
            }
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
           
        }

        private void btnChList_Click(object sender, EventArgs e)
        {
            lblChPage.Text = "1";
            ChastList();
        }

        private void ChastList() {
            dgvCh.Rows.Clear();
            int page = int.Parse(lblChPage.Text)-1;

            List<String[]> data = control.GetListChast((cbChSooruzheniya.SelectedIndex == -1) ? "" : cbChSooruzheniya.SelectedItem.ToString(), tbChSooruzheniya.Text,
                                                                               (cbChTransportnayaTehnika.SelectedIndex == -1) ? "" : cbChTransportnayaTehnika.SelectedItem.ToString(), tbChBoevayaTehnika.Text,
                                                                               (cbChTransportnayaTehnika.SelectedIndex == -1) ? "" : cbChTransportnayaTehnika.SelectedItem.ToString(), tbChTransportnayaTehnika.Text, page * podrazdelenie_page_limit, podrazdelenie_page_limit);

            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                if (lblChPage.Text != "1")
                {

                    lblChPage.Text = (int.Parse(lblChPage.Text) - 1).ToString();
                    ChastList();
                }
                return;
            }

            foreach (string[] s in data)
            {
                dgvCh.Rows.Add(s);
            }
        }

        private void btnChClearFields_Click(object sender, EventArgs e)
        {
            cbChSooruzheniya.SelectedIndex = -1;
            cbChBoevayaTehnika.SelectedIndex = -1;
            cbChTransportnayaTehnika.SelectedIndex = -1;
          
            tbChSooruzheniya.Text = "";
            tbChBoevayaTehnika.Text = "";
            tbChTransportnayaTehnika.Text = "";
        }

        private void btnSoList_Click(object sender, EventArgs e)
        {
            lblSoPage.Text = "1";
            SoorList();
        }

        private void SoorList() {
            dgvSo.Rows.Clear();

           int page = int.Parse(lblSoPage.Text);
            List<String[]> data = control.GetListSooruzheniya(tbSoChastId.Text,page*sooruzhenie_page_limit, sooruzhenie_page_limit);

            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                if (lblSoPage.Text != "1")
                {

                    lblSoPage.Text = (int.Parse(lblSoPage.Text) - 1).ToString();
                    SoorList();
                }
                return;
            }

            foreach (string[] s in data)
            {
                dgvSo.Rows.Add(s);
            }

        }

        private void btnSoClearFields_Click(object sender, EventArgs e)
        {
            tbSoChastId.Text = "";
        }

        private void btnSsClearFields_Click(object sender, EventArgs e)
        {
            tbSsId.Text = "";
        }

        private void IdOfSl_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void btnSlList_Click(object sender, EventArgs e)
        {
            lblSlPage.Text = "1";
            SluzhaschieList();  
        }

        private void SluzhaschieList() {
            dgvSl.Rows.Clear();

            String zvanie = ((cbSlZvanie.SelectedIndex != -1) ? cbSlZvanie.SelectedItem.ToString() : "");
            int page = int.Parse(lblSlPage.Text) - 1;
            List<String[]> data = control.GetListSluzhaschie(zvanie, page * sluzhaschie_page_limit, sluzhaschie_page_limit);

            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                if (lblSlPage.Text != "1")
                {

                    lblSlPage.Text = (int.Parse(lblSlPage.Text) - 1).ToString();
                    SluzhaschieList();
                }
                return;
            }

            foreach (string[] s in data)
            {
                dgvSl.Rows.Add(s);
            }

        }

        private void btnBtList_Click(object sender, EventArgs e)
        {
            lblBtPage.Text = "1";
            BtList();
        }

        private void BtList()
        {
            
            dgvBt.Rows.Clear();
            int page = int.Parse(lblBtPage.Text);
            List<String[]> data = control.GetListBoevayaTehnika(tbBtChastId.Text, "", (cbBtType.SelectedIndex != -1) ? (cbBtType.SelectedItem.ToString()) : "", page*boevaya_tehnika_page_limit, boevaya_tehnika_page_limit);
            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                if (lblBtPage.Text != "1")
                {

                    lblBtPage.Text = (int.Parse(lblBtPage.Text) - 1).ToString();
                    BtList();
                }
                return;
            }

            foreach (string[] s in data)
            {
                dgvBt.Rows.Add(s);
            }
        }

        private void btnTtClearFields_Click(object sender, EventArgs e)
        {
            tbTtChastId.Text = "";
            cbTtType.SelectedIndex = -1;

        }

        private void btnTtList_Click(object sender, EventArgs e)
        {
            lblTtPage.Text = "1";
            TtList();
        }

        private void TtList()
        {
            dgvTt.Rows.Clear();
            int page = int.Parse(lblTtPage.Text);

            List<String[]> data = control.GetListTransportnayaTehnika(tbTtChastId.Text, 
                                                                                                             "",
                                                                                                            (cbTtType.SelectedIndex != -1) ? (cbTtType.SelectedItem.ToString()) : "",
                                                                                                            page*transportnaya_tehnika_page_limit, transportnaya_tehnika_page_limit);
            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                if (lblTtPage.Text != "1")
                {
                    lblTtPage.Text = (int.Parse(lblTtPage.Text) - 1).ToString();
                    TtList();
                }
                return;
            }

            foreach (string[] s in data)
            {
                dgvTt.Rows.Add(s);
            }
        }

        private void btnBtClearFields_Click(object sender, EventArgs e)
        {
            tbBtChastId.Text = "";
            cbBtType.SelectedIndex = -1;
        }
        
       

        List<String[]> getListObiedinenie()
        {
            /*
                        String command_string = "select o.id, o.nazvanie, sum(chast.id) ,  sum(Kolichestvo_sooruzheniy(chast.id)),  sum(Kolichestvo_bt(chast.id)), sum(Kolichestvo_tt(chast.id)) from Obiedinenie o inner join obiedinenie_chast ob_ch on (ob_ch.obiedinenie = o.id) inner join Podrazdelenie chast on (chast.id = ob_ch.chast) ";


                        command_string += " group by o.id order by sum(distinct chast.id);";
                        DB db = new DB();
                        db.openConnection();

                        SqlCommand command = new SqlCommand(command_string, db.getConnection());

                        SqlDataReader reader = command.ExecuteReader();

                        List<String[]> data = new List<String[]>();
                        {
                            data.Add(new string[6]);

                            data[data.Count - 1][0] = reader[0].ToString();
                            data[data.Count - 1][1] = reader[1].ToString();
                            data[data.Count - 1][2] = reader[2].ToString();
                            data[data.Count - 1][3] = reader[3].ToString();
                            data[data.Count - 1][4] = reader[4].ToString();
                            data[data.Count - 1][5] = reader[5].ToString();

                        }

                        reader.Close();
                        db.closeConnection();
                        */
            List<String[]> data = new List<String[]>();

            return data;
        }

        

        

        private void btnSobList_Click(object sender, EventArgs e)
        {
            lblSobPage.Text = "1";
            SostavObList();
        }

        private void SostavObList() {

            dgvSob.Rows.Clear();
            int page = int.Parse(lblSobPage.Text);

            List<String[]> data;
            if (cbSobObiedinenie.SelectedIndex != -1)
            {
                data = control.GetListSostavObiedineniya(cbSobObiedinenie.SelectedItem.ToString(), page*sostav_obiedineniya_page_limit, sostav_obiedineniya_page_limit);

            }
            else
            {
                data = control.GetListChast("", "", "", "", "", "", page * sostav_obiedineniya_page_limit, sostav_obiedineniya_page_limit);
            }

            if (! data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                lblSobPage.Text = (int.Parse(lblSobPage.Text) - 1).ToString();
                SostavObList();
                return;
            }

            foreach (string[] s in data)
            {
                dgvSob.Rows.Add(s);
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Alter login = new Alter();
            login.Show();

        }

        private void btnSlClearFields_Click(object sender, EventArgs e)
        {
            cbSlZvanie.SelectedIndex = -1;
        }

        private void btnSobClearFields_Click(object sender, EventArgs e)
        {

        }

        private void btnSlPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblSlPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            lblSlPage.Text = (int.Parse(lblSlPage.Text) - 1).ToString();
            SluzhaschieList();
        }

        private void btnSlNextPage_Click(object sender, EventArgs e)
        {
            
            lblSlPage.Text = (int.Parse(lblSlPage.Text) + 1).ToString();
            SluzhaschieList();
        }

        private void btnChNextPage_Click(object sender, EventArgs e)
        {
            lblChPage.Text = (int.Parse(lblChPage.Text) + 1).ToString();
            ChastList();
        }

        private void btnChPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblChPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            lblChPage.Text = (int.Parse(lblChPage.Text) - 1).ToString();
            ChastList();
        }

        private void btnSsNextPage_Click(object sender, EventArgs e)
        {
            lblSsPage.Text = (int.Parse(lblSsPage.Text) + 1).ToString();
            StarshiyList();

        }

        private void btnSsPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblSsPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            lblSsPage.Text = (int.Parse(lblSsPage.Text) - 1).ToString();
            StarshiyList();

        }

        private void btnSoNextPage_Click(object sender, EventArgs e)
        {
            lblSoPage.Text = (int.Parse(lblSoPage.Text) + 1).ToString();
            SoorList();
        }

        private void btnSoPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblSoPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            lblSoPage.Text = (int.Parse(lblSoPage.Text) - 1).ToString();
            SoorList();

        }

        private void btnBtNextPage_Click(object sender, EventArgs e)
        {
            lblBtPage.Text = (int.Parse(lblBtPage.Text) + 1).ToString();
            BtList();

        }

        private void btnBtPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblBtPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            lblBtPage.Text = (int.Parse(lblBtPage.Text) - 1).ToString();
            BtList();

        }

        private void btnTtNextPage_Click(object sender, EventArgs e)
        {
            lblTtPage.Text = (int.Parse(lblTtPage.Text) + 1).ToString();
            TtList();
        }

        private void btnTtPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblTtPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            lblTtPage.Text = (int.Parse(lblTtPage.Text) - 1).ToString();
            TtList();

        }
    }
}
