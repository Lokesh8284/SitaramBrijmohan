using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WelcomeFabric
{
    public partial class Show_Image : Form
    {
        Data bd = new Data();
        public Show_Image()
        {
            InitializeComponent();
        }

        private void lblPnlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Show_Image_Load(object sender, EventArgs e)
        {

        }

        public Show_Image(string FolderName, string _ImageName, string _DesignName)
        {
            InitializeComponent();
            if (Data.IsFTP == "False")
                bd.GetImageOnLocal(FolderName, _ImageName, pictureBox1);
            else
                bd.GetImageOnServer(FolderName, _ImageName, pictureBox1);

            lblDesignName.Text = _DesignName;
        }
    }
}
