namespace BimKrav.Server.Tables.Undecided;

public partial class ViewMasterkravwithifcclass
{
    public int IdPset { get; set; }
    public int IdProperty { get; set; }
    public int IdElement { get; set; }
    public string DisiplinKode { get; set; }
    public string PsetName { get; set; }
    public string PsetDescription { get; set; }
    public string PropertyName { get; set; }
    public string IfcPropertyType { get; set; }
    public string RevitPropertyType { get; set; }
    public string PropertyGroup { get; set; }
    public sbyte Skisseprosjekt { get; set; }
    public sbyte Forprosjekt { get; set; }
    public sbyte Detaljprosjekt { get; set; }
    public sbyte Arbeidstegning { get; set; }
    public sbyte Overlevering { get; set; }
    public string Ifcclass { get; set; }
}