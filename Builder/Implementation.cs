using System;
using System.Text;

namespace Builder
{
	public class Car
	{
		private readonly List<string> _parts = new();
		private readonly string _carType;

		public Car(string carType)
		{
			_carType = carType;
		}

		public void AddPart(string part)
		{
			_parts.Add(part);
		}

        public override string ToString()
        {
			var s = new StringBuilder();
			foreach(var part in _parts)
			{
				s.Append($"Car of type {_carType} has part: {part}. ");
			}

            return s.ToString();
        }
    }

	public abstract class CarBuilder
	{
		public Car Car { get; private set; }

		public CarBuilder(string carType)
		{
			Car = new Car(carType);
		}

		public abstract void BuildEngine();
		public abstract void PaintFrame();
	}

	public class GolfBuilder : CarBuilder
	{
		public GolfBuilder()
			: base("Golf")
		{
		}

        public override void BuildEngine()
        {
            Car.AddPart("105hp");
        }

        public override void PaintFrame()
        {
			Car.AddPart("Blue");
        }
    }

    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder()
            : base("BMW")
        {
        }

        public override void BuildEngine()
        {
			Car.AddPart("177hp");
        }

        public override void PaintFrame()
        {
            Car.AddPart("Black");
        }
    }

	public class Garage
	{
		private CarBuilder? _builder;

		public Garage()
		{

		}

		public void Construct(CarBuilder builder)
		{
			_builder = builder;
			_builder.BuildEngine();
			_builder.PaintFrame();
        }

		public void Show()
		{
			Console.WriteLine(_builder?.Car.ToString());
		}
	}
}

