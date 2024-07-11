using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class CheckImgForm : Form
    {
        string url;

        public CheckImgForm(string urlImg)
        {
            InitializeComponent();    
            url = urlImg;       
            this.Load += new EventHandler(Load_Img);

        }

        private void Load_Img(object sender, EventArgs e)
        {
            try
            {
                pictureBoxCheck.Load(url);

            }catch
            {        
                pictureBoxCheck.Image = pictureBoxCheck.ErrorImage;
            }


        }


    }
}
