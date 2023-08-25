using Packt.Shared; // To use Viper.
using System.Xml; // To use XmlWriter and so on.

#region Writing to text streams

SectionTitle("Writing to text streams");

// Define a file to write to.
string textFile = Combine(CurrentDirectory, "streams.txt");

// Create a text file and return a helper writer.
StreamWriter text = File.CreateText(textFile);

// Enumerate the strings, writing each one to the stream
// on a separate line.
foreach (string item in Viper.Callsigns)
{
  text.WriteLine(item);
}
text.Close(); // Release unmanaged file resources.

OutputFileInfo(textFile);

#endregion

#region Writing to XML streams

SectionTitle("Writing to XML streams");

// Define a file path to write to.
string xmlFile = Combine(CurrentDirectory, "streams.xml");

// Declare variables for the filestream and XML writer.
FileStream? xmlFileStream = null;
XmlWriter? xml = null;

try
{
  xmlFileStream = File.Create(xmlFile);

  // Wrap the file stream in an XML writer helper and tell it
  // to automatically indent nested elements.
  xml = XmlWriter.Create(xmlFileStream,
    new XmlWriterSettings { Indent = true });

  // Write the XML declaration.
  xml.WriteStartDocument();

  // Write a root element.
  xml.WriteStartElement("callsigns");

  // Enumerate the strings, writing each one to the stream.
  foreach (string item in Viper.Callsigns)
  {
    xml.WriteElementString("callsign", item);
  }

  // Write the close root element.
  xml.WriteEndElement();
}
catch (Exception ex)
{
  // If the path doesn't exist the exception will be caught.
  WriteLine($"{ex.GetType()} says {ex.Message}");
}
finally
{
  if (xml is not null)
  {
    xml.Close();
    WriteLine("The XML writer's unmanaged resources have been disposed.");
  }

  if (xmlFileStream is not null)
  {
    xmlFileStream.Close();
    WriteLine("The file stream's unmanaged resources have been disposed.");
  }
}

OutputFileInfo(xmlFile);

#endregion

#region Compressing streams

SectionTitle("Compressing streams");
Compress(algorithm: "gzip");
Compress(algorithm: "brotli");

#endregion