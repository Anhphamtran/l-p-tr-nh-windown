using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example01
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn tệp ảnh";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*"; // Lọc theo loại tệp
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // Mở thư mục Ảnh của người dùng

         
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                    
                        pbImage.Image = new Bitmap(openFileDialog.FileName);
                        pbImage.SizeMode = PictureBoxSizeMode.StretchImage; 
                        MessageBox.Show($"Tệp đã được chọn: {openFileDialog.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = txtMaNV.Text;
            string Hoten = txtHoten.Text;

            MessageBox.Show($"Thông tin đã được thêm:\nMã nhân viên: {maNV}\nHọ tên: {Hoten}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtMaNV.Clear();
            txtHoten.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
