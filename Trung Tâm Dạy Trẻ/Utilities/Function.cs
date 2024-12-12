using System.Text;
namespace Trung_Tâm_Dạy_Trẻ.Utilities
{
    public class Function
    {
        public static string? TittleGenerationAlias(string tittle)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(tittle);
        }
    }
}
