using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Collections;

namespace UnionWebApi.Models
{
    public class Funciones
    {
        public static DataTable ExecuteDataTable(string pName, params Object[] args)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            DbCommand command = db.GetStoredProcCommand(pName, args);
            command.CommandTimeout = 0;
            DataTable dt = new DataTable();
            dt.Load(db.ExecuteReader(command));
            return dt;
        }
        public static DataTable ExecuteDataTableWithIdentity(string pName,ref int pIntOutput,params object[] args)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            DbCommand command = db.GetStoredProcCommand(pName, args);
            DataTable dt = new DataTable();
            dt.Load(db.ExecuteReader(command));
            pIntOutput= int.Parse(db.GetParameterValue(command, command.Parameters[args.Length].ParameterName).ToString());
            return dt;
        }

        public static DataTable ExecuteDataTable(string pQuery)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            DataTable dt = new DataTable();
            dt.Load(db.ExecuteReader(db.GetSqlStringCommand(pQuery)));
            return dt;
        }
        public static DataSet ExecuteDataSet(string pName, params Object[] args)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            DbCommand command = db.GetStoredProcCommand(pName, args);
            command.CommandTimeout = 0;
            return db.ExecuteDataSet(command);
        }
        public static DataSet ExecuteDataSet(string pQuery)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            DbCommand command = db.GetSqlStringCommand(pQuery);
            return db.ExecuteDataSet(command);
        }
        public static int ExecuteSql(string pQuery)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            return db.ExecuteNonQuery(db.GetSqlStringCommand(pQuery));
        }
        public static int ExecuteSqlIdentity(string pName, params object[] args)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            DbCommand command = db.GetStoredProcCommand(pName, args);
            db.ExecuteNonQuery(command);
            return int.Parse(db.GetParameterValue(command, command.Parameters[args.Length].ParameterName).ToString());
        }
        public static string ExecuteSqlIdentityPK(string pName, params object[] args)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            DbCommand command = db.GetStoredProcCommand(pName, args);
            db.ExecuteNonQuery(command);
            return db.GetParameterValue(command, command.Parameters[args.Length].ParameterName).ToString();
        }
        public static int ExecuteSql(string pQuery, params Object[] args)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            return db.ExecuteNonQuery(pQuery, args);
        }
        public static object ExecuteScalar(string pQuery)
        {
            Database db = DatabaseFactory.CreateDatabase("MiConexion");
            return db.ExecuteScalar(db.GetSqlStringCommand(pQuery));
        }
        public static bool ExecuteExisteEnBD(string pQuery)
        {
            return ExecuteScalar(pQuery) != null;
        }
        public static bool IsFecha(string cadenaFecha)
        {
            DateTime fechaTemp;
            return DateTime.TryParse(cadenaFecha, out fechaTemp);
            //var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
            //return DateTime.TryParseExact(cadenaFecha, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaTemp);
        }
        public static bool IsNumeric(string pNumero)
        {
            int x;
            if (int.TryParse(pNumero, out x)) return true;
            return false;
        }
        public static bool IsDouble(string pNumero)
        {
            double x;
            if (double.TryParse(pNumero, out x)) return true;
            return false;
        }
        public static bool IsTimeSpan(string pHHMM)
        {
            TimeSpan x;
            if (TimeSpan.TryParse(pHHMM, out x)) return true;
            return false;
        }
        public static DataTable TablaSegunNumeroDeFilas(int pNumeroFilas)
        {
            return ExecuteDataTable("select * from dbo.FN_CREA_TABLA_FILAS(" + pNumeroFilas.ToString() + ")");
        }
        public static void CallJavaScript(Page pPage, string pNombreARegistrar, string pJavascriptCodigo)
        {
            pPage.ClientScript.RegisterStartupScript(pPage.GetType(), pNombreARegistrar, pJavascriptCodigo, true);
        }

        public static void chkListLlenaValoresConDT(DataTable pDT, ref CheckBoxList pchkl, string pValue, string pTextField)
        {
            pchkl.DataSource = pDT;
            pchkl.DataTextField = pTextField;
            pchkl.DataValueField = pValue;
            pchkl.DataBind();
        }
        public static void rblListLlenaValoresConDT(DataTable pDT, ref RadioButtonList pchkl, string pValue, string pTextField)
        {
            pchkl.DataSource = pDT;
            pchkl.DataTextField = pTextField;
            pchkl.DataValueField = pValue;
            pchkl.DataBind();
        }
        public static void rblListLlenaValoresConEnum(System.Type pTipo, ref RadioButtonList pchkl)
        {
            Array values = Enum.GetValues(pTipo);
            SortedList ht = new SortedList();
            for (int i = 0; i < values.Length; i++)
            {
                ht.Add(values.GetValue(i).GetHashCode(), values.GetValue(i).ToString().Replace('_', ' '));
            }
            pchkl.DataSource = ht;
            pchkl.DataTextField = "value";
            pchkl.DataValueField = "key";
            pchkl.DataBind();
        }
        public static void DDLLlenaValoresConDT(DataTable pDT, ref DropDownList pDdl, string pValue, string pTextField)
        {
            pDdl.DataSource = pDT;
            pDdl.DataTextField = pTextField;
            pDdl.DataValueField = pValue;
            pDdl.DataBind();
        }
        public static void DDLLlenaValoresConDT(DataTable pDT, ref DropDownList pDdl, string pValue, string pTextField, string pTextIndex0)
        {
            pDdl.DataSource = pDT;
            pDdl.DataTextField = pTextField;
            pDdl.DataValueField = pValue;
            pDdl.DataBind();
            if (!string.IsNullOrEmpty(pTextIndex0)) pDdl.Items.Insert(0, new ListItem(pTextIndex0, string.Empty));
        }
        public static void DDLLlenaValoresConDT(DataTable pDT, ref DropDownList pDdl, string pValue, string pTextField, string pTextIndex0, string pPk,string pText)
        {
            pDdl.DataSource = pDT;
            pDdl.DataTextField = pTextField;
            pDdl.DataValueField = pValue;
            pDdl.DataBind();
            pDdl.Items.Insert(0, new ListItem(pPk, pText));
            if (!string.IsNullOrEmpty(pTextIndex0)) pDdl.Items.Insert(0, new ListItem(pTextIndex0, string.Empty));
        }
        public static void DDLLlenaValoresConEnum(System.Type pTipo, ref DropDownList pDdl, string pTextIndex0)
        {
            Array values = Enum.GetValues(pTipo);
            SortedList ht = new SortedList();
            for (int i = 0; i < values.Length; i++)
            {
                ht.Add(values.GetValue(i).GetHashCode(), values.GetValue(i).ToString().Replace('_', ' '));
            }
            pDdl.DataSource = ht;
            pDdl.DataTextField = "value";
            pDdl.DataValueField = "key";
            pDdl.DataBind();
            if (!string.IsNullOrEmpty(pTextIndex0)) pDdl.Items.Insert(0, new ListItem(pTextIndex0, string.Empty));
        }



        public static void DDLLlenaValoresConNumeros(int pMax, ref DropDownList pDdl, string pTextIndex0, bool pDesdeCero = false)
        {
            int x = 1;
            if (pDesdeCero) x = 0;
            pDdl.Items.Clear();
            for (int i = x; i <= pMax; i++)
            {
                pDdl.Items.Add(i.ToString());
            }
            if (!string.IsNullOrEmpty(pTextIndex0)) pDdl.Items.Insert(0, new ListItem(pTextIndex0, string.Empty));
        }
        public static string BuscaUnTextoEntreDosCadenas(string pTextoBase, string pTextoInicio, string pTextoTermino)
        {
            int auxPosicionInicial, auxPosicionFinal;
            auxPosicionInicial = pTextoBase.IndexOf(pTextoInicio);
            string auxTextoBaseFinal = pTextoBase.Substring(auxPosicionInicial + pTextoInicio.Length);
            auxPosicionFinal = auxTextoBaseFinal.IndexOf(pTextoTermino);
            return pTextoBase.Substring(auxPosicionInicial + pTextoInicio.Length, auxPosicionFinal);
        }
        public static void AsignarDesdeDr(ref int obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = int.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref long obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = long.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref string obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = dr[pNombreCampo].ToString();
        }
        public static void AsignarDesdeDr(ref DateTime obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = DateTime.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref TimeSpan obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = TimeSpan.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref float obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = float.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref double obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = double.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref bool obj, DataRow dr, string pNombreCampo)
        {
            //If Not dr.IsNull(pNombreCampo) Then obj = IIf(dr(pNombreCampo) = 0, True, False)
            if (!dr.IsNull(pNombreCampo))
                obj = bool.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDrParaBoolean(ref bool obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj = bool.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref tFecha obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj.Fecha = DateTime.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref tTimeSpan obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj.TimeSpan = TimeSpan.Parse(dr[pNombreCampo].ToString());
        }
        public static void AsignarDesdeDr(ref tPeso obj, DataRow dr, string pNombreCampo)
        {
            if (!dr.IsNull(pNombreCampo))
                obj.CLP = double.Parse(dr[pNombreCampo].ToString());
        }
        //public static void AsignarDesdeDr(ref char obj, DataRow dr, string pNombreCampo)
        //{
        //    if (!dr.IsNull(pNombreCampo))
        //        obj = Convert.ToChar(dr[pNombreCampo].ToString());
        //      //  obj = char.Parse(dr[pNombreCampo].ToString());
        //}
        //public static void AsignarDesdeDr(ref Enum obj, Type tipo, DataRow dr, string pNombreCampo)
        //{
        //    if (!dr.IsNull(pNombreCampo))
        //        obj = (Enum)Enum.Parse(tipo, dr[pNombreCampo].ToString(), true);
        //}

        public static void fgError(string pMensaje)
        {
            throw new Exception(pMensaje);
        }

        private static String fgStrSql(string pValue, string pTipo)
        {
            if (String.IsNullOrEmpty(pValue))
                return "null";
            string aux = string.Empty;
            string retorno = string.Empty;
            switch (pTipo)
            {
                case "T":
                    aux = pValue;
                    aux = aux.ToUpper();
                    aux = aux.Replace("Á", "A");
                    aux = aux.Replace("É", "E");
                    aux = aux.Replace("Í", "I");
                    aux = aux.Replace("Ó", "O");
                    aux = aux.Replace("Ú", "U");
                    aux = aux.Replace("Ü", "U");
                    retorno = "'" + aux.Replace("'", "''") + "'";
                    break;
                case "TSM":
                    aux = pValue;
                    aux = aux.ToUpper();
                    aux = aux.Replace("Á", "A");
                    aux = aux.Replace("É", "E");
                    aux = aux.Replace("Í", "I");
                    aux = aux.Replace("Ó", "O");
                    aux = aux.Replace("Ú", "U");
                    aux = aux.Replace("Ü", "U");
                    retorno = "'" + aux.Replace("'", "''") + "'";
                    break;
                case "N":
                    retorno = pValue.Replace(",", ".");
                    break;
                case "I":
                    if (int.Parse(pValue) == 0)
                        retorno = "null";
                    retorno = pValue;
                    break;
                case "B":
                    if (bool.Parse(pValue))
                        retorno = "0";
                    retorno = "1";
                    break;
                case "EB":
                    Funciones.eBoolean auxBoolean = (Funciones.eBoolean)Enum.Parse(typeof(Funciones.eBoolean), pValue);
                    if (auxBoolean == Funciones.eBoolean.Nulo)
                        retorno = "null";
                    retorno = ((int)auxBoolean).ToString();
                    break;
                default:
                    Funciones.fgError("El tipo no está definido para la función fg_StrSql");
                    break;
            }
            return retorno;
        }
        public static string fgStrSql2(string pValue, eTipoDatoSql pTipo)
        {
            string retorno = string.Empty;
            switch (pTipo)
            {
                case eTipoDatoSql.Booleano:
                    retorno = fgStrSql(pValue, "B");
                    break;
                case eTipoDatoSql.TextoSinConvertirAMayusculas:
                    retorno = fgStrSql(pValue, "TSM");
                    break;
                case eTipoDatoSql.BooleanoConNull:
                    retorno = fgStrSql(pValue, "EB");
                    break;
                case eTipoDatoSql.Id:
                    retorno = fgStrSql(pValue, "I");
                    break;
                case eTipoDatoSql.Numerico:
                    retorno = fgStrSql(pValue, "N");
                    break;
                case eTipoDatoSql.TextoNull:
                    retorno = fgStrSql(pValue, "T");
                    break;
                case eTipoDatoSql.Texto:
                    string aux = fgStrSql(pValue, "T");
                    retorno = aux == "null" ? "''" : aux;
                    break;
                case eTipoDatoSql.TextoSinComillas:
                    retorno = fgStrSql(pValue, "T").Replace("'", "");
                    break;
            }
            return retorno;
        }

        enum eBoolean
        {
            Nulo = -1,
            Verdadero = 0,
            Falso = 1
        }

        public enum eTipoDatoSql
        {
            Texto,
            TextoNull,
            TextoSinComillas,
            TextoSinConvertirAMayusculas,
            Id,
            Booleano,
            BooleanoConNull,
            Numerico
        }

        public struct tFecha
        {
            private DateTime _Fecha;
            private bool _Seteada;

            public enum eUnidadFecha
            {
                Mes,
                Año,
                Dia,
                Semana
            }
            public enum eDia
            {
                Lunes = 1,
                Martes = 2,
                Miercoles = 3,
                Jueves = 4,
                Viernes = 5,
                Sabado = 6,
                Domingo = 7,
            }
            public enum eMes
            {
                Enero = 1,
                Febrero = 2,
                Marzo = 3,
                Abril = 4,
                Mayo = 5,
                Junio = 6,
                Julio = 7,
                Agosto = 8,
                Septiembre = 9,
                Octubre = 10,
                Noviembre = 11,
                Diciembre = 12
            }
            public eDia DiaDeLaSemana
            {
                get
                {
                    int i = (int)this._Fecha.DayOfWeek;
                    i = (i == 0 ? 7 : i);
                    return (eDia)i;
                }
            }
            public int NumeroSemanaEnAno
            {
                get
                {
                    GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
                    return cal.GetWeekOfYear(this._Fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                }
            }
            public DateTime Fecha
            {
                get
                {
                    return this._Fecha;
                }
                set
                {
                    this._Fecha = value;
                    this._Seteada = true;
                }
            }
            public int Weeks(int year, int month)
            {
                DayOfWeek wkstart = DayOfWeek.Monday;

                DateTime first = new DateTime(year, month, 1);
                int firstwkday = (int)first.DayOfWeek;
                int otherwkday = (int)wkstart;

                int offset = ((otherwkday + 7) - firstwkday) % 7;

                double weeks = (double)(DateTime.DaysInMonth(year, month) - offset) / 7d;

                return (int)Math.Ceiling(weeks);
            }
            public int NumeroSemanaEnMes()
            {
                DateTime tempdate = this._Fecha.AddDays(-this._Fecha.Day + 1);

                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int weekNumStart = ciCurr.Calendar.GetWeekOfYear(tempdate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                int weekNum = ciCurr.Calendar.GetWeekOfYear(this._Fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                tFecha auxFecha = new tFecha(this._Fecha);
                if ((int)auxFecha.DiaDeLaSemana == 7) //si es domingo
                {
                    auxFecha.Sumar(eUnidadFecha.Dia, 1);
                    if (weekNum + 1 == ciCurr.Calendar.GetWeekOfYear(auxFecha.Fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                    {
                        weekNum += 1;
                    }
                }
                return weekNum - weekNumStart + 1;

            }
            public tFecha(DateTime pFecha)
            {
                this._Fecha = pFecha;
                this._Seteada = true;
            }
            public string ToSql()
            {
                if (this._Seteada) return "'" + this._Fecha.ToString("yyyy-MM-dd") + " 00:00:00.000'";
                return "NULL";
            }
            public string ToSqlSinComillaSimple()
            {
                if (this._Seteada) return this._Fecha.ToString("yyyy-MM-dd") + " 00:00:00.000";
                return "NULL";
            }
            public tFecha PrimeroDelMes()
            {
                return new tFecha(new DateTime(this._Fecha.Year, this._Fecha.Month, 1));
            }
            public tFecha UltimoDiaDelMes()
            {
                return new tFecha(new DateTime(this._Fecha.Year, this._Fecha.Month, DateTime.DaysInMonth(this._Fecha.Year, this._Fecha.Month)));
            }

            public void Sumar(eUnidadFecha pUnidad, int pCantidad)
            {
                string tipo = string.Empty;
                switch (pUnidad)
                {
                    case eUnidadFecha.Dia:
                        tipo = "DAY";
                        // this._Fecha = new DateTime(this._Fecha.Year, this._Fecha.Month, this._Fecha.Day + pCantidad);
                        break;
                    case eUnidadFecha.Mes:
                        tipo = "MONTH";
                        //this._Fecha = new DateTime(this._Fecha.Year, this._Fecha.Month + pCantidad, this._Fecha.Day);
                        break;
                    case eUnidadFecha.Año:
                        tipo = "YEAR";
                        //  this._Fecha = new DateTime(this._Fecha.Year + pCantidad, this._Fecha.Month, this._Fecha.Day);
                        break;
                    case eUnidadFecha.Semana:
                        tipo = "WEEK";
                        //this._Fecha = new DateTime(this._Fecha.Year, this._Fecha.Month, this._Fecha.Day + pCantidad * 7);
                        break;
                }
                this._Fecha = DateTime.Parse(Funciones.ExecuteScalar("SELECT  DATEADD(" + tipo + "," + pCantidad + ", dbo.fn_fecha(" + this.ToSql() + "))").ToString());
            }

            public string MostrarPantalla()
            {
                if (!this._Seteada) return string.Empty;
                return this.MostrarPantalla("dd-MM-yyyy");
            }
            public string MostrarPantalla(string pFormato)
            {
                if (!this._Seteada) return string.Empty;
                return this.Fecha.ToString(pFormato);
            }
            public eMes Mes
            {
                get
                {
                    return (eMes)this._Fecha.Month;
                }
            }

            public string MostrarComo11deMayode2012()
            {
                if (!this.EstaSeteada) return "";
                eMes mes = (eMes)this.Fecha.Month;
                return this.Fecha.Day.ToString() + " de " + mes.ToString() + " de " + this.Fecha.Year.ToString();
            }
            public bool EstaSeteada
            {
                get { return this._Seteada; }
            }
        }

        public struct tTimeSpan
        {
            private TimeSpan _TimeSpan;
            private bool _Seteada;

            public tTimeSpan(TimeSpan pTimeSpan)
            {
                this._TimeSpan = pTimeSpan;
                this._Seteada = true;
            }
            //public tTimeSpan(Boolean pSiempreSinSetear=true)
            //{
            //    this._TimeSpan = TimeSpan.Zero;
            //    this._Seteada =false;
            //}
            //public string ToSql()
            //{
            //    if (this._Seteada) return "'" + this._Fecha.ToString("yyyy-MM-dd") + " 00:00:00.000'";
            //    return "NULL";
            //}
            //public string ToSqlSinComillaSimple()
            //{
            //    if (this._Seteada) return this._Fecha.ToString("yyyy-MM-dd") + " 00:00:00.000";
            //    return "NULL";
            //}
            public TimeSpan TimeSpan
            {
                get
                {
                    return this._TimeSpan;
                }
                set
                {
                    this._TimeSpan = value;
                    this._Seteada = true;
                }
            }
            public string MostrarPantalla()
            {
                if (!this._Seteada) return string.Empty;
                return this.MostrarPantalla(@"hh\:mm");
            }
            public string MostrarPantalla(string pFormato)
            {
                if (!this._Seteada) return string.Empty;
                return this._TimeSpan.ToString(pFormato);
            }
            public bool EstaSeteada
            {
                get { return this._Seteada; }
            }
        }
        public struct tPeso
        {
            private double _CLP;
            private bool _Seteada;

            public double CLP { get { return this._CLP; } set { this._CLP = value; } }
            public bool EstaSeteada { get { return this.EstaSeteada == true; } }

            public tPeso(string pNumber)
            {
                this._CLP = double.Parse(pNumber);
                this._Seteada = true;
            }
            public tPeso(int pNumber)
            {
                this._CLP = pNumber;
                this._Seteada = true;
            }

            public string MostrarPantalla(bool pMostrarTipoMoneda = false, bool pStringVacioSiEsCero = false)
            {
                if (this.CLP == 0 && pStringVacioSiEsCero) return string.Empty;
                return (pMostrarTipoMoneda) ? "$" : string.Empty + this.CLP.ToString("#,##0");
            }
            // Public Function MostrarPantallaConDecimales() As String
            //        Return Me.CLP.ToString("#,###.##")
            //    End Function
        }

        public static string Left(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }
        public static string Right(string param, int length)
        {
            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }
        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        public struct tRUT
        {
            private string _cuerpo;
            public string digito;
            public string Cuerpo
            {
                get { return this._cuerpo; }
                set
                {
                    if (value.Length <= 1) return;
                    this._cuerpo = value;
                }
            }
            public string Completo
            {
                get
                {
                    string aux = this.Cuerpo + "-" + this.digito;
                    if (aux == "-") return string.Empty;
                    return aux;
                }
                set
                {
                    string aux = value.Replace(".", "");
                    if (aux.Length >= 8)
                    {
                        Cuerpo = Left(aux, 2);
                        digito = Right(aux, 1).ToUpper();
                        if (!this.EsValido())
                        {
                            Cuerpo = string.Empty;
                            digito = string.Empty;
                        }
                    }
                }
            }

            public tRUT(string pRutCompleto)
            {
                this._cuerpo = "";
                this.digito = "";
                this.Completo = pRutCompleto;
            }

            public bool EsValido()
            {
                int sum = 0;
                int mul = 2;
                for (int i = this.Cuerpo.Trim().Length; i == 0; i--)
                {
                    sum += Convert.ToInt32(Mid(this.Cuerpo, i, 1)) * mul;
                    mul = mul == 7 ? 2 : mul + 1;
                }
                int dvr = 11 - (sum % 11);
                string str = dvr.ToString();
                if (dvr == 10)
                    str = "K";
                else if (dvr == 11)
                    str = "0";
                if (str.ToUpper() == this.digito.ToUpper())
                    return true;
                return false;
            }
            public string MostrarPantalla()
            {
                if (string.IsNullOrEmpty(this.Completo)) return string.Empty;
                return double.Parse(this.Cuerpo).ToString("#,###") + "-" + this.digito;
            }
        }

        public static DataTable EnumToDT(System.Type pEnum)
        {
            string[] Nombres = Enum.GetNames(pEnum);
            int[] Valores = (int[])Enum.GetValues(pEnum);
            DataTable dt = new DataTable();
            dt.Columns.Add("VALORES");
            dt.Columns.Add("NOMBRES");
            DataRow dr;
            int i = 0;
            foreach (string nombre in Nombres)
            {
                dr = dt.NewRow();
                dr["NOMBRES"] = nombre.Replace("_", " ");
                dr["VALORES"] = Valores[i];
                dt.Rows.Add(dr);
                i++;
            }
            return dt;
        }
        public static string SessionIdiomaGet(System.Web.SessionState.HttpSessionState pSession)
        {
            if (pSession["myapplication.language"] == null) return "es-CL";
            return pSession["myapplication.language"].ToString();
        }
        public static void SessionIdiomaSet(System.Web.SessionState.HttpSessionState pSession, string pValue)
        {
            pSession["myapplication.language"] = pValue;
        }
        public static void DownloadFile(string pFullpath, bool pForceDownload, HttpResponse pResponse)
        {
            string name = Path.GetFileName(pFullpath);
            string ext = Path.GetExtension(pFullpath);
            string type = "";
            if (!string.IsNullOrEmpty(ext)) ext.ToLower();
            switch (ext)
            {
                case ".pdf":
                    type = "application/pdf";
                    break;
            }
            if (pForceDownload) pResponse.AppendHeader("content-disposition", "attachment; filename='" + name + "'");
            if (!string.IsNullOrEmpty(type)) pResponse.ContentType = type;
            pResponse.TransmitFile(pFullpath);
            pResponse.End();
        }
        public static void DownloadFileSinArchivoPreExistente(string pFullpath, byte[] pBytes, HttpResponse pResponse)
        {
            string name = Path.GetFileName(pFullpath);
            string ext = Path.GetExtension(pFullpath);
            string type = "";
            if (!string.IsNullOrEmpty(ext)) ext.ToLower();
            switch (ext)
            {
                case ".pdf":
                    type = "application/pdf";
                    break;
                case ".xls":
                    type = "application/excel";
                    break;
            }
            pResponse.Buffer = true;
            pResponse.Clear();
            pResponse.ContentType = type;
            pResponse.AddHeader("content-disposition", "attachment; filename=" + pFullpath);
            pResponse.BinaryWrite(pBytes); // create the file
            pResponse.Flush(); // send it to the client to download
        }
        //public static void EnviarEmail(string pCuerpo, string pAsunto, string pDestinatario, string pNombreRemitente, ref string pError)
        //{
        //    try
        //    {
        //        System.Net.Mail.SmtpClient _smpt = new System.Net.Mail.SmtpClient(cDatos.SMTPHost());
        //        // _smpt.Port = 587;
        //        _smpt.Credentials = new System.Net.NetworkCredential(cDatos.CorreoTurismo(), "advpro77");
        //        // _smpt.UseDefaultCredentials = false; 
        //        System.Net.Mail.MailMessage _Mensaje = new System.Net.Mail.MailMessage();
        //        _Mensaje.IsBodyHtml = true;
        //        _Mensaje.Body = pCuerpo;
        //        _Mensaje.From = new System.Net.Mail.MailAddress(pNombreRemitente + "<" + cDatos.CorreoTurismo() + ">");
        //        _Mensaje.Subject = pAsunto;
        //        _Mensaje.To.Add(pDestinatario);
        //       // _Mensaje.Bcc.Add(cDatos.CorreoTurismoOculto());
        //        _smpt.Send(_Mensaje);
        //        pError = "Mensaje enviado satisfactoriamente";
        //    }
        //    catch (Exception e)
        //    {
        //        pError = e.Message;
        //    }
        //}

        //  Public Sub EnviarMail(ByVal pAdjuntos() As String, ByVal pAsunto As String, ByVal pCuerpo As String, ByVal pNoEnviarA As iDireccionEMail, ByVal pDestinatarios As List(Of iDireccionEMail), ByVal ParamArray pDestinatariosAdicionales() As iDireccionEMail)
        //    Dim auxDestinatarios As New System.Text.StringBuilder
        //    If Not pDestinatarios Is Nothing Then
        //        For Each i As iDireccionEMail In pDestinatarios
        //            If fgValidaEMail(i.EMailAdress.Address) Then auxDestinatarios.Append(i.EMailAdress.Address & ";")
        //        Next
        //    End If
        //    For Each i As iDireccionEMail In pDestinatariosAdicionales
        //        If Not i Is Nothing Then
        //            If fgValidaEMail(i.EMailAdress.Address) Then auxDestinatarios.Append(i.EMailAdress.Address & ";")
        //        End If
        //    Next
        //    If pAdjuntos Is Nothing Then pAdjuntos = New String() {}
        //    If Not pNoEnviarA Is Nothing Then auxDestinatarios.Replace(pNoEnviarA.EMailAdress.Address & ";", String.Empty)
        //    If Not auxDestinatarios.Length >= 5 Then Exit Sub 'al menos 1 direccion de email
        //    Dim sb As New System.Text.StringBuilder
        //    sb.Append("exec msdb.dbo.sp_send_dbmail ")
        //    sb.AppendFormat("@file_attachments={0},@recipients={1},@subject = {2},@body = {3},@body_format = '{4}'", Funciones.fg_StrSql2(String.Join(";", pAdjuntos), eTipoDatoSql.Texto), Funciones.fg_StrSql2(auxDestinatarios.ToString, eTipoDatoSql.Texto), Funciones.fg_StrSql2(pAsunto, eTipoDatoSql.Texto), fg_StrSql2(pCuerpo, eTipoDatoSql.TextoSinConvertirAMayusculas), "HTML")
        //    Progressa.ExecuteSql(sb.ToString)
        //End Sub
        public static void EnviarEmailPorBD(string pCuerpo, string pAsunto, string pDestinatario, string pCopia, string pNombreRemitente, string pAdjunto, ref string pError)
        {
            try
            {
                string auxAdjunto = "NULL";
                string auxCopias = "NULL";
                if (!string.IsNullOrEmpty(pAdjunto)) auxAdjunto = "'" + pAdjunto + "'";
                if (!string.IsNullOrEmpty(pCopia)) auxCopias = "'" + pCopia + "'";
                StringBuilder sb = new StringBuilder();
                sb.Append("exec msdb.dbo.sp_send_dbmail ");
                sb.AppendFormat("@file_attachments={0}, @recipients='{1}', @subject ='{2}', @body ='{3}', @copy_recipients={4}, @body_format='{5}'", auxAdjunto, pDestinatario, pAsunto, pCuerpo, auxCopias, "HTML");
                ExecuteSql(sb.ToString());
            }
            catch (Exception e)
            {
                pError = e.Message;
            }
        }

        public static void EnviarEmailPorHotmailPorqueAfianzaBloqueoEnvioDeEmailxxx(string pCuerpo, string pAsunto, string pDestinatario, string pCopia, string pNombreRemitente, Attachment pAdjunto, ref string pError)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("ellempen@hotmail.com");
                mail.To.Add(pDestinatario);
                if (!string.IsNullOrEmpty(pCopia)) mail.CC.Add(pCopia);
                mail.Subject = pAsunto;
                mail.IsBodyHtml = true;
                mail.Body = pCuerpo;
                if (pAdjunto != null) mail.Attachments.Add(pAdjunto);
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("ellempen@hotmail.com", "sayamann99");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                pError = e.Message;
            }
        }

        public static void EnviarArchivoPorFTP(string pRutaArchivo, string pNombreArchivo, string pRutaFTP, ref string pErr)
        {
            string rutaynombreArchivo = pRutaArchivo + pNombreArchivo;
            Stream requestStream = null;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(pRutaFTP + pNombreArchivo);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("elmer122", "FXCGVJH45");
                byte[] fileContents = System.IO.File.ReadAllBytes(rutaynombreArchivo);
                request.ContentLength = fileContents.Length;
                requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
            }
            catch (Exception ex)
            {
                pErr = "Ocurrió un error al subir el archivo: " + ex.Message;
                return;
            }
            finally
            {
                requestStream.Close();
                System.IO.File.Delete(rutaynombreArchivo);
            }
        }

        private static byte[] StreamToByte(Stream stream)
        {
            byte[] buffer = new byte[32768];
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                int read = stream.Read(buffer, 0, buffer.Length);
                if (read <= 0) return ms.ToArray();
                ms.Write(buffer, 0, read);
            }
            ms.Close();
            return ms.ToArray();
        }
       
        public static void EliminaTodosLosArchivosDeCarpeta(string pCarpeta)
        {
            foreach (string s in Directory.GetFiles(pCarpeta))
            {
                System.IO.File.Delete(s);
            }
        }
        public enum eTipoCargamasiva
        {
            HOTEL = 1,
            HOTEL_HABITACIONES_VALOR = 2
        }
        public static bool IntToBool(int pInteger)
        {
            return (pInteger == 0);
        }
        //public static string DestinatariosReserva(cUsuario pUsuario)
        //{ 
        //    StringBuilder emails = new StringBuilder(cDatos.correoEkatours() + ";" + pUsuario.Email + ";" + pUsuario.Agencia.EmailsTodos);
        //    if(emails[emails.Length-1]==',')
        //    {
        //        emails.Remove(emails.Length - 1, 1);
        //    }
        //    return emails.ToString();
        //   // return "ellempen@hotmail.com";
        //}
        public enum eTipoReserva
        {
            HOTEL,
            PAQUETE,
            SERVICIO,
            CRUCERO
        }
        public static string ObtieneMensaje(Page pPage, string pNombreHF)
        {
            return ((HiddenField)pPage.Master.FindControl(pNombreHF)).Value;
        }
        public static string ObtieneMensajeMasterLogin(Page pPage, string pNombreHF)
        {
            return ((HiddenField)pPage.Master.FindControl(pNombreHF)).Value;
        }
        public static void SetAlertMensaje(Page pPage, string pText)
        {
            ((Label)pPage.Master.FindControl("lblAlert")).Text = pText;
        }
        public static void AdministraDivAlertReserva(Page pPage)
        {
            ((HtmlGenericControl)pPage.Master.FindControl("divAlertEnProceso")).Visible = false;
            ((HtmlGenericControl)pPage.Master.FindControl("divAlertFin")).Visible = true;
        }

        public static void SetAlertEntidad(Page pPage, eEntidad pEntidad)
        {
            ((Label)pPage.Master.FindControl("lblTipoEntidad")).Text = ((int)pEntidad).ToString();
        }
        public enum eEntidad
        {
            HOTEL = 0,
            CRUCERO = 1,
            PAQUETE = 2,
            SERVICIO = 3
        }
        public static void BorraUnAtributo(ref string pTextoBase, string pNombreAtributo)
        {
            pTextoBase = Regex.Replace(pTextoBase, pNombreAtributo + @"="".*?""", string.Empty);
            pTextoBase = Regex.Replace(pTextoBase, pNombreAtributo + "=.*?>", ">");
            pTextoBase = Regex.Replace(pTextoBase, pNombreAtributo + @"=.*?\s", String.Empty);
        }
        public static void BorraAtributosNoDeseados(ref string pTextoBase)
        {
            BorraUnAtributo(ref pTextoBase, "(size|class|id|border|width|background|bordercolor|cellspacing|cellpadding|bgcolor|align|scope|colspan)");
        }
        public static string BorrarHtmlNoDeseado(string pTextoBase)
        {
            pTextoBase = pTextoBase.Replace("<div>", string.Empty);
            pTextoBase = pTextoBase.Replace("</div>", string.Empty);
            BorrarSoloEtiquetaSinContenido(ref pTextoBase, "div");
            BorraAtributosNoDeseados(ref pTextoBase);
            return pTextoBase;
        }
        public static void BorrarEtiquetaConCierre(ref string pTextoBase, string pNombreEtiqueta)
        {
            pTextoBase = Regex.Replace(pTextoBase, "<" + pNombreEtiqueta + @".*</" + pNombreEtiqueta + ">", String.Empty);
        }
        public static void BorrarSoloEtiquetaSinContenido(ref string pTextoBase, string pNombreEtiqueta)
        {
            pTextoBase = Regex.Replace(pTextoBase, "<" + pNombreEtiqueta + "=.*?>", String.Empty);
        }
        public static void AddAsyncPostBackTriggerParaEventoOutSide(MasterPage pMaster, string pUniqueId, string pEvento)
        {
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = pUniqueId;
            trigger.EventName = pEvento;
            ((UpdatePanel)pMaster.FindControl("UpdatePanelContent")).Triggers.Add(trigger);
        }
        public static void AddPostBackTriggerParaEventoInSide(MasterPage pMaster, string pUniqueId)
        {
            PostBackTrigger trigger = new PostBackTrigger();
            trigger.ControlID = pUniqueId;
            ((UpdatePanel)pMaster.FindControl("UpdatePanelContent")).Triggers.Add(trigger);
        }
        public static string PrimeraLetraMayuscula(string pText)
        {
            return pText[0].ToString().ToUpper() + pText.Substring(1).ToLower();
        }

        public static string NumeroALetras(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + NumeroALetras(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + NumeroALetras(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + NumeroALetras(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + NumeroALetras(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + NumeroALetras(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }
        //esto funciona en el servidor , asi q no alugar
     

        }
    }

