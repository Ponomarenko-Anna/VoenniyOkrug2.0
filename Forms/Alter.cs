using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoenniyOkrug
{
    public partial class Alter : Form
    {
        private int podrazdelenie_page_limit = 10;
        private int sluzhaschie_page_limit = 10;
        private int obiedinenie_page_limit = 7;
        private int sooruzhenie_page_limit = 7;
        private int boevaya_tehnika_page_limit = 7;
        private int transportnaya_tehnika_page_limit = 7;
        private Dao.DataProvider control = new Dao.DataProvider();

        public Alter()
        {
            InitializeComponent();
            LoadData();
      }

        void LoadData()
        {
            var context = new Context.voenniy_okrugEntities();
            LoadSluzhaschie();
            LoadPodrazdelenie(context);
            LoadObiedinenie(context);
            LoadSooruzhenie();
            LoadBoevayaTehnika(context);
            LoadTransportnayaTehnika(context);
        }

        private void LoadSluzhaschie() {
            string[] columnNames = control.GetDgvFormatSluzhashie();
            dgvSl.Columns.Clear();

            foreach (string columnName in columnNames) {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvSl.Columns.Add(column);
            }

            lblSlPage.Text = "0";

        }

        private void LoadPodrazdelenie(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatPodrazdelenie();
            dgvPd.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvPd.Columns.Add(column);
            }

            lblPdPage.Text = "0";
            var tipiPodrazdeleniy = context.Tip_podrazdeleniya.ToList();
            foreach (var tp in tipiPodrazdeleniy) { cbPdType.Items.Add(tp.nazvanie); }

        }

        private void LoadObiedinenie(Context.voenniy_okrugEntities context)
        {
            string[] columnNames = control.GetDgvFormatObiedinenie();
            dgvOb.Columns.Clear();

            foreach (string columnName in columnNames)
            {
                System.Windows.Forms.DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                column.HeaderText = columnName;
                dgvOb.Columns.Add(column);
            }

            lblObPage.Text = "0";

            var tipiObiedineniy = context.Tip_obiedineniya.ToList();
            foreach (var to in tipiObiedineniy) { cbObType.Items.Add(to.nazvanie); }

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

            lblSoPage.Text = "0";

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

            lblBtPage.Text = "0";

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

            lblTtPage.Text = "0";
            var tipiTransportnoyTehnoki = context.Tip_transportnoy_tehniki.ToList();
            foreach (var ttt in tipiTransportnoyTehnoki) { cbTtType.Items.Add(ttt.nazvanie); }

        }

        private void btnSlList_Click(object sender, EventArgs e)
        {
            dgvSl.Rows.Clear();
            List<string[]> data = control.GetListSluzhaschie(tbSlId.Text, tbSlName.Text, tbSlMidName.Text, tbSlSurname.Text, 0, sluzhaschie_page_limit);
            lblSlPage.Text = "1";
            foreach (var row in data)
            {
                dgvSl.Rows.Add(row);
            }
        }

        private void btnPdList_Click(object sender, EventArgs e)
        {
            dgvPd.Rows.Clear();
            List<string[]> data = control.GetListPodrazdelenie(tbPdId.Text, tbPdNazvanie.Text, (cbPdType.SelectedIndex == -1) ? "" : cbPdType.SelectedItem.ToString(), 0, podrazdelenie_page_limit);
            lblPdPage.Text = "1";
            foreach (var row in data)
            {
                dgvPd.Rows.Add(row);
            }
        }

        private void btnSlClearFields_Click(object sender, EventArgs e)
        {
            tbSlName.Text = "";
            tbSlMidName.Text = "";
            tbSlId.Text = "";
            tbSlSurname.Text = "";
        }

        private void btnPdClearFields_Click(object sender, EventArgs e)
        {
            tbPdId.Text = "";
            cbPdType.SelectedIndex = -1;

        }

        private void btnObList_Click(object sender, EventArgs e)
        {
            dgvOb.Rows.Clear();
            List<string[]> data = control.GetListObiedinenie(tbObId.Text, tbObNazvanie.Text, (cbObType.SelectedIndex == -1) ? "" : cbObType.SelectedItem.ToString(), 0, obiedinenie_page_limit);
            lblObPage.Text = "1";
            foreach (var row in data)
            {
                dgvOb.Rows.Add(row);
            }


        }

        private void btnObClearFields_Click(object sender, EventArgs e)
        {
            tbObId.Text = "";
            tbObNazvanie.Text = "";
            cbObType.SelectedIndex = -1;
        }

        private void btnSlAdd_Click(object sender, EventArgs e)
        {
            if (tbSlName.Text == "" || tbSlMidName.Text == "" || tbSlId.Text == "" || tbSlSurname.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                string id = tbSlName.Text;
                string create = control.CreateSluzhashchie(tbSlId.Text, tbSlName.Text, tbSlMidName.Text, tbSlSurname.Text);
                if (create == "") MessageBox.Show("Успешно добавлено");
                else MessageBox.Show(create);
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Form = new Login();
            Form.Show();

        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataGridView2_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int row = dgvSl.CurrentCell.RowIndex;
            if (dgvSl[0, row].Value == null) return;

            string id_ = dgvSl[0, row].Value.ToString();
            string imya_ = dgvSl[1, row].Value.ToString();
            string otchestvo_ = dgvSl[2, row].Value.ToString();
            string familiya_ = dgvSl[3, row].Value.ToString();
            string id_starshego_ = (dgvSl[4, row].Value == null) ? "" : (dgvSl[4, row].Value.ToString());
            string m_zvanie_ = (dgvSl[5, row].Value == null) ? "" : (dgvSl[5, row].Value.ToString());
            string s_zvanie_ = (dgvSl[6, row].Value == null) ? "" : (dgvSl[6, row].Value.ToString());

            MessageBox.Show(control.UpdateSluzhaschie(id_, imya_, otchestvo_, familiya_, id_starshego_, m_zvanie_, s_zvanie_));

        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int row = dgvPd.CurrentCell.RowIndex;
            if (dgvPd[0, row].Value == null) return;


            string id_ = dgvPd[0, row].Value.ToString();
            string tip_podr_ = dgvPd[1, row].Value.ToString();
            string nazvanie_ = dgvPd[2, row].Value.ToString();
            string id_starshego_ = (dgvPd[3, row].Value == null) ? "" : dgvPd[3, row].Value.ToString();
            string komandir_ = dgvPd[4, row].Value.ToString();
            komandir_ = (komandir_ == "") ? "" : komandir_.Substring(0, komandir_.LastIndexOf(' '));
            string location_ = dgvPd[5, row].Value.ToString();

            MessageBox.Show(control.UpdatePodrazdelenie(id_, tip_podr_, nazvanie_, id_starshego_, komandir_, location_));

        }

        private void dataGridView3_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int row = dgvOb.CurrentCell.RowIndex;
            if (dgvOb[0, row].Value == null) return;

            string id_ = dgvOb[0, row].Value.ToString();
            string tip_ob_ = dgvOb[1, row].Value.ToString();
            string nazvanie_ = dgvOb[2, row].Value.ToString();
            List<string> sostav_ = dgvOb[3, row].Value.ToString().Split(',').ToList();

            MessageBox.Show(control.UpdateObiedinenie(id_, tip_ob_, nazvanie_, sostav_));


        }

        private void btnSoClearFields_Click_1(object sender, EventArgs e)
        {
            tbSoId.Text = "";
            tbSoIdPodrazdeleniya.Text = "";
            tbSoIdPodrazdeleniya.Text = "";
        }

        private void btnSoList_Click(object sender, EventArgs e)
        {
            dgvSo.Rows.Clear();

            List<string[]> data = control.GetListSooruzhenie(tbSoId.Text, tbSoNazvanie.Text, tbSoIdPodrazdeleniya.Text, 0, sooruzhenie_page_limit);

            lblSoPage.Text = "1";
            foreach (var row in data)
            {
                dgvSo.Rows.Add(row);
            }
        }

        private void dataGridView4_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int row = dgvSo.CurrentCell.RowIndex;

            if (dgvSo[0, row].Value == null) return;

            string id_ = dgvSo[0, row].Value.ToString();
            string nazvanie_ = (dgvSo[1, row].Value == null) ? "" : dgvSo[1, row].Value.ToString();
            string podrazdelenie_ = (dgvSo[2, row].Value == null) ? "" : dgvSo[2, row].Value.ToString();


            MessageBox.Show(control.UpdateSooruzhenie(id_, nazvanie_, podrazdelenie_));

        }

        private void btnBtList_Click(object sender, EventArgs e)
        {
            dgvBt.Rows.Clear();
            List<String[]> data = control.GetListBoevayaTehnika(tbBtId.Text, (cbBtType.SelectedIndex == -1) ? "" : cbBtType.SelectedItem.ToString(), tbBtIdPodrazdeleniya.Text, 0, boevaya_tehnika_page_limit);
            lblBtPage.Text = "1";
            foreach (String[] row in data)
            {
                dgvBt.Rows.Add(row);
            }
        }

        private void btnTtList_Click(object sender, EventArgs e)
        {
            dgvTt.Rows.Clear();

            List<String[]> data = control.GetListTransportnayaTehnika(tbTtId.Text, (cbTtType.SelectedIndex == -1) ? "" : cbTtType.SelectedItem.ToString(), tbTtIdPodrazdeleniya.Text, 0, transportnaya_tehnika_page_limit);
            lblTtPage.Text = "1";
            foreach (String[] row in data)
            {
                dgvTt.Rows.Add(row);
            }
        }

        private void btnBtClearFields_Click(object sender, EventArgs e)
        {
            tbBtIdPodrazdeleniya.Text = "";
            tbBtId.Text = "";
            cbBtType.SelectedIndex = -1;
        }

        private void btnTtClearFields_Click(object sender, EventArgs e)
        {
            tbTtId.Text = "";
            tbTtIdPodrazdeleniya.Text = "";
            cbTtType.SelectedIndex = -1;
        }

        private void dataGridView5_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int row = dgvBt.CurrentCell.RowIndex;

            if (dgvBt[0, row].Value == null) return;

            string id_ = dgvBt[0, row].Value.ToString();
            string tip_ = (dgvBt[1, row].Value == null) ? "" : dgvBt[1, row].Value.ToString();
            string kolichestvo_ = (dgvBt[2, row].Value == null) ? "" : dgvBt[2, row].Value.ToString();
            string podrazdelenie_ = (dgvBt[3, row].Value == null) ? "" : dgvBt[3, row].Value.ToString();

            MessageBox.Show(control.UpdateBoevayaTehnika(id_, tip_, kolichestvo_, podrazdelenie_));
        }

        private void dataGridView6_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            int row = dgvTt.CurrentCell.RowIndex;

            if (dgvTt[0, row].Value == null) return;

            string id_ = dgvTt[0, row].Value.ToString();
            string tip_ = (dgvTt[1, row].Value == null) ? "" : dgvTt[1, row].Value.ToString();
            string kolichestvo_ = (dgvTt[2, row].Value == null) ? "" : dgvTt[2, row].Value.ToString();
            string podrazdelenie_ = (dgvTt[3, row].Value == null) ? "" : dgvTt[3, row].Value.ToString();

            MessageBox.Show(control.UpdateTransportnayaTehnika(id_, tip_, kolichestvo_, podrazdelenie_));
        }

        private void btnCmdRun_Click(object sender, EventArgs e)
        {
            string command = rtbCmdCommand.Text;
            var data  = control.ExecuteCommand(command);

            foreach (String[] row in data)
            {
                foreach (String value in row)
                {
                    rtbCmdResult.Text += value + " ";
                }
                rtbCmdResult.Text += '\n'.ToString();
            }
        }

        private void btnSlDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.DeleteSluzhashchie(tbSlId.Text, tbSlName.Text, tbSlMidName.Text, tbSlSurname.Text));

        }

        private void btnSoDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.DeleteSooruzhenie(tbSoId.Text, tbSoNazvanie.Text, tbSoIdPodrazdeleniya.Text));

        }

        private void btnBtDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.DeleteBoevayaTehnika(tbBtId.Text, (cbBtType.SelectedIndex == -1) ? "" : cbBtType.SelectedItem.ToString(), "", tbBtIdPodrazdeleniya.Text));

        }

        private void btnttDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.DeleteTransportnayaTehnika(tbTtId.Text, (cbTtType.SelectedIndex == -1) ? "" : cbTtType.SelectedItem.ToString(), "", tbTtIdPodrazdeleniya.Text));
        }

        private void btnObDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.DeleteObiedinenie(tbObId.Text, tbObNazvanie.Text, (cbObType.SelectedIndex == -1) ? "" : cbObType.SelectedItem.ToString()));

        }

        private void btnPdDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.DeletePodrazdelenie(tbPdId.Text, tbPdNazvanie.Text, (cbPdType.SelectedIndex == -1) ? "" : cbPdType.SelectedItem.ToString()));

        }

        private void btnPdAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.CreatePodrazdelenie(tbPdId.Text, (cbPdType.SelectedIndex == -1) ? "" : cbPdType.SelectedItem.ToString(), tbPdNazvanie.Text));

        }

        private void btnObAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.CreateObiedinenie(tbObId.Text, (cbObType.SelectedIndex == -1) ? "" : cbObType.SelectedItem.ToString(), tbObNazvanie.Text));

        }

        private void btnSoAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.CreateSooruzhenie(tbSoId.Text, tbSoNazvanie.Text, tbSoIdPodrazdeleniya.Text));

        }

        private void btnBtAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.CreateBoevayaTehnika(tbBtId.Text, tbBtIdPodrazdeleniya.Text, (cbBtType.SelectedIndex == -1) ? "" : cbBtType.SelectedItem.ToString()));

        }

        private void btnTtAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(control.CreateTransportnayaTehnika(tbTtId.Text, tbTtIdPodrazdeleniya.Text, (cbTtType.SelectedIndex == -1) ? "" : cbTtType.SelectedItem.ToString()));

        }

        private void btnCmdClearFields_Click(object sender, EventArgs e)
        {
            rtbCmdCommand.Text = "";
            rtbCmdResult.Text = "";

        }

        private void btnQueries_Click(object sender, EventArgs e)
        {
            this.Hide();
            Queries Form = new Queries();
            Form.Show();

        }

        private void btnPdNextPage_Click(object sender, EventArgs e)
        {
            int from = int.Parse(lblPdPage.Text) * podrazdelenie_page_limit;
            List<string[]> data = control.GetListPodrazdelenie(tbPdId.Text, tbPdNazvanie.Text, (cbPdType.SelectedIndex == -1) ? "" : cbPdType.SelectedItem.ToString(), from, podrazdelenie_page_limit);
            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            dgvPd.Rows.Clear();
            lblPdPage.Text = (int.Parse(lblPdPage.Text) + 1).ToString();
            foreach (var row in data)
            {
                dgvPd.Rows.Add(row);
            }
        }

        private void btnPdPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblPdPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            int from = (int.Parse(lblPdPage.Text) - 2) * podrazdelenie_page_limit;
            List<string[]> data = control.GetListPodrazdelenie(tbPdId.Text, tbPdNazvanie.Text, (cbPdType.SelectedIndex == -1) ? "" : cbPdType.SelectedItem.ToString(), from, podrazdelenie_page_limit);
            dgvPd.Rows.Clear();
            lblPdPage.Text = (int.Parse(lblPdPage.Text) - 1).ToString();
            foreach (var row in data)
            {
                dgvPd.Rows.Add(row);
            }
        }

        private void btnSlPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblSlPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            int from = (int.Parse(lblSlPage.Text) - 2) * sluzhaschie_page_limit;
            List<string[]> data = control.GetListSluzhaschie(tbSlId.Text, tbSlName.Text, tbSlMidName.Text, tbSlSurname.Text, from, sluzhaschie_page_limit);
            dgvSl.Rows.Clear();
            lblSlPage.Text = (int.Parse(lblSlPage.Text) - 1).ToString();
            foreach (var row in data)
            {
                dgvSl.Rows.Add(row);
            }
        }

        private void btnObPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblObPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            int from = (int.Parse(lblObPage.Text) - 2) * obiedinenie_page_limit;
            List<string[]> data = control.GetListObiedinenie(tbObId.Text, tbObNazvanie.Text, (cbObType.SelectedIndex == -1) ? "" : cbObType.SelectedItem.ToString(), 0, obiedinenie_page_limit);
            dgvOb.Rows.Clear();
            lblObPage.Text = (int.Parse(lblObPage.Text) - 1).ToString();
            foreach (var row in data)
            {
                dgvOb.Rows.Add(row);
            }
        }

        private void btnSoPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblSoPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            int from = (int.Parse(lblSoPage.Text) - 2) * sooruzhenie_page_limit;
            List<string[]> data = control.GetListSooruzhenie(tbSoId.Text, tbSoNazvanie.Text, tbSoIdPodrazdeleniya.Text, from, sooruzhenie_page_limit);
            dgvSo.Rows.Clear();
            lblSoPage.Text = (int.Parse(lblSoPage.Text) - 1).ToString();
            foreach (var row in data)
            {
                dgvSo.Rows.Add(row);
            }

        }

        private void btnBtPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblBtPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            int from = (int.Parse(lblBtPage.Text) - 2) * boevaya_tehnika_page_limit;
            List<String[]> data = control.GetListBoevayaTehnika(tbBtId.Text, (cbBtType.SelectedIndex == -1) ? "" : cbBtType.SelectedItem.ToString(), tbBtIdPodrazdeleniya.Text, from, boevaya_tehnika_page_limit);
            dgvBt.Rows.Clear();
            lblBtPage.Text = (int.Parse(lblBtPage.Text) - 1).ToString();
            foreach (var row in data)
            {
                dgvBt.Rows.Add(row);
            }
        }

        private void btnTtPreviousPage_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblTtPage.Text) <= 1)
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            int from = (int.Parse(lblTtPage.Text) - 2) * podrazdelenie_page_limit;
            List<String[]> data = control.GetListTransportnayaTehnika(tbTtId.Text, (cbTtType.SelectedIndex == -1) ? "" : cbTtType.SelectedItem.ToString(), tbTtIdPodrazdeleniya.Text, from, transportnaya_tehnika_page_limit);
            dgvTt.Rows.Clear();
            lblTtPage.Text = (int.Parse(lblTtPage.Text) - 1).ToString();
            foreach (var row in data)
            {
                dgvTt.Rows.Add(row);
            }

        }

        private void btnSlNextPage_Click(object sender, EventArgs e)
        {
            int from = int.Parse(lblSlPage.Text) * sluzhaschie_page_limit;
            List<string[]> data = control.GetListSluzhaschie(tbSlId.Text, tbSlName.Text, tbSlMidName.Text, tbSlSurname.Text, from, sluzhaschie_page_limit);

            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            dgvSl.Rows.Clear();
            lblSlPage.Text = (int.Parse(lblSlPage.Text) + 1).ToString();
            foreach (var row in data)
            {
                dgvSl.Rows.Add(row);
            }
        }

        private void btnObNextPage_Click(object sender, EventArgs e)
        {
            int from = int.Parse(lblObPage.Text) * obiedinenie_page_limit;
            List<string[]> data = control.GetListObiedinenie(tbObId.Text, tbObNazvanie.Text, (cbObType.SelectedIndex == -1) ? "" : cbObType.SelectedItem.ToString(), from, obiedinenie_page_limit);
            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            dgvOb.Rows.Clear();
            lblObPage.Text = (int.Parse(lblObPage.Text) + 1).ToString();
            foreach (var row in data)
            {
                dgvOb.Rows.Add(row);
            }
        }

        private void btnSoNextPage_Click(object sender, EventArgs e)
        {
            int from = int.Parse(lblSoPage.Text) * sooruzhenie_page_limit;
            List<string[]> data = control.GetListSooruzhenie(tbSoId.Text, tbSoNazvanie.Text, tbSoIdPodrazdeleniya.Text, from, sooruzhenie_page_limit);
            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            dgvSo.Rows.Clear();
            lblSoPage.Text = (int.Parse(lblSoPage.Text) + 1).ToString();
            foreach (var row in data)
            {
                dgvSo.Rows.Add(row);
            }
        }

        private void btnBtNextPage_Click(object sender, EventArgs e)
        {
            int from = int.Parse(lblBtPage.Text) * boevaya_tehnika_page_limit;
            List<String[]> data = control.GetListBoevayaTehnika(tbBtId.Text, (cbBtType.SelectedIndex == -1) ? "" : cbBtType.SelectedItem.ToString(), tbBtIdPodrazdeleniya.Text, from, boevaya_tehnika_page_limit);
            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            dgvBt.Rows.Clear();
            lblBtPage.Text = (int.Parse(lblBtPage.Text) + 1).ToString();
            foreach (var row in data)
            {
                dgvBt.Rows.Add(row);
            }
        }

        private void btnTtNextPage_Click(object sender, EventArgs e)
        {
            int from = int.Parse(lblTtPage.Text) * podrazdelenie_page_limit;
            List<String[]> data = control.GetListTransportnayaTehnika(tbTtId.Text, (cbTtType.SelectedIndex == -1) ? "" : cbTtType.SelectedItem.ToString(), tbTtIdPodrazdeleniya.Text, from, transportnaya_tehnika_page_limit);
            if (!data.Any())
            {
                MessageBox.Show("Больше нет страниц");
                return;
            }
            dgvTt.Rows.Clear();
            lblTtPage.Text = (int.Parse(lblTtPage.Text) + 1).ToString();
            foreach (var row in data)
            {
                dgvTt.Rows.Add(row);
            }
        }
    }
}


