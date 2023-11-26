using System;
namespace Proxy
{
    //Virutal + Protected

    public interface IDocument
    {
        void DisplayDocument();
    }

    /// <summary>
    /// Real Subject
    /// </summary>
	public class Document : IDocument
	{
		public string? Title { get; set; }
        public string? Content { get; set; }
        public int AuthorId { get; set; }

        public DateTimeOffset LastAccessed { get; private set; }
        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Loading file from disk...");
            Thread.Sleep(1000);

            Title = "Title";
            Content = "Content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Title:{Title}, Content:{Content}");
        }
    }

    /// <summary>
    /// Proxy
    /// </summary>
    public class DocumentProxy : IDocument
    {
        //private Document? _document;
        private Lazy<Document> _document;
        private string _fileName;

        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }

        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();
        }
    }

    public class ProtectedDocumentProxy : IDocument
    {
        private string _fileName;
        private string _userRole;
        private DocumentProxy _documentProxy;

        public ProtectedDocumentProxy(string fileName, string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(fileName);
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Displaying document in {nameof(ProtectedDocumentProxy)}");

            if(_userRole != "Viewer")
            {
                throw new UnauthorizedAccessException();
            }

            _documentProxy.DisplayDocument();

            Console.WriteLine($"Exiting display in {nameof(ProtectedDocumentProxy)}");
        }
    }
}

