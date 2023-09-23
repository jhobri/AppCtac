using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Transversal.Functions
{
    public static class Utils
    {
        public static string Trim(string valor)
        {
            return valor?.Trim();
        }
        public static string TrimCustom(this string valor)
        {
            return valor?.Trim();
        }
        public static string TrimUpper(this string valor)
        {
            return valor?.Trim().ToUpper();
        }
        public static MessageStatusResponse GetMessageResponse(string msj, string msjOptional = "")
        {
            if (string.IsNullOrEmpty(msjOptional))
                return new MessageStatusResponse(message: msj, code: "00");
            else
                return new MessageStatusResponse(message: string.Format("{0} {1}", msj, msjOptional), code: "00");
        }

        public static int GetLimitePeriodo(this string pPeriodo)
        {
            if (string.IsNullOrEmpty(pPeriodo) || pPeriodo.Trim().Length != 2)
                return 0;

            char[] periodos = pPeriodo.ToCharArray();
            string tipo = periodos[0].ToString();
            int maximoIndex = 0;
            switch (tipo.TrimUpper())
            {
                case "B":
                    maximoIndex = 4;
                    break;
                case "T":
                    maximoIndex = 3;
                    break;
                case "S":
                    maximoIndex = 2;
                    break;
                case "A":
                    maximoIndex = 1;
                    break;
            }

            return maximoIndex;
        }
        public static (int, string) GetMaximoPeriodo(this string pPeriodo)
        {
            if (string.IsNullOrEmpty(pPeriodo) || pPeriodo.Trim().Length != 2)
                return (0, string.Empty);

            char[] periodos = pPeriodo.ToCharArray();
            string tipo = periodos[0].ToString();
            int maximoIndex = 0;
            switch (tipo.TrimUpper())
            {
                case "B":
                    maximoIndex = 4;
                    break;
                case "T":
                    maximoIndex = 3;
                    break;
                case "S":
                    maximoIndex = 2;
                    break;
                case "A":
                    maximoIndex = 1;
                    break;
            }

            return (maximoIndex, tipo);
        }
        public static bool EsUltimoPeriodo(string pPeriodo)
        {

            char[] periodos = pPeriodo.ToCharArray();
            int current = int.Parse(periodos[1].ToString());
            int maximo = 0;
            switch (periodos[0].ToString().TrimUpper())
            {
                case "B":
                    maximo = 4;
                    break;
                case "T":
                    maximo = 3;
                    break;
                case "S":
                    maximo = 2;
                    break;
                case "A":
                    maximo = 1;
                    break;
            }

            return current == maximo;


        }
        public static (int, string) GetIndexPeriodoAndTipo(this string pPeriodo)
        {
            if (string.IsNullOrEmpty(pPeriodo) || pPeriodo.Trim().Length != 2)
                return (0, "");

            char[] periodos = pPeriodo.Trim().ToCharArray();
            string tipo = periodos[0].ToString();
            int index = int.Parse(periodos[1].ToString());
            return (index, tipo);
        }

    }
}