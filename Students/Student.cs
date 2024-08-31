using System;

namespace ApiCrud.Students {

	public class Student
	{
		public Guid Id { get; init; }
		public string Name { get; private set; }
		public bool Active { get; set; }

		public Student(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
			Active = true;
		}
	}
}