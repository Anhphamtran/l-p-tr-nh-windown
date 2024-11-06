using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Example01
{
    public partial class Form1 : Form
    {
        string path = @"D:\form.xml"; 

        public void Write(InfoWindows iw)
        {
            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
            using (StreamWriter file = new StreamWriter(path))
            {
                writer.Serialize(file, iw);
            }
        }

    
        public InfoWindows Read()
        {
            if (!File.Exists(path)) return null;  
            XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
            using (StreamReader file = new StreamReader(path))
            {
                return (InfoWindows)reader.Deserialize(file);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null)
            {
                this.Size = new System.Drawing.Size(iw.Width, iw.Height);
                this.Location = iw.Location;
            }
        }

    
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows
            {
                Width = this.Size.Width,
                Height = this.Size.Height,
                Location = this.Location
            };
            Write(iw);
        }

       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoWindows iw = new InfoWindows
            {
                Width = this.Size.Width,
                Height = this.Size.Height,
                Location = this.Location
            };
            Write(iw);
        }

  
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\Key_Logger.txt", true))
            {
                sw.WriteLine(e.KeyCode);
            }
        }

 
        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.Text = "Article for Button";
            this.Size = new System.Drawing.Size(500, 500);
        }
    }
}
