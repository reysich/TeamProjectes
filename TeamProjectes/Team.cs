using System;
using System.Drawing;
using TeamProjectes;

internal class Team : INameAndCopy
{
    protected string nameOrganiz;
	protected int registrId;
	public string Name
	{
		set 
		{
			if (value == "")
			{
                throw new Exception("Пустая строка");
            }
			else
			{
                nameOrganiz = value;
            }
		}
		get { return nameOrganiz; }
	}
	public int RegistrId
	{
		set 
		{
			if(value <= 0)
			{
				throw new Exception("Реистрационный номер не может быть 0 или меньше");
			}
			else
			{
                registrId = value;
            }
		}
		get { return registrId; }
	}
    public Team()
	{
		registrId = 0;
		nameOrganiz = "default";
    }
	public Team (string nameOrganiz , int regisrtId)
	{
		this.nameOrganiz = nameOrganiz;
		this.registrId = regisrtId;
	}
	public virtual object DeepCopy()
	{
		return new Team(Name,registrId);
	}
	public virtual object DeepCpoy()
	{
		return new Team (nameOrganiz,registrId);
	}

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Team))
		{
            return false;
        }
        else
		{
            return nameOrganiz == (obj as Team).nameOrganiz && registrId == (obj as Team).registrId ;
        }
    }
    public static bool operator ==(Team t1, Team t2) 
	{
        if ((object)t1 == null) return (object)t2 == null;
        return t1.Equals(t2);
    }

    public static bool operator !=(Team t1, Team t2)
	{
        if ((object)t1 == null) return false;
        return !t1.Equals(t2); ; 
	}
    public override int GetHashCode()
    {
        return HashCode.Combine(nameOrganiz,registrId);
    }

    public override string ToString()
    {
        return $"Название организации:{Name}\nРегистрационный номер:{RegistrId}\n";
    }
}
