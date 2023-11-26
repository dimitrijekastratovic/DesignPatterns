using System;
namespace Iterator
{
	//IPeopleIterator
	//PeopleIterator

	//IPeopleCollection
	//PeopleCollection

	public class Person
	{
		public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

		public Person(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

    }

    /// <summary>
    /// Iterator
    /// </summary>
    public interface IPeopleIterator
	{
		Person First();
		Person Next();
		bool IsDone { get; }
		Person CurrentItem { get; }
	}

    /// <summary>
    /// Concrete Iterator
    /// </summary>
    public class PeopleIterator : IPeopleIterator
    {
        private PeopleCollection _peopleCollection;
        private int _current = 0;

        public PeopleIterator(PeopleCollection collection)
        {
            _peopleCollection = collection;
        }

        public Person First()
        {
            _current = 0;
            return _peopleCollection[_current];
        }

        public Person Next()
        {
            _current++;
            return IsDone ? null! : _peopleCollection[_current];
        }

        public bool IsDone { get { return _current >= _peopleCollection.Count; } }

        public Person CurrentItem { get { return _peopleCollection[_current]; } }
    }

    /// <summary>
    /// Aggregate
    /// </summary>
    public interface IPeopleCollection
	{
		IPeopleIterator CreateIterator();
	}

    /// <summary>
    /// Concrete Aggregate
    /// </summary>
    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }
}

