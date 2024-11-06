using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Example01
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private void btSelect_Click(object sender, EventArgs e)
        {
            if (lbSong.SelectedItem != null)
            {
                string song = lbSong.SelectedItem.ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(lbSong.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài hát.");
            }
        }

        private void btDeselect_Click(object sender, EventArgs e)
        {
            if (lbFavorite.SelectedItem != null)
            {
                string song = lbFavorite.SelectedItem.ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(lbFavorite.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài hát.");
            }
        }
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            List<string> songsToMove = new List<string>();

            foreach (var item in lbSong.Items)
            {
                songsToMove.Add(item.ToString());
            }

            foreach (string song in songsToMove)
            {
                lbFavorite.Items.Add(song);
                lbSong.Items.Remove(song);
            }
        }
        private void btDeselectAll_Click(object sender, EventArgs e)
        {
            List<string> songsToMove = new List<string>();

            foreach (var item in lbFavorite.Items)
            {
                songsToMove.Add(item.ToString());
            }

            foreach (string song in songsToMove)
            {
                lbSong.Items.Add(song);
                lbFavorite.Items.Remove(song);
            }
        }
        private void lbSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbSong.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string song = lbSong.Items[index].ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(index);
            }
        }
        private void lbFavorite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbFavorite.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string song = lbFavorite.Items[index].ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(index);
            }
        }

        // Đóng form
        private void btnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
