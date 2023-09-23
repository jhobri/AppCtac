namespace Back.Ctac.Transversal.Constants
{
    //public class ConstantesFase
    //{
    //    public const string FASE_REGULAR = "01";
    //    public const string FASE_RECUPERACION = "02";
    //}
    public class MotivoRectificacion
    {
        public const short ACTUALIZAR_CALIFICACION_ESTUDIANTE = 3;// VALIDAR NOTA EN FASE REGULAR
        public const short RECTIFICAR_CALIFICACION_AREA_CARGO = 6;// VALIDAR NOTA EN FASE REGULAR

        public const short REGULARIZAR_TRASLADO_ESTUDIANTE = 7;// NO SE VALIDA NOTA EN FASE REGULAR
        public const short ELIMINAR_RETIRO_ESTUDIANTE = 9;// SI EXISTE NOTAS EN FASE REGULAR APLICAR VALIDACION, LO CONTRARIO NO SE VALIDA NOTA EN FASE REGULAR
                                                          //public const short RECUPERACION = 3;
    }
    public class ConstanteModalidad
    {
        public const string EBR = "01";
        public const string EBA = "03";
        public const string EBE = "04";
    }

    public class AreasExonerables
    {
        public const string RELIGION = "035";
        public const string EDUCACION_FISICA = "031";

    }
    public class TipoConsultaEstudiante
    {
        public const short GESTION_AUTORIZACION = 1;
        public const short GESTION_EVALUACION = 2;

    }

    public class TipoEvaluacion
    {
        public const short REGULAR = 1;
        public const short POSTERGACION = 2;
        public const short RECTIFICACION = 3;//SE REFIERE RECTIFICACION DE ACTA FINAL


        /*public const short RECTIFICACION_RECUPERACION = 4;
        public const short RECTIFICACION_POSTERGACION = 6;
        public const short RECTIFICACION_SUBSANACION = 7;
        public const short RECTIFICACION_PROMOCION_GUIDA = 8;
        */
        public const short RECUPERACION = 9;

    }
    public class TipoAutorizacionEvaluacion
    {
        public const short EVALUAR_EN_MISMA_IE = 1;
        public const short EVALUAR_DE_IE_EXTERNO = 2;
        public const short EVALUAR_POR_IE_EXTERNO = 3;

    }
    public class TipoMigracion
    {

        public const short RECTIFICACION = 3;
    }
    public class TipoRegistroEvaluacion
    {
        public const short NotasPorPeriodo = 0;
        public const short NotasFinales = 1;

    }
    public class TipoProcesamientoEvaluacion
    {
        public const short POR_GRADO = 1;
        public const short POR_SECCION = 2;


    }

    public class Fase
    {
        public const string REGULAR = "01";
        public const string RECUPERACION = "02";


    }
    //public class ConstanteEstadoCierreIe
    //{
    //    public const short SinCierre = 0;
    //    public const short ConCierre = 1;
    //}

    //public class ConstanteEstadoPeriodo
    //{
    //    public const short SinEvaluacion = 0;
    //    public const short EnEvaluacion = 1;
    //    public const short Cerrado = 2;
    //}

    public class EstadoProceso
    {
        //public const short SinProceso = 0;
        //public const short EnProceso = 1;
        public const short Habilitado = 1;
        public const short CierreAnual = 2;
    }
    //public class EstadoEvaluacion
    //{
    //    public const short SinEvaluacion = 0;
    //    public const short EnEvaluacion = 1;
    //    public const short Cerrado = 2;
    //    public const short CierreAnual = 3;
    //}
    public class TipoArea
    {
        public const string OFICIAL = "001";
        public const string TALLER = "002";
        public const string TRANSVERSAL = "003";
        public const string COMPETENCIA_NO_ASOCIADO = "004";

    }

    public class ConstanteGrado
    {
        /*
        public const string   = "01"	//0 a 2 años                    
        public const string   = "02"	//3 años                        
        public const string   = "02"	//Grupo único de 3 a 5 años     
        public const string   = "03"	//4 años                        
        public const string   = "03"	//Grupo 3 años                  
        public const string   = "04"	//5 años                        
        public const string   = "04"	//Grupo 4 años                                         
        public const string   = "05"	//3 a 5 años                    
        public const string   = "05"	//Grupo 5 años                  
            */

        public const string PrimeroPrimaria = "04"; //PRIMERO   
        public const string SegundoPrimaria = "05"; //SEGUNDO                       
        public const string TerceroPrimaria = "06"; //TERCERO                       
        public const string CuartoPrimaria = "07";  //CUARTO                        
        public const string QuintoPrimaria = "08";  //QUINTO                        
        public const string SextoPrimaria = "09";   //SEXTO                         

        public const string Primero = "10"; //PRIMERO                       
        public const string Segundo = "11"; //SEGUNDO                       
        public const string Tercero = "12"; //TERCERO                       
        public const string Cuarto = "13";  //CUARTO                        
        public const string Quinto = "14";  //QUINTO
    }

    public class ConstanteNivel
    {
        public const string InicialCuna = "A1";                     // Inicial Cuna
        public const string InicialJardin = "A2";                   // Inicial - Jardín
        public const string InicialCunaJardin = "A3";               // Inicial - Cuna-Jardín
        public const string InicialProgramaNoEscolarizado = "A5";   // Inicial Prog No Escolariz
        public const string Primaria = "B0";                        // Primaria
        public const string PrimariaAdultos = "C0";                 // Primaria de Adultos
        public const string Secundaria = "F0";                      // Secundaria
        public const string SecundariaAdultos = "G0";               // Secundaria de Adultos

    }
}
