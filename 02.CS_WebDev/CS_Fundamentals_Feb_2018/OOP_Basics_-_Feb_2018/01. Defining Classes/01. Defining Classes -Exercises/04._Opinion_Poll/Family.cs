using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Family
{
    private List<Person> members;

    public Family()
    {
        this.members = new List<Person>();
    }

    public List<Person> Members
    {
        get { return this.members; }
        private set
        {
            this.members = value;
        }
    }

    public void AddMember(Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.members
            .OrderByDescending(p => p.Age)
            .FirstOrDefault();

    }
}