using Abp.Reflection.Extensions;
using SKecommerce.Core.Domain;

namespace Shared.Helpers;

public static class WebContentDirectoryFinder
{
    public static string CalculateContentRootFolder()
    {
        var coreAssemblyDirectoryPath = Path.GetDirectoryName(typeof(CloudCoreModule).GetAssembly().Location);
        if (coreAssemblyDirectoryPath == null)
        {
            throw new Exception("Could not find location of SKecommerce.Core assembly!");
        }

        var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
        while (!DirectoryContains(directoryInfo.FullName, "SKecommerce.Web.sln"))
        {
            if (directoryInfo.Parent == null)
            {
                throw new Exception("Could not find content root folder!");
            }

            directoryInfo = directoryInfo.Parent;
        }

        var webMvcFolder = Path.Combine(directoryInfo.FullName, $"Source{Path.DirectorySeparatorChar}SKecommerce.Web.Mvc");
        if (Directory.Exists(webMvcFolder))
        {
            return webMvcFolder;
        }

        var webHostFolder = Path.Combine(directoryInfo.FullName, $"Source{Path.DirectorySeparatorChar}SKecommerce.Web.Host");
        if (Directory.Exists(webHostFolder))
        {
            return webHostFolder;
        }

        throw new Exception("Could not find root folder of the web project!");
    }

    private static bool DirectoryContains(string directory, string fileName)
    {
        return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
    }
}