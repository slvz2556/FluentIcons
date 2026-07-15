using FluentIcons.Models;
using System.Text.Json;

namespace FluentIcons.Service;

public static class Manager
{
    public static void Initialize()
    {
        List<IconModel> Icons = new List<IconModel>();
        Icons.Clear();

#if DEBUG
        var directories = Directory.GetDirectories(@"C:\Users\SLVZ\OneDrive\SLVZ\Web\FluentIcons\wwwroot\icons");
#else
        var directories = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "icons"));
#endif

        int index = 0;

        foreach (var directory in directories)
        {
            var info = new DirectoryInfo(directory);
            var files = info.GetFiles();

            var icon = new IconModel
            {
                Id = index++,
                Name = info.Name,
                FilePreview = files.Any(x => x.Name.EndsWith("regular.svg")) ?
                files.Where(x => x.Name.EndsWith("regular.svg")).First().Name : files.First().Name
            };

            foreach (var f in files)
                icon.Files.Add(f.Name);

            Icons.Add(icon);
        }

        File.WriteAllText(Path.Combine(@"C:\Users\SLVZ\OneDrive\SLVZ\Web\FluentIcons\wwwroot\icons.json"),
            JsonSerializer.Serialize<List<IconModel>>(Icons));

    }
}
