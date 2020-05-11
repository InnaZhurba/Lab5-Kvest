using AutoMapper;
using BLL_Kvest.DTO;
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
using UI_Kvest.Entities;

namespace UI_Kvest
{
    public partial class AddKvestRoom : Form
    {
        IKvestRoomService kvestService;
        int ageCategory;
        int usersValue;
        public AddKvestRoom( IKvestRoomService serv)
        {
            kvestService = serv;

            InitializeComponent();
            AddComboUsersValues();
            AddComboAgeCategories();
            CleanItems();
        }
        void AddComboUsersValues()
        {
            
            IEnumerable<UsersValueDTO> usersVal = kvestService.GetUsersValues();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersValueDTO, UsersValue>()).CreateMapper();
            IEnumerable<UsersValue> val = mapper.Map<IEnumerable<UsersValueDTO>, List<UsersValue>>(usersVal);


            foreach(UsersValue c in val)
                comboBox1.Items.Add(c.min + "-" + c.max);
        }
        void AddComboAgeCategories()
        {
            IEnumerable<AgeCategoryDTO> usersVal = kvestService.GetAgeCategories();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AgeCategoryDTO, AgeCategory>()).CreateMapper();
            IEnumerable<AgeCategory> val = mapper.Map<IEnumerable<AgeCategoryDTO>, List<AgeCategory>>(usersVal);

            foreach (AgeCategory c in val)
                comboBox2.Items.Add(c.min + "-" + c.max);
        }
        void CleanItems()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KvestRoom, KvestRoomDTO>()).CreateMapper();
                KvestRoomDTO kvest = mapper.Map<KvestRoom,KvestRoomDTO>(new KvestRoom { Name = textBox1.Text , UsersValueId = usersValue, AgeCategoryId = ageCategory, PriceForOneUser = Convert.ToInt32(textBox2.Text) });

                kvestService.MakeKvest(kvest);
                //if (prog.AddKvestRoom(textBox1.Text, usersValue, ageCategory, Convert.ToInt32(textBox2.Text)))
                //{
                    MessageBox.Show("Kvest-room was added succesfully!!!");
                    CleanItems();
                //}
            }
            else
                MessageBox.Show("You shoud edit all rows. Try again!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            usersValue = comboBox1.SelectedIndex + 1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ageCategory = comboBox2.SelectedIndex + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuForAdmin m = new MenuForAdmin(kvestService);
            m.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddKvestRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
