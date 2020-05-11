using BLL_Kvest.Interfaces;
using BLL_Kvest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Kvest
{
    public partial class MenuForAdmin : Form
    {
        IKvestRoomService serv;
        public MenuForAdmin(IKvestRoomService s)
        {
            serv = s;
            InitializeComponent();
        }

        private void MenuForAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AddKvestRoom add = new AddKvestRoom(serv);
            add.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditOrDeleteKvest add = new EditOrDeleteKvest();
            //add.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //BLL.Program prog = new BLL.Program();
            //prog.AddSertificate();
            MessageBox.Show("Succesful!");
        }
    }
}
