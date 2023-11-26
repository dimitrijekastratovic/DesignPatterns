using System;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility;

public class Document
{
    public string Title { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public bool ApprovedByDevelopers { get; set; }
    public bool ApprovedByManagement { get; set; }

    public Document(
        string title,
        DateTimeOffset lastModified,
        bool approvedByDevelopers,
        bool approvedByManagement)
    {
        Title = title;
        LastModified = lastModified;
        ApprovedByDevelopers = approvedByDevelopers;
        ApprovedByManagement = approvedByManagement;
    }
}

/// <summary>
/// Handler
/// </summary>
public interface IHandler<T> where T : class
{
    IHandler<T> SetSuccessor(IHandler<T> successor);
    void Handle(T request);
}

/// <summary>
/// Concrete handler
/// </summary>
public class DocumentTitleHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if(string.IsNullOrEmpty(document.Title))
        {
            throw new ValidationException(
                new ValidationResult("Title must not be empty",
                new List<string>() { "Title" }),
                null,
                null);
        }

        //next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}

/// <summary>
/// Concrete handler
/// </summary>
public class DocumentLastModifiedHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (document.LastModified < DateTime.UtcNow.AddDays(-30))
        {
            throw new ValidationException(
                new ValidationResult("Document must be modified in the last 30 days",
                new List<string>() { "LastModified" }),
                null,
                null);
        }

        //next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}

// <summary>
/// Concrete handler
/// </summary>
public class DocumentApprovedByDevelopersHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (!document.ApprovedByDevelopers)
        {
            throw new ValidationException(
                new ValidationResult("Document must be approved by developers",
                new List<string>() { "ApprovedByDevelopers" }),
                null,
                null);
        }

        //next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}

// <summary>
/// Concrete handler
/// </summary>
public class DocumentApprovedByManagementHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        if (!document.ApprovedByManagement)
        {
            throw new ValidationException(
                new ValidationResult("Document must be approved by management",
                new List<string>() { "ApprovedByManagement" }),
                null,
                null);
        }

        //next handler
        _successor?.Handle(document);
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}