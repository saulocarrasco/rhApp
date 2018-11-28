using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhApp
{
    public partial class FrmReportEmployees : Form
    {
        private readonly RhDataService _rhService;
        public FrmReportEmployees(RhDataService rhService)
        {
            InitializeComponent();
            _rhService = rhService;
            LstEmployees.DataSource = _rhService.GetAll<Employee>().ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var results = _rhService.GetAll<Employee>().Where(i=>i.DateJoin >= txtStart.Value && i.DateJoin <= txtEnd.Value).ToList();

            LstEmployees.DataSource = results;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(LstEmployees.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para la exportación");
                return;
            }

            var folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string folderName = "";

            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                return;
            }

            var fileName = string.Format("reporte{0}.csv", DateTime.UtcNow.AddHours(-4).ToString("ddMMyyyyHHmmss"));
            //var filename = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, folder);
            var pathToSave = Path.Combine(folderName, fileName);

            var sb = new StringBuilder();

            sb.AppendFormat("Nombre;");
            sb.AppendFormat("Cedula;");
            sb.AppendFormat("Departamento;");
            sb.AppendFormat("Posicion;");
            sb.AppendFormat("Salario;");
            sb.AppendFormat("Fecha de ingreso;\n");

            foreach (var item in (List<Employee>)LstEmployees.DataSource)
            {
                sb.AppendFormat("{0}{1}", item.Name, ";");
                sb.AppendFormat("{0}{1}", item.IdentificationNumber, ";");
                sb.AppendFormat("{0}{1}", item.Department, ";");
                sb.AppendFormat("{0}{1}", item.JobPosition, ";");
                sb.AppendFormat("{0}{1}", item.Salary, ";");
                sb.AppendFormat("{0}{1}\n", item.DateJoin, ";");
            }

            var stream = new MemoryStream();
            var sw = new StreamWriter(stream, Encoding.UTF8);
            sw.Write(sb.ToString());
            sw.Flush();
            stream.Position = 0;

            //var resultPath = pathToSave.Replace("\\", "/");
           

            var fileStream = File.Create(pathToSave);

            CopyStream(stream, fileStream);

            fileStream.Close();
            stream.Close();
           
           // File.WriteAllText(filename, sb.ToString());
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}
