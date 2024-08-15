using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1
{
    public partial class InventoryDs : Form
    {
        public InventoryDs()
        {
            InitializeComponent();
        }

        private void InventoryDs_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var Inventory = context.Inventory.ToList();
                    DtgList.DataSource = Inventory;
                }

                DtgList.Columns["Sales"].Visible = false;

                DtgList.Columns["Id"].HeaderText = "Identificacion";
                DtgList.Columns["Object"].HeaderText = "Tipo";
                DtgList.Columns["Length"].HeaderText = "Enumerado ";
                DtgList.Columns["Pricing"].HeaderText = "Precio";
                DtgList.Columns["Amouth"].HeaderText = "Cantidad";
            }
            catch (Exception error)
            {
                MessageBox.Show($"A ocurrido un problema {error}");
                throw;
            }

        }

        private void CbxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (CbxObject.Text == "Ovalos" || CbxObject.Text == "Ensambles")
            {
                CbxLength.SelectedIndex = -1;
                CbxLength.Enabled = false;
            }
            else
            {
                CbxLength.Enabled = true;
            }
        }

        public void CleanForm()
        {
            TxtId.Text = "";
            CbxObject.SelectedIndex = -1;
            CbxLength.SelectedIndex = -1;
            TxtPricing.Text = "";
            TxtAmout.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbxObject.Text == "")
                {
                    MessageBox.Show("El campo objeto no puede estar en blanco");
                } else if (TxtPricing.Text == "")
                {
                    MessageBox.Show("El campo precio no puede estar en blanco");
                } else if (TxtAmout.Text == "")
                {
                    MessageBox.Show("El campo cantidad no puede estar en blanco");
                } else
                {
                    using (var context = new AppDbContext())
                    {
                        Inventory inventory = new Inventory()
                        {
                            Object = CbxObject.Text,
                            Length = CbxLength.Text,
                            Pricing = int.Parse(TxtPricing.Text),
                            Amouth = int.Parse(TxtAmout.Text)
                        };
                        context.Inventory.Add(inventory);
                        context.SaveChanges();

                        var Inventory = context.Inventory.ToList();
                        DtgList.DataSource = Inventory;

                        CleanForm();
                        MessageBox.Show("Se guardo con éxito");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"A ocurrido un problema {error}");
                throw;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bool contieneLetras = Regex.IsMatch(TxtId.Text, "[a-zA-Z]");
                if (TxtId.Text == "")
                {
                    MessageBox.Show("No puede estar en blanco");
                }
                else if (contieneLetras)
                {
                    MessageBox.Show("Solo numeros");
                }
                else
                {
                    using (var context = new AppDbContext())
                    {
                        var resultList = context.Inventory.AsEnumerable().FirstOrDefault(a => a.Id == int.Parse(TxtId.Text));
                        if (resultList != null)
                        {
                            CbxObject.Text = resultList.Object;
                            CbxLength.Text = resultList.Length;
                            TxtPricing.Text = resultList.Pricing.ToString();
                            TxtAmout.Text = resultList.Amouth.ToString();
                        }
                        else
                        {
                            MessageBox.Show($"No se encontro esta identificacion");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"A ocurrido un problema {error}");
                throw;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool contieneLetras = Regex.IsMatch(TxtId.Text, "[a-zA-Z]");
                if (TxtId.Text == "")
                {
                    MessageBox.Show("No puede estar en blanco");
                }
                else if (contieneLetras)
                {
                    MessageBox.Show("Solo numeros");
                }
                else
                {
                    using (var context = new AppDbContext())
                    {
                        int id = int.Parse(TxtId.Text);
                        var inventory = context.Inventory.Find(id);
                        if (inventory != null)
                        {
                            inventory.Object = CbxObject.Text;
                            inventory.Length = CbxLength.Text;
                            inventory.Pricing = int.Parse(TxtPricing.Text);
                            inventory.Amouth = int.Parse(TxtAmout.Text);
                            context.SaveChanges();

                            var Inventory = context.Inventory.ToList();
                            DtgList.DataSource = Inventory;

                            MessageBox.Show($"Se actulizo con éxito");
                        }
                        else
                        {
                            MessageBox.Show($"No se encontro esta identificacion");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"A ocurrido un problema {error}");
                throw;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool contieneLetras = Regex.IsMatch(TxtId.Text, "[a-zA-Z]");
                if (TxtId.Text == "")
                {
                    MessageBox.Show("No puede estar en blanco");
                }
                else if (contieneLetras)
                {
                    MessageBox.Show("Solo numeros");
                }
                else
                {
                    using (var context = new AppDbContext())
                    {
                        int id = int.Parse(TxtId.Text);
                        var inventory = context.Inventory.Find(id);
                        if (inventory != null)
                        {
                            context.Inventory.Remove(inventory);
                            context.SaveChanges();

                            var Inventory = context.Inventory.ToList();
                            DtgList.DataSource = Inventory;

                            CleanForm();
                            MessageBox.Show($"Se elimino con éxito");
                        }
                        else
                        {
                            MessageBox.Show($"No se encontro esta identificacion");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"A ocurrido un problema {error}");
                throw;
            }
        }

    }
}
