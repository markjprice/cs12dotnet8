#region Handling cross-platform environments and filesystems

SectionTitle("Handling cross-platform environments and filesystems");
WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator",
  arg1: PathSeparator);
WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar",
  arg1: DirectorySeparatorChar);
WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",
  arg1: GetCurrentDirectory());
WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",
  arg1: CurrentDirectory);
WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",
  arg1: SystemDirectory);
WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",
  arg1: GetTempPath());
WriteLine("GetFolderPath(SpecialFolder");
WriteLine("{0,-33} {1}", arg0: " .System)",
  arg1: GetFolderPath(SpecialFolder.System));
WriteLine("{0,-33} {1}", arg0: " .ApplicationData)",
  arg1: GetFolderPath(SpecialFolder.ApplicationData));
WriteLine("{0,-33} {1}", arg0: " .MyDocuments)",
  arg1: GetFolderPath(SpecialFolder.MyDocuments));
WriteLine("{0,-33} {1}", arg0: " .Personal)",
  arg1: GetFolderPath(SpecialFolder.Personal));

#endregion

#region Managing drives

SectionTitle("Managing drives");
WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
  "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");

foreach (DriveInfo drive in DriveInfo.GetDrives())
{
  if (drive.IsReady)
  {
    WriteLine(
      "{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
      drive.Name, drive.DriveType, drive.DriveFormat,
      drive.TotalSize, drive.AvailableFreeSpace);
  }
  else
  {
    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
  }
}

#endregion

#region Managing directories

SectionTitle("Managing directories");

string newFolder = Combine(
  GetFolderPath(SpecialFolder.Personal), "NewFolder");

WriteLine($"Working with: {newFolder}");

// We must explicitly say which Exists method to use 
// because we statically imported both Path and Directory.
WriteLine($"Does it exist? {Path.Exists(newFolder)}");

WriteLine("Creating it...");
CreateDirectory(newFolder);

// Let's use the Directory.Exists method this time.
WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
Write("Confirm the directory exists, and then press any key.");
ReadKey(intercept: true);

WriteLine("Deleting it...");
Delete(newFolder, recursive: true);
WriteLine($"Does it exist? {Path.Exists(newFolder)}");

#endregion

#region Managing files

SectionTitle("Managing files");

// Define a directory path to output files starting
// in the user's folder.
string dir = Combine(
  GetFolderPath(SpecialFolder.Personal), "OutputFiles");

CreateDirectory(dir);

// Define file paths.
string textFile = Combine(dir, "Dummy.txt");
string backupFile = Combine(dir, "Dummy.bak");
WriteLine($"Working with: {textFile}");

WriteLine($"Does it exist? {File.Exists(textFile)}");

// Create a new text file and write a line to it.
StreamWriter textWriter = File.CreateText(textFile);
textWriter.WriteLine("Hello, C#!");
textWriter.Close(); // Close file and release resources.
WriteLine($"Does it exist? {File.Exists(textFile)}");

// Copy the file, and overwrite if it already exists.
File.Copy(sourceFileName: textFile,
  destFileName: backupFile, overwrite: true);

WriteLine(
  $"Does {backupFile} exist? {File.Exists(backupFile)}");

Write("Confirm the files exist, and then press any key.");
ReadKey(intercept: true);

// Delete the file.
File.Delete(textFile);
WriteLine($"Does it exist? {File.Exists(textFile)}");

// Read from the text file backup.
WriteLine($"Reading contents of {backupFile}:");
StreamReader textReader = File.OpenText(backupFile);
WriteLine(textReader.ReadToEnd());
textReader.Close();

#endregion

#region Managing paths

SectionTitle("Managing paths");

WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
WriteLine($"File Name: {GetFileName(textFile)}");
WriteLine("File Name without Extension: {0}",
  GetFileNameWithoutExtension(textFile));
WriteLine($"File Extension: {GetExtension(textFile)}");
WriteLine($"Random File Name: {GetRandomFileName()}");
WriteLine($"Temporary File Name: {GetTempFileName()}");

#endregion

#region Getting file information

SectionTitle("Getting file information");

FileInfo info = new(backupFile);
WriteLine($"{backupFile}:");
WriteLine($"Contains {info.Length} bytes.");
WriteLine($"Last accessed {info.LastAccessTime}");
WriteLine($"Has readonly set to {info.IsReadOnly}.");

#endregion

#region Controlling how you work with files

WriteLine("Is the backup file compressed? {0}",
  info.Attributes.HasFlag(FileAttributes.Compressed));

#endregion
