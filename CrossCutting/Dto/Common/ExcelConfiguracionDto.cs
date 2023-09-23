namespace Back.Ctac.Dto.Common;

public class ExcelConfiguracionDto
{
    public string Path { get; set; }

    /// <summary>
    /// 1: INDICA GENERAR EL ARCHIVO EN EL DIRECTORIO DEL SERVER
    /// 0: INDICA GENERA SOLO EN LA MEMORIA
    /// </summary>
    public short GenerarEnServer { get; set; }
    public string WorkBookPassword { get; set; }
    public string WorkSheetPassword { get; set; }
    public string WorkBookAuthor { get; set; }
    public string WorkBookCompany { get; set; }
    public string WorkBookTitle { get; set; }
    public string WorkBookCategoryModeP { get; set; }
    public string WorkBookCategoryModeA { get; set; }
    public string WorkBookCategoryModeF { get; set; }
    public string WorkBookCategoryModeAAnt { get; set; }
    public string WorkBookTag { get; set; }
    public string WorkBookSubjet { get; set; }

    public string PlantillaExcel { get; set; }


    public int CaracterMinimoExcelNotaAnual { get; set; }
    public int CaracterMaximoExcelNotaAnual { get; set; }
    public int CaracterMinimoExcelNotaFinal { get; set; }
    public int CaracterMaximoExcelNotaFinal { get; set; }
    public int CaracterMinimoExcelNotaPeriodo { get; set; }
    public int CaracterMaximoExcelNotaPeriodo { get; set; }
    public int CaracterMinimoExcelNotaFinal2020 { get; set; }
    public int CaracterMaximoExcelNotaFinal2020 { get; set; }
}
