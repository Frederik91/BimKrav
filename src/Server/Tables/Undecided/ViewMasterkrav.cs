namespace BimKrav.Server.Tables.Undecided;

public class ViewMasterkrav
{
    public int IdPset { get; set; }
    public int IdProperty { get; set; }
    public int IdElement { get; set; }
    public string DisciplineCode { get; set; }
    public string PsetName { get; set; }
    public string PropertyName { get; set; }
    public string TypeInstans { get; set; }
    public string IfcPropertyType { get; set; }
    public string RevitPropertyType { get; set; }
    public string PropertyGroup { get; set; }
    public string RevitElement { get; set; }
    public sbyte Skisseprosjekt { get; set; }
    public sbyte Forprosjekt { get; set; }
    public sbyte Detaljprosjekt { get; set; }
    public sbyte Arbeidstegning { get; set; }
    public sbyte Overlevering { get; set; }
}