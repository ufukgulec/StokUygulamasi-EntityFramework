using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            urunGetir();
            kategoriGetir();
        }

        private void urunGetir()
        {
            using (MyDbContext context = new MyDbContext())
            {
                gvurun.DataSource = context.Products.ToList();
            }
        }
        private void kategoriGetir()
        {
            using (MyDbContext context = new MyDbContext())
            {
                cbkategori.DataSource = context.Categories.ToList();
                cbkategori.DisplayMember = "CategoryName";
                cbkategori.ValueMember = "CategoryId";
            }
        }

        private void cbkategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                kategoriyeGöreurunGetir(Convert.ToInt32(cbkategori.SelectedValue));
            }
            catch (Exception)
            {

            }


        }
        private void kategoriyeGöreurunGetir(int kategoriId)
        {
            using (MyDbContext context = new MyDbContext())
            {
                gvurun.DataSource = context.Products.Where(x => x.CategoryId == kategoriId).ToList();
            }
        }
        private void ismeGöreurunGetir(string name)
        {
            using (MyDbContext context = new MyDbContext())
            {
                gvurun.DataSource = context.Products.Where(x => x.ProductName.Contains(name)).ToList();
            }
        }
        private void txturun_TextChanged(object sender, EventArgs e)
        {
            ismeGöreurunGetir(txturun.Text);
        }
    }
}
