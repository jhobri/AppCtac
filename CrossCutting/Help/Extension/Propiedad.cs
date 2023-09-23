using Back.Ctac.Dto.Common;
using Back.Ctac.Transversal.Functions;
using ClosedXML.Excel;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Transversal.Extension
{
    public static class Propiedad
    {
        public static void ProtectNotaPeriodo(this XLWorkbook workbook, ExcelConfiguracionDto excelConfig)
        {
            workbook.Properties.Author = excelConfig.WorkBookAuthor;
            workbook.Properties.Company = excelConfig.WorkBookCompany;
            workbook.Properties.Title = excelConfig.WorkBookTitle;
            workbook.Properties.Category = excelConfig.WorkBookCategoryModeP;
            workbook.Properties.Subject = excelConfig.WorkBookSubjet;
            workbook.Properties.Keywords = excelConfig.WorkBookTag;
            workbook.Protect(true, false, excelConfig.WorkBookPassword);
        }

        public static List<MessageStatusResponse> ValidaPropiedadExcel(this XLWorkbook workbook, ExcelConfiguracionDto excelConfig)
        {
            var validations = new List<MessageStatusResponse>();

            if (workbook.Properties.Subject != excelConfig.WorkBookSubjet && workbook.Properties.Keywords != excelConfig.WorkBookTag)
            {
                validations.Add(Utils.GetMessageResponse("El archivo cargado no fue creado por el SIAGIE."));
                return validations;
            }

            if (!workbook.IsPasswordProtected)
            {
                validations.Add(Utils.GetMessageResponse("El archivo cargado no fue creado por el SIAGIE."));
                return validations;
            }
            return validations;
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
            }

            return current == maximo;


        }

    }
}
