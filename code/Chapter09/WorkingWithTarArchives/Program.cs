using System.Formats.Tar; // TarFile

try
{
  string current = Environment.CurrentDirectory;
  WriteInformation($"Current directory:   {current}");

  string sourceDirectory = Path.Combine(current, "images");
  string destinationDirectory = Path.Combine(current, "extracted");
  string tarFile = Path.Combine(current, "images-archive.tar");

  if (!Directory.Exists(sourceDirectory))
  {
    WriteError($"The {sourceDirectory} directory must exist. Please create it and add some files to it.");
    return;
  }

  if (File.Exists(tarFile))
  {
    // If the Tar archive file already exists then we must delete it.
    File.Delete(tarFile);
    WriteWarning($"{tarFile} already existed so it was deleted.");
  }

  WriteInformation(
    $"Archiving directory: {sourceDirectory}\n      To .tar file:        {tarFile}");

  TarFile.CreateFromDirectory(
    sourceDirectoryName: sourceDirectory,
    destinationFileName: tarFile,
    includeBaseDirectory: true);

  WriteInformation($"Does {tarFile} exist? {File.Exists(tarFile)}.");

  if (!Directory.Exists(destinationDirectory))
  {
    // If the destination directory does not exist then we must create
    // it before extracting a Tar archive to it.
    Directory.CreateDirectory(destinationDirectory);
    WriteWarning($"{destinationDirectory} did not exist so it was created.");
  }

  WriteInformation(
    $"Extracting archive:  {tarFile}\n      To directory:        {destinationDirectory}");

  TarFile.ExtractToDirectory(
    sourceFileName: tarFile,
    destinationDirectoryName: destinationDirectory,
    overwriteFiles: true);

  if (Directory.Exists(destinationDirectory))
  {
    foreach (string dir in Directory.GetDirectories(destinationDirectory))
    {
      WriteInformation(
        $"Extracted directory {dir} containing these files: " +
        string.Join(',', Directory.EnumerateFiles(dir)
          .Select(file => Path.GetFileName(file))));
    }
  }
}
catch (Exception ex)
{
  WriteError(ex.Message);
}
