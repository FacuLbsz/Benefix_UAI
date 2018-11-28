using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeEvaluaciones
{

    private static GestorDeEvaluaciones instancia;
    public GestorDeDigitoVerificador gestorDeDigitoVerificador;
    private GestorDeObjetivos gestorDeObjetivos;
    private GestorDeEquipos gestorDeEquipos;
    private BaseDeDatos baseDeDatos;

    private GestorDeEvaluaciones()
    {
        gestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        gestorDeObjetivos = GestorDeObjetivos.ObtenerInstancia();
        gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeEvaluaciones ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEvaluaciones();
        }

        return instancia;
    }

    public int CrearEvaluacion(Evaluacion evaluacion)
    {
        var empleado = evaluacion.usuario;
        var objetivo = evaluacion.equipoObjetvo.objetivo.identificador;
        var equipo = evaluacion.equipoObjetvo.equipo.identificador;
        var puntaje = evaluacion.equipoObjetvo.objetivo.puntaje;
        var periodo = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));


        var evaluacionExistente = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EVALUACION INNER JOIN EquipoObjetivo on EquipoObjetivo.idEquipoObjetivo = Evaluacion.EquipoObjetivo_idEquipoObjetivo WHERE periodo = {0} AND Evaluacion.EquipoObjetivo_idEquipoObjetivo = {1} AND Evaluacion.Usuario_idUsuario = {2}", periodo, evaluacion.equipoObjetvo.identificador, empleado.identificador));
        if (evaluacionExistente.Rows.Count > 0)
        {
            if (!evaluacion.alcanzado)
            {
                var registros = baseDeDatos.ModificarBase(String.Format("DELETE FROM EVALUACION WHERE idEvaluacion = {0}", evaluacionExistente.Rows[0]["idEvaluacion"]));
                gestorDeDigitoVerificador.ModificarDigitoVV("EVALUACION");
                return registros;
            }
        }
        else if (evaluacion.alcanzado)
        {
            var digitoVH = GestorDeDigitoVerificador.ObtenerDigitoVH(new List<String> { puntaje.ToString(), periodo.ToString() });
            var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO evaluacion (puntaje,periodo,EquipoObjetivo_idEquipoObjetivo,digitoVerificadorH,Usuario_idUsuario)  VALUES ({0},{1},{2},'{3}',{4})", puntaje, periodo, evaluacion.equipoObjetvo.identificador, digitoVH, empleado.identificador));
            gestorDeDigitoVerificador.ModificarDigitoVV("EVALUACION");

            return registros;
        }


        return 1;
    }

    public List<Evaluacion> ObtenerEvaluacionDeUnEmpleadoParaUnPeriodo(Usuario empleado, int periodo)
    {
        var equipos = gestorDeEquipos.ConsultarEquiposDeUnEmpleadoPorPeriodo(empleado, periodo);

        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        equipos.ForEach(e =>
        {
            var equipoObjetivos = gestorDeObjetivos.ConsultarObjetivosAsignadosAUnEquipoEnUnPeriodo(e, periodo);
            equipoObjetivos.ForEach(o =>
            {
                Evaluacion evaluacion = null;

                var evaluacionesEnBase = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EVALUACION WHERE EQUIPOOBJETIVO_IDEQUIPOOBJETIVO = {0} and PERIODO = {1} AND USUARIO_IDUSUARIO = {2}", o.identificador, periodo, empleado.identificador));
                if (evaluacionesEnBase.Rows.Count > 0)
                {
                    evaluacion = PopularEvaluacionDesdeBD(evaluacionesEnBase.Rows[0], o);
                }
                else
                {
                    evaluacion = new Evaluacion();
                    evaluacion.alcanzado = false;
                    evaluacion.equipoObjetvo = o;
                }

                evaluaciones.Add(evaluacion);
            });
        });

        return evaluaciones;
    }

    public List<Evaluacion> ObtenerEvaluacionDeUnEmpleadoParaUnPeriodoYUnEquipo(Equipo equipo, Usuario empleado, int periodo)
    {
        var objetivos = gestorDeObjetivos.ConsultarObjetivosAsignadosAUnEquipoEnUnPeriodo(equipo, periodo);
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        objetivos.ForEach((o) =>
        {
            Evaluacion evaluacion = null;

            var evaluacionesEnBase = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EVALUACION WHERE EQUIPOOBJETIVO_IDEQUIPOOBJETIVO = {0} and PERIODO = {1} AND USUARIO_IDUSUARIO = {2}", o.identificador, periodo, empleado.identificador));
            if (evaluacionesEnBase.Rows.Count > 0)
            {
                evaluacion = PopularEvaluacionDesdeBD(evaluacionesEnBase.Rows[0], o);
            }
            else
            {
                evaluacion = new Evaluacion();
                evaluacion.alcanzado = false;
                evaluacion.equipoObjetvo = o;
            }

            evaluaciones.Add(evaluacion);

        });


        return evaluaciones;
    }


    private Evaluacion PopularEvaluacionDesdeBD(DataRow evaluacionRow, EquipoObjetivo equipoObjetivo)
    {
        Evaluacion evaluacion = new Evaluacion();
        evaluacion.alcanzado = true;
        evaluacion.identificador = Convert.ToInt32(evaluacionRow["idEvaluacion"]);
        evaluacion.periodo = Convert.ToInt32(evaluacionRow["periodo"]);
        evaluacion.usuario = new Usuario() { identificador = Convert.ToInt32(evaluacionRow["Usuario_idUsuario"]) };
        evaluacion.puntaje = Convert.ToInt32(evaluacionRow["puntaje"]);

        if (equipoObjetivo == null)
        {
            equipoObjetivo = new EquipoObjetivo();
            equipoObjetivo.equipo = new Equipo() { identificador = Convert.ToInt32(evaluacionRow["idEquipo"]), nombre = Convert.ToString(evaluacionRow["nombreEquipo"]) };
            equipoObjetivo.objetivo = new Objetivo() { identificador = Convert.ToInt32(evaluacionRow["idObjetivo"]), nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(evaluacionRow["nombreObjetivo"])), puntaje = Convert.ToInt32(GestorDeEncriptacion.DesencriptarAes(Convert.ToString(evaluacionRow["puntajeObjetivo"]))) };
            equipoObjetivo.identificador = Convert.ToInt32(evaluacionRow["EquipoObjetivo_idEquipoObjetivo"]);
        }
        evaluacion.equipoObjetvo = equipoObjetivo;

        return evaluacion;
    }

    public List<Object[]> ObtenerEvaluacionDeUnEquipoParaUnPeriodo(Equipo equipo, int periodo)
    {

        var objetivosAsignadosAUnEquipoEnUnPeriodo = gestorDeObjetivos.ConsultarObjetivosAsignadosAUnEquipoEnUnPeriodo(equipo, periodo);
        var puntajeTotalDeObjetivos = 0;
        objetivosAsignadosAUnEquipoEnUnPeriodo.ForEach(obj =>
        {
            puntajeTotalDeObjetivos = puntajeTotalDeObjetivos + obj.objetivo.puntaje;
        });

        DataTable equipoempleadoTable = baseDeDatos.ConsultarBase(String.Format("select usuario.idUsuario, usuario.nombreUsuario from equipoempleado inner join usuario on usuario.idUsuario = equipoempleado.Usuario_idUsuario where equipoempleado.Equipo_idEquipo = {0} and usuario.habilitado = 1 and (periodoFin is null or periodoFin >= {1}) AND periodoInicio <= {1}", equipo.identificador, periodo));
        List<Usuario> empleadosAsignados = new List<Usuario>();
        foreach (DataRow equipoEmpleado in equipoempleadoTable.Rows)
        {
            Usuario usuario = new Usuario() { identificador = Convert.ToInt32(equipoEmpleado["idUsuario"]), nombreUsuario = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(equipoEmpleado["nombreUsuario"])) };
            empleadosAsignados.Add(usuario);
        }

        List<Object[]> evaluacionesDeUsuario = new List<object[]>();
        empleadosAsignados.ForEach(u =>
        {
            var puntajeObtenidoEvaluaciones = 0;
            objetivosAsignadosAUnEquipoEnUnPeriodo.ForEach(obj =>
            {
                var evaluacionesEnBase = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EVALUACION WHERE EQUIPOOBJETIVO_IDEQUIPOOBJETIVO = {0} and PERIODO = {1} AND USUARIO_IDUSUARIO = {2}", obj.identificador, periodo, u.identificador));
                if (evaluacionesEnBase.Rows.Count > 0)
                {
                    puntajeObtenidoEvaluaciones = puntajeObtenidoEvaluaciones + Convert.ToInt32(evaluacionesEnBase.Rows[0]["puntaje"]);
                }
            });

            var porcentajeCumplimiento = puntajeObtenidoEvaluaciones * 100 / puntajeTotalDeObjetivos;
            evaluacionesDeUsuario.Add(new object[] { u.nombreUsuario, porcentajeCumplimiento });
        });

        return evaluacionesDeUsuario;
    }

    public List<Evaluacion> ObtenerEvaluacionesDeUnObjetivo(Objetivo objetivo)
    {

        return null;
    }

}