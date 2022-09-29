using API.Enums;

namespace API.Extensions
{
    public static class EnumExtension
    {
        public static string GetDocumentKey(this AccountDocuments document)
        {
            return (int)document switch
            {
                1 => "INVOICE",
                2 => "GOOD_RECIPT",
                _ => "",
            };
        }
    }
}
