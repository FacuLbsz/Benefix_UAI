using BrightIdeasSoftware;
using Genesis.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesis
{
    public partial class MiEstado : Form
    {
        private GestorDeEvaluaciones gestorDeEvaluaciones;
        private GestorDeBeneficios gestorDeBeneficios;
        private List<Evaluacion> evaluaciones;
        private int puntajeObtenido;
        private List<Beneficio> beneficiosAsignados;

        public MiEstado()
        {
            InitializeComponent();
            gestorDeEvaluaciones = GestorDeEvaluaciones.ObtenerInstancia();
            gestorDeBeneficios = GestorDeBeneficios.ObtenerInstancia();
        }

        private void MiEstado_Load(object sender, EventArgs e)
        {

            evaluaciones = gestorDeEvaluaciones.ObtenerEvaluacionDeUnEmpleadoParaUnPeriodo(GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion(), Convert.ToInt32(DateTime.Now.ToString("yyyyMM")));
            this.puntajeObtenido = 0;
            evaluaciones.Where(ev => ev.alcanzado).ToList().ForEach(ev =>
            {
                puntajeObtenido = puntajeObtenido + ev.puntaje;
            });

            this.equipo.GroupKeyGetter = delegate (object rowObject)
            {
                Evaluacion evaluacion = (Evaluacion)rowObject;
                return evaluacion.equipoObjetvo.equipo.nombre;
            };

            this.equipo.GroupKeyToTitleConverter = delegate (object groupKey)
            {
                return groupKey.ToString();
            };
            evaluacionesListView.UseAlternatingBackColors = true;
            evaluacionesListView.AddObjects(evaluaciones);

            beneficiosAsignados = gestorDeBeneficios.ObtenerBeneficiosParaUnEmpleadoYUnPeriodo(GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion(), Convert.ToInt32(DateTime.Now.ToString("yyyyMM")));

            beneficiosListView.RowFormatter = delegate (OLVListItem olvItem)
            {
                Beneficio beneficio = (Beneficio)olvItem.RowObject;
                if (puntajeObtenido >= beneficio.puntaje)
                    olvItem.BackColor = Color.LightGreen;
                else
                    olvItem.BackColor = Color.OrangeRed;
            };
            this.puntajee.AspectGetter = delegate (object rowObject)
            {
                Beneficio beneficio = (Beneficio)rowObject;
                return puntajeObtenido + "/" + beneficio.puntaje;
            };
            beneficiosListView.AddObjects(beneficiosAsignados);

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            this.equipo.ToolTipText = "Objetivos asignados a los equipos que pertenece el usuario en sesion";
            this.puntaje.ToolTipText = "Puntaje que representa el objetivo";
            this.cumplimiento.ToolTipText = "Indica si el objetivo fue alcanzado";

            this.beneficioss.ToolTipText = "Beneficios asignados a los equipos que pertenece el usuario en sesion";
            this.puntajee.ToolTipText = "Puntaje obtenido de los objetivos cumplidos respecto del puntaje necesario para acceder al beneficio";

            toolTip1.SetToolTip(this.exportarPdfButton, "Exporta el reporte en un documento PDF");

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "3_Miestado.htm");

        }

        private void exportarPdfButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona donde depositar tu arhivo .PDF";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var nombreEmpleado = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion().nombreUsuario.Replace(".", " ");
                    var titulo = "Mi estado " + nombreEmpleado + " para el periodo " + ObtenerMes(DateTime.Now.Month) + " " + DateTime.Now.Year;
                    var filePath = fbd.SelectedPath + "\\Mi estado " + nombreEmpleado + ".pdf";

                    List<String> columnsObjetivos = new List<string>();
                    columnsObjetivos.Add(equipo.Text);
                    columnsObjetivos.Add(puntaje.Text);
                    columnsObjetivos.Add(cumplimiento.Text);

                    List<String> columnsBeneficios = new List<string>();
                    columnsBeneficios.Add(beneficioss.Text);
                    columnsBeneficios.Add(puntajee.Text);

                    MiEstadoPDF.ExportarPDFARuta(titulo, columnsObjetivos, evaluaciones, columnsBeneficios, beneficiosAsignados, filePath);
                    MessageBox.Show("PDF creado con exito!");
                }
            }
        }

        private String ObtenerMes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "ENERO";
                case 2:
                    return "FEBRERO";
                case 3:
                    return "MARZO";
                case 4:
                    return "ABRIL";
                case 5:
                    return "MAYO";
                case 6:
                    return "JUNIO";
                case 7:
                    return "JULIO";
                case 8:
                    return "AGOSTO";
                case 9:
                    return "SEPTIEMBRE";
                case 10:
                    return "OCTUBRE";
                case 11:
                    return "NOVIEMBRE";
                case 12:
                    return "DICIEMBRE";
                default:
                    return "";
            }
        }
    }
}
