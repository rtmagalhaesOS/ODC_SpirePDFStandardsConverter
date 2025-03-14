using OutSystems.ExternalLibraries.SDK;

namespace OutSystems.SpirePDF
{
    /// <summary>
    /// Provides functionality for working with PDF files using the Free Spire.PDF for .NET library.
    /// Supports conversion of PDF documents to PDF/A format and merging multiple PDFs into a single file.
    /// </summary>
    /// <remarks>
    /// - The free version of Spire.PDF for .NET supports processing PDF documents with a maximum of **10 pages**.
    /// - Supports conversion to multiple PDF/A standards, including **PDF/A-1A, PDF/A-1B, PDF/A-2A, PDF/A-2B, PDF/A-3A, and PDF/A-3B**.
    /// - Provides functionality to **merge multiple PDFs** into a single document.
    /// </remarks>
    [OSInterface(Description = "Extension for the Free Spire.PDF for .NET library, enabling conversion of PDF documents to PDF/A format. The free version of the library is limited to processing PDFs with up to 10 pages.",
        IconResourceName = "SpirePDFStandardsConverter.resources.PDF-NET.png")]
    public interface ISpirePDFStandardsConverter
    {
        /// <summary>
        /// Converts a given PDF file (as a byte array) to a specified PDF/A standard (e.g., '1A', '1B', '2A', '2B', '3A', '3B').
        /// </summary>
        /// <param name="file">The PDF file content represented as a byte array to be converted.</param>
        /// <param name="standard">The PDF/A standard to which the file should be converted, such as '1A', '1B', '2A', '2B', '3A', or '3B'.</param>.
        /// <param name="pdfFile">The output byte array that will contain the converted PDF/A document.</param>
        /// <returns>The converted PDF content as a byte array in the specified PDF/A standard.</returns>
        void ConvertPDFToPDFA(
            [OSParameter(Description = "The PDF file content as a byte array to be converted.")] byte[] file,
            [OSParameter(Description = "The PDF/A standard to convert the file to (e.g., '1A', '1B', '2A', '2B', '3A', '3B').")] string standard,
            [OSParameter(Description = "The output byte array that will contain the converted PDF/A document.")] out byte[] pdfFile);
    }
}