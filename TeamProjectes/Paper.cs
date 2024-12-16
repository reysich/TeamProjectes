using System;
using TeamProjectes;


class Paper
{
    public string Title { get; set; }
    public Person Author { get; set; }
    public DateTime PublishDate { get; set; }

    public virtual object DeepCopy()
    {
        return new Paper(Title, (Person)Author.DeepCopy(), PublishDate);
    }

    public Paper(string title, Person author, DateTime publishDate) 
    {
        Title = title; 
        Author = author;
        PublishDate = publishDate; 
    }
    public Paper() 
    { 
        Title = "Название по умолчанию"; 
        Author = new Person(); 
        PublishDate = DateTime.Today; 
    }

    public override string ToString() 
    { 
        return $"Заголовок: {Title}, Автор: {Author}, Дата публикации: {PublishDate.ToShortDateString()}"; 
    }
}
