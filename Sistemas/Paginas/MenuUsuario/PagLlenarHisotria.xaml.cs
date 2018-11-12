using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Sistemas.Paginas.MenuUsuario;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Sistemas.Paginas
{
	/// <summary>
	/// Lógica de interacción para PagLlenarHisotria.xaml
	/// </summary>
	public partial class PagLlenarHisotria : Page
	{
		iTextSharp.text.Document historiaPdf;
		string[] datos;
		public PagLlenarHisotria(string[] datos)
		{
			InitializeComponent();
			this.datos = datos;
			historiaPdf = new Document();
			PdfWriter.GetInstance(historiaPdf, new FileStream("sdsdf.pdf", FileMode.OpenOrCreate));
			historiaPdf.Open();
			
			historiaPdf.Add(new iTextSharp.text.Paragraph("hey"));
			
			historiaPdf.Close();
			FillForm();


		}

		private void guardar_Click(object sender, RoutedEventArgs e)
		{
			
			string[] valores = { this.datos[0], ingAf.Text };
			Conexion consultas = new Conexion("Data Source=localhost;Initial Catalog=ecco;Integrated Security=True");
			bool insertarListo=consultas.insertHistoriaCl(valores);
			if (insertarListo)
			{
				MessageBox.Show("insertado correctamente");
				NavigationService.Navigate(new MenuPrincipal(this.datos, consultas.getConexion()));
				NavigationService.RemoveBackEntry();
			}
			else MessageBox.Show("error");
			
		}

		private void ingAf_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				int.Parse(ingAf.Text);
			}
			catch {
				
				ingAf.Text = "Solo valores enteros";

			}
		}

		private void ingAf_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ingAf.Clear();
		}

		private void FillForm()
		{
			string pdfTemplate = @"formulario.pdf";
			string newFile = @"formulario1.pdf";

			PdfReader pdfReader = new PdfReader(pdfTemplate);
			PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(
						newFile, FileMode.Create));

			AcroFields pdfFormFields = pdfStamper.AcroFields;

			// Asigna los campos

			pdfFormFields.SetField("c1","df");
			pdfFormFields.SetField("c2", "lklk");
			pdfFormFields.SetField("c3", "dato 3");
			pdfFormFields.SetField("c4", "dato 4");

			string sTmp = "Datos asignados";
			MessageBox.Show(sTmp, "Terminado");

			// Cambia la propiedad para que no se pueda editar el PDF
			pdfStamper.FormFlattening = true;

			// Cierra el PDF
			pdfStamper.Close();
		}
	}
}


			
