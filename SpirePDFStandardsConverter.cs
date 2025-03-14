using System.IO;
using OutSystems.ExternalLibraries.SDK;
using Spire.Pdf.Conversion;
using System;

namespace OutSystems.SpirePDF
{
    /// <summary>
    /// Provides functionality to convert a PDF document to a specified PDF/A format using the Spire.PDF library.
    /// The library supports various PDF/A standards, including '1A', '1B', '2A', '2B', '3A', and '3B'.
    /// Please note that the free version of the Spire.PDF library is limited to processing PDF files with a maximum of 10 pages.
    /// </summary>
    public class SpirePDFStandardsConverter : ISpirePDFStandardsConverter
    {
        /// <summary>
        /// Converts a PDF document to a specified PDF/A format based on the given standard.
        /// The method supports conversion to different PDF/A versions such as '1A', '1B', '2A', '2B', '3A', or '3B'.
        /// The conversion process uses the Spire.PDF library to ensure compliance with the chosen PDF/A standard.
        /// </summary>
        /// <param name="file">The PDF content as a byte array to be converted to PDF/A format.</param>
        /// <param name="standard">The PDF/A standard to which the document should be converted (e.g., '1A', '1B', '2A', '2B', '3A', or '3B').</param>
        /// <param name="pdfFile">The output byte array that will contain the converted PDF/A document.</param>
        /// <returns>A byte array indicating the success of the conversion process. A success flag or indicator.</returns>
        /// <exception cref="ArgumentException">Thrown when the file is null or empty, or the standard is not valid.</exception>
        [OSAction(Description = "Converts a PDF document to a specified PDF/A format. Supported standards include '1A', '1B', '2A', '2B', '3A', and '3B'. Free version supports only PDF files with up to 10 pages.")]
        public void ConvertPDFToPDFA(
            [OSParameter(Description = "The PDF file content as a byte array to be converted.")] byte[] file,
            [OSParameter(Description = "The PDF/A standard to convert the file to (e.g., '1A', '1B', '2A', '2B', '3A', '3B').")] string standard,
            [OSParameter(Description = "The output byte array that will contain the converted PDF/A document.")] out byte[] pdfFile)
        {
            // Validate input parameters
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("The provided file is empty or null.", nameof(file));
            }

            if (string.IsNullOrEmpty(standard))
            {
                throw new ArgumentException("The provided standard is empty or null.", nameof(standard));
            }

            // Convert the input file to PDF/A format
            using (MemoryStream memoryStream = new MemoryStream(file))
            {
                // Create a PdfStandardsConverter instance with the input PDF
                PdfStandardsConverter converter = new PdfStandardsConverter(memoryStream);

                using (MemoryStream outputStream = new MemoryStream())
                {
                    // Perform conversion based on the specified PDF/A standard
                    switch (standard.ToUpper())
                    {
                        case "1A":
                            converter.ToPdfA1A(outputStream);
                            break;

                        case "1B":
                            converter.ToPdfA1B(outputStream);
                            break;

                        case "2A":
                            converter.ToPdfA2A(outputStream);
                            break;

                        case "2B":
                            converter.ToPdfA2B(outputStream);
                            break;

                        case "3A":
                            converter.ToPdfA3A(outputStream);
                            break;

                        case "3B":
                            converter.ToPdfA3B(outputStream);
                            break;

                        default:
                            throw new ArgumentException($"Invalid PDF/A standard: {standard}. Supported values are '1A', '1B', '2A', '2B', '3A', and '3B'.", nameof(standard));
                    }

                    // Assign the converted PDF to the out parameter
                    pdfFile = outputStream.ToArray();
                }
            }
        }
    }
}