using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Example01
{

    public partial class QLNhanVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-68V6IK4C;Initial Catalog=QLNHANVIEN;Integrated Security=True;Encrypt=False";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinNhanVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }
        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_manv.ReadOnly = true; 
            int i;
            i=dgv.CurrentRow.Index;
            tb_manv.Text=dgv.Rows[i].Cells[0].Value.ToString();
            tb_tennv.Text= dgv.Rows[i].Cells[1].Value.ToString();
            cb_gioitinh.Text= dgv.Rows[i].Cells[3].Value.ToString();
            dtime_ngaysinh.Text= dgv.Rows[i].Cells[2].Value.ToString();
            tb_chucvu.Text= dgv.Rows[i].Cells[4].Value.ToString();
            tb_tienluong.Text= dgv.Rows[i].Cells[5].Value.ToString();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            

            command=connection.CreateCommand();
            command.CommandText = "insert into ThongTinNhanVien values ('"+tb_manv.Text+"','"+tb_tennv.Text+"','"+dtime_ngaysinh.Text+"','"+cb_gioitinh.Text+"','"+tb_chucvu.Text+"','"+tb_tienluong.Text+"')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            command= connection.CreateCommand();
            command.CommandText = "delete from ThongTinNhanVien where MaNV='"+tb_manv.Text+"'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update ThongTinNhanVien set TenNV= N'"+tb_tennv.Text+"',NgaySinh='"+dtime_ngaysinh.Text+"',GioiTinh= N'"+cb_gioitinh.Text+"',ChucVu= N'"+tb_chucvu.Text+"',TienLuong='"+tb_tienluong.Text+"' where MaNV ='"+tb_manv.Text+"' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void bt_khoitao_Click(object sender, EventArgs e)
        {
            tb_manv.Text = "";
            tb_tennv.Text = "";
            dtime_ngaysinh.Text = "1/1/1990";
            cb_gioitinh.Text = "";
            tb_chucvu.Text = "";
            tb_tienluong.Text = "";
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
