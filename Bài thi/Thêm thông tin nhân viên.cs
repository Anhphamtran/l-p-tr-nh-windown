using System;
using System.Windows.Forms;

namespace Example01
{
    public partial class Form5 : Form
    {
        private int studentCount = 0;

        public Form5()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtHoten.Text) ||
                dtpNgaysinh.Value == null ||
                (rbNam.Checked == false && rbNu.Checked == false) ||
                string.IsNullOrWhiteSpace(cmbKhoa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gioiTinh = rbNam.Checked ? "Nam" : "Nữ";
            string sinhVienInfo = $"Họ và tên: {txtHoten.Text}\n" +
                                  $"Ngày Sinh: {dtpNgaysinh.Value.ToString("dd/MM/yyyy")}\n" +
                                  $"Giới tính: {gioiTinh}\n" +
                                  $"Khoa: {cmbKhoa.Text}";

            studentCount++;
            listStatus.Items.Add($"#{studentCount}: {sinhVienInfo}");
            listStatus.Items.Add(""); 

            MessageBox.Show("Thông tin đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtHoten.Clear();
            dtpNgaysinh.Value = DateTime.Now;
            rbNam.Checked = false;
            rbNu.Checked = false;
            cmbKhoa.SelectedIndex = -1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
