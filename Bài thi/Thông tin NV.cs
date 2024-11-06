using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Example01
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("MaNV", "Mã nhân viên");
            dataGridView1.Columns.Add("TenNV", "Tên nhân viên");
            dataGridView1.Columns.Add("Tuoi", "Tuổi");
            DataGridViewCheckBoxColumn gioiTinhColumn = new DataGridViewCheckBoxColumn();
            gioiTinhColumn.HeaderText = "Giới tính (Nam)";
            gioiTinhColumn.Name = "GioiTinh";  
            dataGridView1.Columns.Add(gioiTinhColumn);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maNV = txtMa.Text;
            string tenNV = txtTen.Text;
            int tuoi;
            if (!int.TryParse(txtTuoi.Text, out tuoi))
            {
                MessageBox.Show("Vui lòng nhập tuổi hợp lệ.");
                return;
            }
            bool gioiTinh = chkGender.Checked;
            dataGridView1.Rows.Add(maNV, tenNV, tuoi, gioiTinh);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtMa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtTuoi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[3].Value != null && dataGridView1.CurrentRow.Cells[3].Value is bool)
                {
                    chkGender.Checked = (bool)dataGridView1.CurrentRow.Cells[3].Value;
                }
                else
                {
                    chkGender.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            {
                int idx = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows[idx].Cells[0].Value = txtMa.Text;
                dataGridView1.Rows[idx].Cells[1].Value = txtTen.Text;
                dataGridView1.Rows[idx].Cells[2].Value = txtTuoi.Text;
                dataGridView1.Rows[idx].Cells[3].Value = chkGender.Checked;
            }
        }

        private void Form8_Load_1(object sender, EventArgs e)
        {

        }
    }
}
