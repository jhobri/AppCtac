namespace Back.Ctac.Transversal.Functions
{
    public static class FuncionesComunes
    {
        public static bool EsPrimerPeriodo(string periodoActualCode)
        {
            var ValorMaximo = 0;
            var periodoActualEnNumero = Convert.ToInt32(periodoActualCode.Substring(1, 1));
            if (periodoActualEnNumero == 1)
            {
                return true;
            }
            return false;
        }

        public static bool EsMismoPeriodo(string periodoIe, string periodoUsuario)
        {
            if (periodoIe == periodoUsuario)
            {
                return true;
            }
            return false;
        }

        public static string PeriodoPromocionalAliasToDb(string periodoPromocionalUsuario)
        {
            if (periodoPromocionalUsuario == "A") return "ANUAL";
            if (periodoPromocionalUsuario == "S1") return "Promocional/Atención I";
            if (periodoPromocionalUsuario == "S2") return "Promocional/Atención II";
            return "X";
        }

        public static bool EsMismoPeriodoPromocional(string periodoPromocionalIe, string periodoPromocionalUsuario)
        {
            if (periodoPromocionalIe == periodoPromocionalUsuario)
            {
                return true;
            }
            return false;
        }
        public static string PeriodoEvaluacionAliasToDb(string periodoEvaluacionDB, int periodoEvaluacionUsuario)
        {
            var periodoActualEnTipo = periodoEvaluacionDB.Substring(0, 1);
            //  var periodoActualEnNumero = Convert.ToInt32(periodoEvaluacionDB.Substring(1, 1));
            var pe = PeriodoEvaluacionAliasToPeriodoEvaluacion(periodoActualEnTipo, periodoEvaluacionUsuario);
            return pe;
        }

        public static string PeriodoEvaluacionAliasToPeriodoEvaluacion(string tipo, int valor)
        {
            return $"{tipo}{valor}";
        }
    }
}