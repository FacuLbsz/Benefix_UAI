using BrightIdeasSoftware;
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
        private int puntajeObtenido;

        public MiEstado()
        {
            InitializeComponent();
            gestorDeEvaluaciones = GestorDeEvaluaciones.ObtenerInstancia();
            gestorDeBeneficios = GestorDeBeneficios.ObtenerInstancia();
        }

        private void MiEstado_Load(object sender, EventArgs e)
        {

            List<Evaluacion> evaluaciones = gestorDeEvaluaciones.ObtenerEvaluacionDeUnEmpleadoParaUnPeriodo(GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion(), Convert.ToInt32(DateTime.Now.ToString("yyyyMM")));
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

            var beneficiosAsignados = gestorDeBeneficios.ObtenerBeneficiosParaUnEmpleadoYUnPeriodo(GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion(), Convert.ToInt32(DateTime.Now.ToString("yyyyMM")));

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

        }
    }
}
