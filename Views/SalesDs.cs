using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;


namespace WindowsFormsApp1
{
    public partial class SalesDs : Form
    {
        public SalesDs()
        {
            InitializeComponent();
        }

        private async void SalesDs_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    //ID_Ventas,Precio_salida,Cantidad vendida,
                    //ID_Inventario, Tipo, Serie, Precio inventario,Cantidad inventario

                    var salesList = await context.Sales.Join(context.Inventory,
                            salesMd => salesMd.FK_Inventory,
                            inventoryMd => inventoryMd.Id,
                            (salesMd, inventoryMd) => new
                            {
                                id_sales = salesMd.Id,
                                pricing_sales = salesMd.Pricing,
                                amouth_sales = salesMd.Amouth,
                                date_sales = salesMd.Date,
                                id_inventory = inventoryMd.Id,
                                object_inventory = inventoryMd.Object,
                                length_inventory = inventoryMd.Length,
                                pricing_inventory = inventoryMd.Pricing,
                                amouth_inventory = inventoryMd.Amouth
                            }).ToListAsync();
                    DtgList.DataSource = salesList;
                }

                //DtgList.Columns["Inventory"].Visible = false;

                DtgList.Columns["id_sales"].HeaderText = "Id ventas";
                DtgList.Columns["pricing_sales"].HeaderText = "Precio ventas";
                DtgList.Columns["amouth_sales"].HeaderText = "Cantidad ventas";
                DtgList.Columns["date_sales"].HeaderText = "Fecha";
                DtgList.Columns["id_inventory"].HeaderText = "Id inventario";
                DtgList.Columns["object_inventory"].HeaderText = "Tipo inventario";
                DtgList.Columns["length_inventory"].HeaderText = "Serie inventario";
                DtgList.Columns["pricing_inventory"].HeaderText = "Precio inventario";
                DtgList.Columns["amouth_inventory"].HeaderText = "Cantidad inventario";
            }
            catch (Exception error)
            {
                MessageBox.Show($"A ocurrido un problema {error}");
                throw;
            }
        }

        public void CleanForm()
        {
            TxtId.Text = "";
            TxtIdInventory.Text = "";
            TxtPricing.Text = "";
            TxtAmout.Text = "";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool contieneLetrasIdInventory = Regex.IsMatch(TxtIdInventory.Text, "[a-zA-Z]");
                if (TxtIdInventory.Text == "")
                {
                    MessageBox.Show("El campo identificacion inventario no puede estar en blanco");
                }
                else if (TxtPricing.Text == "")
                {
                    MessageBox.Show("El campo precio no puede estar en blanco");
                }
                else if (TxtAmout.Text == "")
                {
                    MessageBox.Show("El campo cantidad no puede estar en blanco");
                }
                else if (contieneLetrasIdInventory)
                {
                    MessageBox.Show("Solo numeros en la identificacion del inventario");
                }
                else
                {
                    using (var context = new AppDbContext())
                    {
                        //Aqui resta las cantidades
                        var inventory = context.Inventory.Find(int.Parse(TxtIdInventory.Text));
                        if (inventory != null)
                        {
                            //Aqui hago la resta y guardo el valor
                            int subtraction = inventory.Amouth.Value - int.Parse(TxtAmout.Text);
                            inventory.Amouth = subtraction;
                            context.SaveChanges();

                            //Aqui guardo el valor de la venta
                            Sales sales = new Sales()
                            {
                                FK_Inventory = int.Parse(TxtIdInventory.Text),
                                Pricing = int.Parse(TxtPricing.Text),
                                Amouth = int.Parse(TxtAmout.Text),
                                Date = DtDate.Value.Date
                            };
                            context.Sales.Add(sales);
                            context.SaveChanges();

                            //Aqui hago el guardado del inventario
                            var salesList = await context.Sales.Join(context.Inventory,
                            salesMd => salesMd.FK_Inventory,
                            inventoryMd => inventoryMd.Id,
                            (salesMd, inventoryMd) => new
                            {
                                id_sales = salesMd.Id,
                                pricing_sales = salesMd.Pricing,
                                amouth_sales = salesMd.Amouth,
                                date_sales = salesMd.Date,
                                id_inventory = inventoryMd.Id,
                                object_inventory = inventoryMd.Object,
                                length_inventory = inventoryMd.Length,
                                pricing_inventory = inventoryMd.Pricing,
                                amouth_inventory = inventoryMd.Amouth
                            }).ToListAsync();
                            DtgList.DataSource = salesList;

                            CleanForm();
                            MessageBox.Show("Se guardo con éxito");
                        }
                        else
                        {
                            MessageBox.Show($"No se encontro esta identificacion del inventario");
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
                        var resultList = context.Sales.AsEnumerable().FirstOrDefault(a => a.Id == int.Parse(TxtId.Text));
                        if (resultList != null)
                        {
                            TxtIdInventory.Text = resultList.FK_Inventory.ToString();
                            TxtPricing.Text = resultList.Pricing.ToString();
                            TxtAmout.Text = resultList.Amouth.ToString();
                            DtDate.Value = resultList.Date.Value.Date;
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

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool textSale = Regex.IsMatch(TxtId.Text, "[a-zA-Z]");
                bool textInventory = Regex.IsMatch(TxtIdInventory.Text, "[a-zA-Z]");

                if (TxtId.Text == "")
                {
                    MessageBox.Show("La identificacion de la venta , no puede estar en blanco");
                }
                //if (TxtIdInventory.Text == "")
                //{
                //    MessageBox.Show("La identificacion del inventario , no puede estar en blanco");
                //}
                else if (TxtPricing.Text == "")
                {
                    MessageBox.Show("El campo precio no puede estar en blanco");
                }
                else if (TxtAmout.Text == "")
                {
                    MessageBox.Show("El campo cantidad no puede estar en blanco");
                }
                else if (textSale)
                {
                    MessageBox.Show("Identificacion venta , solo numeros");
                }
                else if (textInventory)
                {
                    MessageBox.Show("Identificacion inventario , solo numeros");
                }
                else
                {
                    using (var context = new AppDbContext())
                    {
                        int idSales = int.Parse(TxtId.Text);
                        var sale = context.Sales.Find(idSales);

                        if (sale == null)
                        {
                            MessageBox.Show("La identificacion de la venta , no existe");
                        }
                        else
                        {
                            //sumo la cantidad de la venta al inventario
                            var inventory = context.Inventory.Find(sale.FK_Inventory);
                            int sum = (int)(inventory.Amouth + sale.Amouth);

                            //Resto la nueva cantidad al inventario y lo actualizo
                            int subtraction = sum - int.Parse(TxtAmout.Text);
                            inventory.Amouth = subtraction;
                            context.SaveChanges();

                            //Actualizo la nueva cantidad y el precio de la venta
                            sale.Pricing = int.Parse(TxtPricing.Text);
                            sale.Amouth = int.Parse(TxtAmout.Text);
                            sale.Date = DtDate.Value.Date;
                            context.SaveChanges();

                            //Actualizo la lista
                            var salesList = await context.Sales.Join(context.Inventory,
                            salesMd => salesMd.FK_Inventory,
                            inventoryMd => inventoryMd.Id,
                            (salesMd, inventoryMd) => new
                            {
                                id_sales = salesMd.Id,
                                pricing_sales = salesMd.Pricing,
                                amouth_sales = salesMd.Amouth,
                                date_sales = salesMd.Date,
                                id_inventory = inventoryMd.Id,
                                object_inventory = inventoryMd.Object,
                                length_inventory = inventoryMd.Length,
                                pricing_inventory = inventoryMd.Pricing,
                                amouth_inventory = inventoryMd.Amouth
                            }).ToListAsync();
                            DtgList.DataSource = salesList;

                            MessageBox.Show($"Se actulizo con éxito");
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

        private async void BtnDelete_Click(object sender, EventArgs e)
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
                        //Aqui resta las cantidades
                        var sales = context.Sales.Find(int.Parse(TxtId.Text));
                        if (sales != null)
                        {
                            //Aqui hago la suma y guardo el valor
                            var inventory = context.Inventory.Find(sales.FK_Inventory.Value);
                            int sum = inventory.Amouth.Value + sales.Amouth.Value;

                            //Actualizo el valor del inventario
                            inventory.Amouth = sum;
                            context.SaveChanges();

                            //Elimino el valor de la venta
                            context.Sales.Remove(sales);
                            context.SaveChanges();

                            var salesList = await context.Sales.Join(context.Inventory,
                            salesMd => salesMd.FK_Inventory,
                            inventoryMd => inventoryMd.Id,
                            (salesMd, inventoryMd) => new
                            {
                                id_sales = salesMd.Id,
                                pricing_sales = salesMd.Pricing,
                                amouth_sales = salesMd.Amouth,
                                date_sales = salesMd.Date,
                                id_inventory = inventoryMd.Id,
                                object_inventory = inventoryMd.Object,
                                length_inventory = inventoryMd.Length,
                                pricing_inventory = inventoryMd.Pricing,
                                amouth_inventory = inventoryMd.Amouth
                            }).ToListAsync();
                            DtgList.DataSource = salesList;

                            CleanForm();
                            MessageBox.Show($"Se elimino con éxito");
                        }
                        else
                        {
                            MessageBox.Show($"No se encontro la identificacion de la venta");
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

        private void BtnDowloand_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbxLength.Text == "")
                {
                    MessageBox.Show("Tiene que escoger una opcion para poder descargar");
                } else if(CbxLength.Text == "Todo") {
                    DowloandPdfAll();
                } else if(CbxLength.Text == "Mes") {
                    DowloandPdfMonth();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
        }

        public async void DowloandPdfAll()
        {
            try
            {
                //Esta fecha sera para guardar el documento 
                DateTime now = DateTime.Now;

                //Esto es para el documento de entrada y salida
                string inputPdfPath = @"C:\Users\cvta_\Desktop\aplicacion marqueza\Documentos\Tabla_de_Bolitas_de_Oro.pdf";
                string outputPdfPath = $@"C:\Users\cvta_\Desktop\aplicacion marqueza\Documentos\{now.ToString("yyyyMMddHHmmssfff")}.pdf";
                //string inputPdfPath = @"C:\Users\jquir\OneDrive\Escritorio\mis cosas\project\Empresas\joyeria la marqueza\Doc\Tabla_de_Bolitas_de_Oro.pdf";
                //string outputPdfPath = $@"C:\Users\jquir\OneDrive\Escritorio\{now.ToString("yyyyMMddHHmmssfff")}.pdf";

                // Abrir el documento PDF existente
                PdfDocument document = PdfReader.Open(inputPdfPath, PdfDocumentOpenMode.Modify);

                // Obtener la primera página
                PdfPage page = document.Pages[0];

                // Crear un objeto XGraphics para dibujar en la página
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Crear un objeto XFont sin especificar un estilo de fuente
                XFont font = new XFont("Arial", 8);

                //Comienza con la consulta a la base de datos
                using (var context = new AppDbContext())
                {

                    //Realizo la consulta , con la informacion necesaria
                    var ListSales = await context.Sales.Join(context.Inventory,
                        salesMd => salesMd.FK_Inventory,
                        inventoryMd => inventoryMd.Id,
                        (salesMd, inventoryMd) => new
                        {
                            id_sales = salesMd.Id,
                            pricing_sales = salesMd.Pricing,
                            amouth_sales = salesMd.Amouth,
                            date_sales = salesMd.Date,
                            id_inventory = inventoryMd.Id,
                            object_inventory = inventoryMd.Object,
                            length_inventory = inventoryMd.Length,
                            pricing_inventory = inventoryMd.Pricing,
                            amouth_inventory = inventoryMd.Amouth
                        }).ToListAsync();

                    //Realizo la consulta del inventario
                    var ListInventory = await context.Inventory
                        .GroupBy (x => x.Object)
                        .Select(x => new 
                        { 
                            Object_inventory = x.Select(b => b.Object).FirstOrDefault(),
                            Amouth_inventory = x.Sum(b => b.Amouth)
                        }).ToListAsync();

                    //En esta tengo los valores totales
                    var TotalPricingSales = ListSales.Sum(s => s.pricing_sales);
                    var TotalAmouthSales = ListSales.Sum(s => s.amouth_sales);
                    var TotalAmouthInventory = ListInventory.Sum(s => s.Amouth_inventory);

                    //Agrupa la informacion por el tipo
                    var GroupTypeSales = ListSales
                        .GroupBy(s => s.object_inventory)
                        .Select(a => new
                        {
                            object_inventory = a.Select(b => b.object_inventory).FirstOrDefault(),
                            Amouth_Sales = a.Sum(b => b.amouth_sales),
                            Pricing_Sales = a.Sum(b => b.pricing_sales),
                        }).ToList();

                    //Agrupa la informacion por la serie
                    var GroupLengthSales = ListSales
                        .GroupBy(s => new { s.length_inventory , s.object_inventory })
                        .Select(a => new
                        {
                            length_inventory = a.Select(b => b.length_inventory).FirstOrDefault(),
                            object_inventory = a.Select(b => b.object_inventory).FirstOrDefault(),
                            Amouth_Sales = a.Sum(b => b.amouth_sales),
                            Pricing_Sales = a.Sum(b => b.pricing_sales),
                        }).ToList();

                    //Cantidad x serie
                    for (int m = 0; m < GroupLengthSales.Count; m++)
                    {
                        //Diamantadas
                        if (GroupLengthSales[m].length_inventory.ToString() == "Numero 1" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(100, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 2" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(135, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 3" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(170, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 4" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(205, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 5" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(240, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 6" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(275, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 7" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(310, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 8" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(345, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        // Lisas
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 1" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(100, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 2" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(135, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 3" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(170, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 4" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(205, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 5" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(240, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 6" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(275, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 7" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(310 , 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 8" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(345, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }

                    }

                    //Cantidad vendida y precio vendido
                    for (int i = 0; i < GroupTypeSales.Count; i++)
                    {
                        if (GroupTypeSales[i].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(380, 152, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(480, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        } 
                        else if (GroupTypeSales[i].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(380, 165, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(480, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        } 
                        else if (GroupTypeSales[i].object_inventory.ToString() == "Ovalos")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(380, 178, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(480, 178, page.Width, page.Height), XStringFormats.TopLeft);
                        } 
                        else if (GroupTypeSales[i].object_inventory.ToString() == "Ensambles")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(380, 191, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(480, 191, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                    }

                    //Cantidad Actual
                    for (int s = 0; s < ListInventory.Count; s++)
                    {
                        if (ListInventory[s].Object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(430, 152, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (ListInventory[s].Object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(430, 165, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (ListInventory[s].Object_inventory.ToString() == "Ovalos")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(430, 178, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (ListInventory[s].Object_inventory.ToString() == "Ensambles")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(430, 191, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                    }

                    // Dibujar el texto en la posición especificada - cantidad total vendida
                    gfx.DrawString(TotalAmouthSales.ToString(), font, XBrushes.Black, new XRect(380, 205, page.Width, page.Height), XStringFormats.TopLeft);

                    // Dibujar el texto en la posición especificada - precio total
                    gfx.DrawString(TotalPricingSales.ToString(), font, XBrushes.Black, new XRect(480, 205, page.Width, page.Height), XStringFormats.TopLeft);

                    // Dibujar el texto en la posición especificada - cantidad total actual
                    gfx.DrawString(TotalAmouthInventory.ToString(), font, XBrushes.Black, new XRect(430, 205, page.Width, page.Height), XStringFormats.TopLeft);

                    // Guardar el documento modificado
                    document.Save(outputPdfPath);

                    MessageBox.Show("Documento PDF modificado y guardado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public async void DowloandPdfMonth()
        {
            try
            {
                //Esta fecha sera para guardar el documento 
                DateTime now = DateTime.Now;

                //Esto es para el documento de entrada y salida
                string inputPdfPath = @"C:\Users\cvta_\Desktop\aplicacion marqueza\Documentos\Tabla_de_Bolitas_de_Oro_Fecha.pdf";
                string outputPdfPath = $@"C:\Users\cvta_\Desktop\aplicacion marqueza\Documentos\{now.ToString("yyyyMMddHHmmssfff")}.pdf";
                //string inputPdfPath = @"C:\Users\jquir\OneDrive\Escritorio\mis cosas\project\Empresas\joyeria la marqueza\Doc\Tabla_de_Bolitas_de_Oro_Fecha.pdf";
                //string outputPdfPath = $@"C:\Users\jquir\OneDrive\Escritorio\{now.ToString("yyyyMMddHHmmssfff")}.pdf";

                // Abrir el documento PDF existente
                PdfDocument document = PdfReader.Open(inputPdfPath, PdfDocumentOpenMode.Modify);

                // Obtener la primera página
                PdfPage page = document.Pages[0];

                // Crear un objeto XGraphics para dibujar en la página
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Crear un objeto XFont sin especificar un estilo de fuente
                XFont font = new XFont("Arial", 8);

                //Comienza con la consulta a la base de datos
                using (var context = new AppDbContext())
                {
                    //Realizo la consulta , con la informacion necesaria
                    var ListSales = await context.Sales
                        .Where(a => a.Date > DtStart.Value && a.Date < DtEnd.Value)
                        .Join(context.Inventory,
                        salesMd => salesMd.FK_Inventory,
                        inventoryMd => inventoryMd.Id,
                        (salesMd, inventoryMd) => new
                        {
                            id_sales = salesMd.Id,
                            pricing_sales = salesMd.Pricing,
                            amouth_sales = salesMd.Amouth,
                            date_sales = salesMd.Date,
                            id_inventory = inventoryMd.Id,
                            object_inventory = inventoryMd.Object,
                            length_inventory = inventoryMd.Length,
                            pricing_inventory = inventoryMd.Pricing,
                            amouth_inventory = inventoryMd.Amouth
                        }).ToListAsync();

                    //Realizo la consulta del inventario
                    var ListInventory = await context.Inventory
                        .GroupBy(x => x.Object)
                        .Select(x => new
                        {
                            Object_inventory = x.Select(b => b.Object).FirstOrDefault(),
                            Amouth_inventory = x.Sum(b => b.Amouth)
                        }).ToListAsync();

                    //En esta tengo los valores totales
                    var TotalPricingSales = ListSales.Sum(s => s.pricing_sales);
                    var TotalAmouthSales = ListSales.Sum(s => s.amouth_sales);
                    var TotalAmouthInventory = ListInventory.Sum(s => s.Amouth_inventory);

                    //Agrupa la informacion por el tipo
                    var GroupTypeSales = ListSales
                        .GroupBy(s => s.object_inventory)
                        .Select(a => new
                        {
                            object_inventory = a.Select(b => b.object_inventory).FirstOrDefault(),
                            Amouth_Sales = a.Sum(b => b.amouth_sales),
                            Pricing_Sales = a.Sum(b => b.pricing_sales),
                        }).ToList();

                    //Agrupa la informacion por la serie
                    var GroupLengthSales = ListSales
                        .GroupBy(s => new { s.length_inventory, s.object_inventory })
                        .Select(a => new
                        {
                            length_inventory = a.Select(b => b.length_inventory).FirstOrDefault(),
                            object_inventory = a.Select(b => b.object_inventory).FirstOrDefault(),
                            Amouth_Sales = a.Sum(b => b.amouth_sales),
                            Pricing_Sales = a.Sum(b => b.pricing_sales),
                        }).ToList();

                    // Dibujar el texto en la posición especificada - fecha
                    gfx.DrawString($"Fecha inicio: {DtStart.Value.Date} - Fecha fin: {DtEnd.Value.Date}", font, XBrushes.Black, new XRect(80, 100, page.Width, page.Height), XStringFormats.TopLeft);

                    //Cantidad x serie
                    for (int m = 0; m < GroupLengthSales.Count; m++)
                    {
                        //Diamantadas
                        if (GroupLengthSales[m].length_inventory.ToString() == "Numero 1" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(105, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 2" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(140, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 3" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(175, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 4" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(210, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 5" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(245, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 6" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(280, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 7" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(315, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 8" && GroupLengthSales[m].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(350, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        // Lisas
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 1" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(105, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 2" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(140, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 3" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(175, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 4" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(215, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 5" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(245, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 6" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(280, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 7" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(315, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupLengthSales[m].length_inventory.ToString() == "Numero 8" && GroupLengthSales[m].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupLengthSales[m].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(350, 154, page.Width, page.Height), XStringFormats.TopLeft);
                        }

                    }

                    //Cantidad vendida y valor vendido
                    for (int i = 0; i < GroupTypeSales.Count; i++)
                    {
                        if (GroupTypeSales[i].object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(385, 140, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(490, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupTypeSales[i].object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(385, 153, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(490, 153, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupTypeSales[i].object_inventory.ToString() == "Ovalos")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(385, 166, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(490, 166, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (GroupTypeSales[i].object_inventory.ToString() == "Ensambles")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(GroupTypeSales[i].Amouth_Sales.ToString(), font, XBrushes.Black, new XRect(385, 179, page.Width, page.Height), XStringFormats.TopLeft);

                            // Dibujar el texto en la posición especificada - precio
                            gfx.DrawString(GroupTypeSales[i].Pricing_Sales.ToString(), font, XBrushes.Black, new XRect(490, 179, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                    }

                    //Cantidad Actual
                    for (int s = 0; s < ListInventory.Count; s++)
                    {
                        if (ListInventory[s].Object_inventory.ToString() == "Diamantadas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(435, 140, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (ListInventory[s].Object_inventory.ToString() == "Lisas")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(435, 153, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (ListInventory[s].Object_inventory.ToString() == "Ovalos")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(435, 166, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                        else if (ListInventory[s].Object_inventory.ToString() == "Ensambles")
                        {
                            // Dibujar el texto en la posición especificada - cantidad
                            gfx.DrawString(ListInventory[s].Amouth_inventory.ToString(), font, XBrushes.Black, new XRect(435, 179, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                    }

                    // Dibujar el texto en la posición especificada - cantidad total vendida
                    gfx.DrawString(TotalAmouthSales.ToString(), font, XBrushes.Black, new XRect(390, 194, page.Width, page.Height), XStringFormats.TopLeft);

                    // Dibujar el texto en la posición especificada - precio total
                    gfx.DrawString(TotalPricingSales.ToString(), font, XBrushes.Black, new XRect(490, 194, page.Width, page.Height), XStringFormats.TopLeft);

                    // Dibujar el texto en la posición especificada - cantidad total actual
                    gfx.DrawString(TotalAmouthInventory.ToString(), font, XBrushes.Black, new XRect(440, 194, page.Width, page.Height), XStringFormats.TopLeft);

                    // Guardar el documento modificado
                    document.Save(outputPdfPath);

                    MessageBox.Show("Documento PDF modificado y guardado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
